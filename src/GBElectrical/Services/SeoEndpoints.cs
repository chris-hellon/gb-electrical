using System.Text;
using System.Xml.Linq;
using GBElectrical.Content;
using Microsoft.Extensions.Options;

namespace GBElectrical.Services;

/// <summary>robots.txt and sitemap.xml, built from <see cref="SiteOptions"/> so they always point at the live domain.</summary>
public static class SeoEndpoints
{
    private static readonly XNamespace SitemapNs = "http://www.sitemaps.org/schemas/sitemap/0.9";
    private static readonly XNamespace ImageNs = "http://www.google.com/schemas/sitemap-image/1.1";

    public static IEndpointRouteBuilder MapSeoEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/robots.txt", (IOptions<SiteOptions> options) =>
        {
            var site = options.Value;
            var body = site.AllowIndexing
                ? $"User-agent: *\nAllow: /\n\nSitemap: {site.Url("sitemap.xml")}\n"
                : "User-agent: *\nDisallow: /\n";
            return Results.Text(body, "text/plain", Encoding.UTF8);
        });

        app.MapGet("/sitemap.xml", (IOptions<SiteOptions> options) =>
        {
            var site = options.Value;

            // One page, plus every job photo as an image entry so they can show up in Google Images.
            var images = new[] { Seo.ShareImagePath }
                .Concat(SiteContent.LightboxPhotos.Select(p => p.Src))
                .Distinct()
                .Select(src => new XElement(ImageNs + "image", new XElement(ImageNs + "loc", site.Url(src))));

            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(SitemapNs + "urlset",
                    new XAttribute(XNamespace.Xmlns + "image", ImageNs),
                    new XElement(SitemapNs + "url",
                        new XElement(SitemapNs + "loc", site.Url("/")),
                        images)));

            return Results.Text(doc.Declaration + "\n" + doc.Root, "application/xml", Encoding.UTF8);
        });

        return app;
    }
}
