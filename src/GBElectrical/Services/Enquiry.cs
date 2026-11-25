using System.ComponentModel.DataAnnotations;

namespace GBElectrical.Services;

/// <summary>Quote request from the contact form.</summary>
public sealed class Enquiry
{
    [Required] public string Name { get; set; } = "";
    public string? Phone { get; set; }
    [Required, EmailAddress] public string Email { get; set; } = "";
    public string Service { get; set; } = "Solar PV";
    [Required] public string Message { get; set; } = "";

    /// <summary>Honeypot. Hidden from people; bots tick it and Web3Forms drops the submission.</summary>
    public bool Botcheck { get; set; }
}
