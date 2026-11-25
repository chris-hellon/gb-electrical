namespace GBElectrical.Content;

// All page copy that repeats lives here as records, rendered with @foreach.
// PLACEHOLDERS: text in [square brackets] still needs confirming with GB Electrical. Search for "[".

/// <summary>Business-wide contact facts (confirmed by the owner).</summary>
public static class Site
{
    public const string Name = "GB Electrical";
    public const string PhoneDisplay = "07763 941362";
    public const string PhoneHref = "tel:07763941362";
    public const string PhoneInternational = "+44 7763 941362";
    public const string Email = "info@gb-electrical.com";
    public const string EmailHref = "mailto:info@gb-electrical.com";
    public const string FacebookUrl = "https://www.facebook.com/gbelectricalltd";
    public const string FacebookPhotosUrl = "https://www.facebook.com/gbelectricalltd/photos";
}

/// <summary>Search and social sharing defaults for the home page.</summary>
public static class Seo
{
    // Google shows roughly the first 60 characters of a title and 155-160 of a description in results.
    public const string Title = "Solar PV & Electricians in Birkenhead, Wirral | GB Electrical";
    public const string Description = "NICEIC approved electricians in Birkenhead with 20+ years' experience. Solar PV, heat pumps, rewires, testing and lighting across the North West.";
    public const string ShareImagePath = "img/og-image.jpg";
    public const string ShareImageAlt = "Red feature wall with LED lighting installed by GB Electrical at MediCinema, Alder Hey";
    public const string LogoPath = "img/icons/icon-512.png";
    public const string ThemeColor = "#032A4B";
}

/// <summary>A photo that can be opened in the lightbox. Caption is the lightbox title (data-caption in the static build).</summary>
public sealed record Photo(string Src, string Alt, string Caption);

public sealed record SolarStep(string Title, string Description);

public sealed record Service(string Title, string Description, string Icon, bool IsFeature = false);

public sealed record ProjectShot(Photo Photo, string CssClass);

public sealed record Project(
    string Kicker,
    string Title,
    string Description,
    IReadOnlyList<string> Facts,
    IReadOnlyList<ProjectShot> Shots,
    bool Flip = false);

/// <summary>A gallery tile. Size is "tall", "wide" or null. A null Photo renders the "See it on Facebook" tile.</summary>
public sealed record GalleryItem(string? Size, Photo? Photo, string Label);

public sealed record Role(string Title, string Detail);

public sealed record Faq(string Question, string Answer);

public static class SiteContent
{
    public static readonly IReadOnlyList<string> SolarBenefits =
    [
        "Cut your electricity bills by using the power you generate",
        "Rely less on the grid and rising energy prices",
        "Pairs well with an air source heat pump",
        "[Confirm] Battery storage available to use your power after dark",
    ];

    public static readonly IReadOnlyList<SolarStep> SolarSteps =
    [
        new("Free survey", "We visit, check your roof, orientation and current usage, and talk through what you want from solar."),
        new("System design & quote", "A system sized for your home or business, with a clear, fixed quote and no pressure."),
        new("Installation", "Panels, inverter and electrics fitted by our own installers, with minimal disruption."),
        new("Tested, certified & registered", "Everything is tested and certified, and we handle the paperwork, including notifying your network operator."),
    ];

    public static readonly IReadOnlyList<Service> Services =
    [
        new("Solar PV", "Roof-mounted solar panel systems for homes and commercial buildings, designed and installed in-house.", "solar", IsFeature: true),
        new("Air source heat pumps", "Efficient low-carbon heating, with the electrical supply and controls fitted properly.", "heat-pump"),
        new("Rewires", "Full and partial rewires, consumer unit upgrades and new circuits for renovations and extensions.", "pulse"),
        new("Inspection & testing", "EICRs and periodic inspections for homeowners, landlords and businesses.", "clipboard"),
        new("Security", "[Confirm] Security lighting, CCTV and alarm systems to protect your property.", "shield"),
        new("Commercial & feature lighting", "Statement lighting for venues and public spaces, plus kitchens, gardens and extensions at home.", "bulb"),
    ];

    public static readonly IReadOnlyList<string> AlsoDo =
    [
        "Consumer units", "Kitchens & extensions", "Garden & outdoor lighting", "Fault finding", "Heating controls",
    ];

