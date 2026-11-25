# GB Electrical

Website for **GB Electrical**, an NICEIC Approved Contractor based in Birkenhead, Wirral, with over 20 years' experience.
They do domestic and commercial work across the North West, with solar PV as their main focus, plus air source heat pumps,
rewires, inspection and testing, security, and commercial and feature lighting.

It's a single-page site built with **Blazor on .NET 10**.

## Features

### Page sections
- **Hero** with a solar-led headline, calls to action and a photo of recent work
- **Trust strip** with the NICEIC badge and key selling points
- **Solar PV** pitch, benefits and a four-step guide to how an install works
- **Services:** six service cards plus a "we also do" list
- **Featured projects:** MediCinema at Alder Hey Children's Hospital and the Birkenhead Drill mural lighting
- **Recent work** photo gallery
- **About** section with key stats
- **Careers:** current vacancies
- **FAQ** accordion
- **Contact:** phone, email, Facebook and a quote request form
- **Mobile call bar** that stays at the bottom of the screen on phones

### Interactive features
- **Responsive layout** for phones, tablets and desktops, with a collapsible mobile menu
- **Photo lightbox** for all project and gallery photos, with keyboard navigation (arrow keys and Escape)
- **Quote request form** with validation and spam protection, sent through [Web3Forms](https://web3forms.com)

### Accessibility
- Skip-to-content link, a labelled menu button with `aria-expanded`, and real buttons for photos
- Labelled form fields, with form messages announced to screen readers
- Focus moves into the photo viewer and returns afterwards; visible focus outlines
- Touch targets of at least 44px; respects the reduced-motion setting

### SEO
- Title, description, canonical URL and robots meta tags, all in the first HTML response
- Open Graph and Twitter/X cards with a 1200×630 share image
- schema.org structured data: `Electrician` (a LocalBusiness type), `WebSite`, `WebPage` and `FAQPage`
- `robots.txt` and `sitemap.xml` generated at runtime, with job photos listed for Google Images
- Favicon, Apple touch icon and web manifest
- Real 404 responses with `noindex`, and a high fetch priority for the main hero image

## Tech

- .NET 10 / Blazor Web App (Interactive Server, with prerendering)
- Plain CSS: global BEM-style classes, with brand colours and spacing set as variables in `wwwroot/css/styles.css`
- A few small JavaScript modules for browser-only behaviour (the photo viewer's `<dialog>`, the Escape key, form submission)
- Montserrat and Lato from Google Fonts

| Brand colour | Hex |
|---|---|
| Navy | `#032A4B` |
| Deep navy | `#011E37` |
| Orange | `#F4572C` |
| Grey | `#E5E5E5` |

## Getting started

You need the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/chris-hellon/gb-electrical.git
cd gb-electrical
dotnet run --project src/GBElectrical --launch-profile http
```

Then open http://localhost:5189.

## Configuration

| Setting | Purpose |
|---|---|
| `Site:BaseUrl` | The live site address, used for canonical URLs, social tags, structured data and the sitemap. The default is `https://gb-electrical.com`. |
| `Site:AllowIndexing` | Set it to `false` on staging copies to block search engines. |
| `Web3Forms:AccessKey` | Access key for the contact form. Keep it out of source control. |

To set the form key locally:

```bash
dotnet user-secrets set "Web3Forms:AccessKey" "<your-key>" --project src/GBElectrical
```

In production, set the environment variable `Web3Forms__AccessKey` instead.

## Project structure

```
src/GBElectrical/
├── Components/
│   ├── Pages/        Home page, 404 and error pages
│   ├── Sections/     One component per page section (Hero, SolarFeature, ServicesGrid, ContactForm, …)
│   └── Shared/       Icon, Logo, Lightbox, SeoHead and other reusable pieces
├── Content/          Site copy and lists (services, projects, gallery, FAQs) as C# records
├── Services/         Form model, settings, structured data, robots.txt and sitemap endpoints
└── wwwroot/          CSS, images, icons and the web manifest
```

Most copy changes, such as adding a gallery photo, a service or an FAQ, only need an edit to `Content/SiteContent.cs`.

## Credits

Photos are of GB Electrical's own work, from their [Facebook page](https://www.facebook.com/gbelectricalltd).
