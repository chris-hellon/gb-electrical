using System.Text.Json;
using System.Text.Json.Nodes;
using GBElectrical.Content;

namespace GBElectrical.Services;

/// <summary>
/// Builds the schema.org JSON-LD for the home page: the business (Electrician, a LocalBusiness type),
/// the website, the page itself and the FAQs.
/// Anything still marked "[Confirm]" (or other [placeholder] text) is left out until it's confirmed,
/// so unconfirmed claims never reach search engines' structured data.
/// </summary>
public static class StructuredData
{
    public static string ForHomePage(SiteOptions site, string title, string description)
    {
        var home = site.Url("/");
        var businessId = home + "#business";
        var websiteId = home + "#website";

        var business = new JsonObject
        {
            ["@type"] = "Electrician",
            ["@id"] = businessId,
            ["name"] = Site.Name,
            ["url"] = home,
            ["logo"] = site.Url(Seo.LogoPath),
            ["image"] = new JsonArray(site.Url(Seo.ShareImagePath), site.Url("img/work/medicinema-1.jpg")),
            ["description"] = description,
            ["telephone"] = Site.PhoneInternational,
            ["email"] = Site.Email,
            ["address"] = new JsonObject
            {
                ["@type"] = "PostalAddress",
                ["addressLocality"] = "Birkenhead",
                ["addressRegion"] = "Merseyside",
                ["addressCountry"] = "GB",
            },
            ["areaServed"] = new JsonArray(
                Place("City", "Birkenhead"),
                Place("AdministrativeArea", "Wirral"),
                Place("AdministrativeArea", "Merseyside"),
                Place("AdministrativeArea", "North West England")),
            ["sameAs"] = new JsonArray(Site.FacebookUrl),
            ["hasCredential"] = new JsonObject
            {
                ["@type"] = "EducationalOccupationalCredential",
                ["credentialCategory"] = "certification",
                ["name"] = "NICEIC Approved Contractor",
                ["recognizedBy"] = new JsonObject { ["@type"] = "Organization", ["name"] = "NICEIC", ["url"] = "https://www.niceic.com" },
            },
            ["knowsAbout"] = new JsonArray(SiteContent.Services.Select(s => (JsonNode)s.Title).ToArray()),
            ["hasOfferCatalog"] = new JsonObject
            {
                ["@type"] = "OfferCatalog",
                ["name"] = "Electrical and renewable energy services",
                ["itemListElement"] = new JsonArray(SiteContent.Services.Select(ServiceOffer).ToArray()),
            },
        };

        var website = new JsonObject
        {
            ["@type"] = "WebSite",
            ["@id"] = websiteId,
            ["url"] = home,
            ["name"] = Site.Name,
            ["inLanguage"] = "en-GB",
            ["publisher"] = new JsonObject { ["@id"] = businessId },
        };

        var webPage = new JsonObject
        {
            ["@type"] = "WebPage",
            ["@id"] = home + "#webpage",
            ["url"] = home,
            ["name"] = title,
            ["description"] = description,
            ["inLanguage"] = "en-GB",
            ["isPartOf"] = new JsonObject { ["@id"] = websiteId },
            ["about"] = new JsonObject { ["@id"] = businessId },
            ["primaryImageOfPage"] = new JsonObject { ["@type"] = "ImageObject", ["url"] = site.Url(Seo.ShareImagePath) },
        };

        var graph = new JsonArray(business, website, webPage);

        var faqs = SiteContent.Faqs.Where(f => IsConfirmed(f.Question) && IsConfirmed(f.Answer)).ToList();
        if (faqs.Count > 0)
        {
            graph.Add(new JsonObject
            {
                ["@type"] = "FAQPage",
                ["@id"] = home + "#faq",
                ["mainEntity"] = new JsonArray(faqs.Select(f => (JsonNode)new JsonObject
                {
                    ["@type"] = "Question",
                    ["name"] = f.Question,
                    ["acceptedAnswer"] = new JsonObject { ["@type"] = "Answer", ["text"] = f.Answer },
                }).ToArray()),
            });
        }

        var root = new JsonObject { ["@context"] = "https://schema.org", ["@graph"] = graph };

        // The default encoder escapes <, > and &, so the JSON can't break out of its <script> tag.
        return root.ToJsonString(new JsonSerializerOptions { WriteIndented = false });
    }

    /// <summary>True when the text has no [placeholder] still waiting to be confirmed.</summary>
    public static bool IsConfirmed(string text) => !text.Contains('[');

    private static JsonNode Place(string type, string name) => new JsonObject { ["@type"] = type, ["name"] = name };

    private static JsonNode ServiceOffer(Service service)
    {
        var item = new JsonObject { ["@type"] = "Service", ["name"] = service.Title };
        if (IsConfirmed(service.Description)) item["description"] = service.Description;
        return new JsonObject { ["@type"] = "Offer", ["itemOffered"] = item };
    }
}