    public static readonly IReadOnlyList<Project> Projects =
    [
        new(
            Kicker: "Commercial · Liverpool",
            Title: "MediCinema at Alder Hey Children’s Hospital",
            Description: "[Confirm] Electrical and feature lighting installation for the hospital cinema, from LED feature walls and illuminated signage to the lighting in the screening room.",
            Facts: ["Feature lighting", "LED installation", "Commercial"],
            Shots:
            [
                new(new("img/work/medicinema-entrance.jpg", "MediCinema entrance with green LED lighting", "MediCinema, Alder Hey: entrance"), "shot--a"),
                new(new("img/work/medicinema-2.jpg", "Illuminated elephant and heart feature wall", "MediCinema, Alder Hey: feature wall"), "shot--b"),
                new(new("img/work/medicinema-seating.jpg", "Cinema seating with coloured wall lighting", "MediCinema, Alder Hey: cinema seating"), "shot--c"),
                new(new("img/work/medicinema-3.jpg", "MediCinema lobby with film-reel sign", "MediCinema, Alder Hey: lobby"), "shot--d"),
            ]),
        new(
            Kicker: "Public art · Birkenhead",
            Title: "Lighting the Birkenhead Drill mural",
            Description: "[Confirm] Floodlighting for the landmark “Birkenhead Drill” mural, so it can be seen by everyone heading for the Wallasey tunnel after dark.",
            Facts: ["Exterior lighting", "Landmark", "Birkenhead"],
            Shots:
            [
                new(new("img/work/mural-night.jpg", "The Birkenhead Drill mural illuminated at night above the street", "The Birkenhead Drill mural, lit at night"), "shot--tall-a"),
                new(new("img/work/mural-install.jpg", "Electrician fitting lighting at the foot of the mural", "Birkenhead Drill: fitting the lighting"), "shot--tall-b"),
            ],
            Flip: true),
    ];

    // Add more photos here; "tall" spans two rows, "wide" spans two columns.
    public static readonly IReadOnlyList<GalleryItem> Gallery =
    [
        new("tall", new("img/work/kitchen-pendants.jpg", "Kitchen island with black pendant lights", "Kitchen pendant lighting"), "Kitchen lighting"),
        new("wide", new("img/work/garden-lighting-1.jpg", "Garden patio with spike lights at night", "Garden lighting"), "Garden lighting"),
        new("tall", new("img/work/consumer-unit-1.jpg", "New consumer unit installed", "Consumer unit upgrade"), "Consumer units"),
        new(null, new("img/work/plinth-lights.jpg", "Kitchen plinth lights glowing along the units", "Kitchen plinth lights"), "Plinth lights"),
        new(null, new("img/work/kitchen-skylight.jpg", "Kitchen extension with skylight and recessed spotlights", "Spotlights under a skylight"), "Spotlights"),
        new("wide", new("img/work/house-exterior.jpg", "Detached house with driveway and fence lights at dusk", "Driveway and fence lighting"), "Exterior lighting"),
        new("wide", new("img/work/extension.jpg", "Rear extension with outdoor wall lights", "Extension electrics"), "Extensions"),
        new("wide", new("img/work/kitchen-undercab.jpg", "Kitchen with under-cabinet lighting", "Under-cabinet kitchen lighting"), "Under-cabinet lighting"),
        new(null, new("img/work/garden-lighting-2.jpg", "Garden seating area lit at night", "Garden lighting"), "Outdoor"),
        new(null, new("img/work/consumer-unit-2.jpg", "New wiring and consumer unit during a rewire", "Rewire and new consumer unit"), "Rewires"),
        new("wide", null, "More of our work"),
        new("wide", new("img/work/van-grey.jpg", "GB Electrical vans on site", "On site with the GB Electrical vans"), "On site"),
    ];

    /// <summary>Every lightbox photo in page order (projects first, then recent work), matching the static build's prev/next order.</summary>
    public static readonly IReadOnlyList<Photo> LightboxPhotos =
        Projects.SelectMany(p => p.Shots.Select(s => s.Photo))
            .Concat(Gallery.Where(g => g.Photo is not null).Select(g => g.Photo!))
            .ToList();

    public static readonly IReadOnlyList<Role> Roles =
    [
        new("Qualified electricians", "Solar PV experience preferred"),
        new("Solar panel fitters", "Experienced installers"),
        new("Surveyor", "Solar site surveys"),
        new("Electricians’ mates", "Domestic & commercial"),
    ];

    public static readonly IReadOnlyList<Faq> Faqs =
    [
        new("Is my roof suitable for solar panels?", "Most roofs can take solar. Direction, pitch, shading and condition all play a part. We check all of this on a free survey and will tell you honestly if it isn’t worth it."),
        new("Do I need planning permission for solar?", "Usually not. Most domestic roof-mounted systems count as permitted development, but listed buildings and conservation areas can be different. We’ll check for you before any work starts."),
        new("Can solar work with a heat pump?", "Yes. Heat pumps run on electricity, so generating your own with solar can help offset what they use. We install both and can plan them together."),
        new("Are you NICEIC approved?", "Yes. We’re an NICEIC Approved Contractor, and all of our work is tested and certified."),
        new("Do you work on commercial properties?", "Yes. We do domestic and commercial work, from rewires and testing to feature lighting for venues like MediCinema at Alder Hey."),
        new("Are quotes free?", "[Confirm] Yes. Surveys and quotes are free and there’s no obligation."),
    ];

    public static readonly IReadOnlyList<string> EnquiryServices =
    [
        "Solar PV", "Air source heat pump", "Rewire", "Inspection & testing", "Security", "Commercial work", "Something else",
    ];
}
