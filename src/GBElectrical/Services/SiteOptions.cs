namespace GBElectrical.Services;

/// <summary>Bound from the "Site" config section. Used for canonical URLs, social tags, structured data and the sitemap.</summary>
public sealed class SiteOptions
{
    /// <summary>The live site's address, without a trailing slash. Absolute URLs (canonical, og:image, sitemap) are built from it.</summary>
    public string BaseUrl { get; set; } = "https://gb-electrical.com";

    /// <summary>Set to false on staging or test copies so search engines don't index them.</summary>
    public bool AllowIndexing { get; set; } = true;

    public string Url(string path = "/") => BaseUrl.TrimEnd('/') + "/" + path.TrimStart('/');
}
