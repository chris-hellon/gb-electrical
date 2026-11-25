namespace GBElectrical.Services;

/// <summary>Bound from the "Web3Forms" config section. Get a free access key at https://web3forms.com for info@gb-electrical.com.</summary>
public sealed class Web3FormsOptions
{
    public const string Placeholder = "YOUR_WEB3FORMS_ACCESS_KEY";

    public string AccessKey { get; set; } = Placeholder;
    public string Subject { get; set; } = "New enquiry from gb-electrical.com";
    public string FromName { get; set; } = "GB Electrical website";

    public bool IsConfigured => !string.IsNullOrWhiteSpace(AccessKey) && !AccessKey.StartsWith("YOUR_", StringComparison.Ordinal);
}
