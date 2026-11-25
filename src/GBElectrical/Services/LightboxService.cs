using GBElectrical.Content;
using Microsoft.AspNetCore.Components;

namespace GBElectrical.Services;

/// <summary>
/// Per-circuit bridge between the photo buttons (in Projects and Recent work) and the single Lightbox dialog.
/// </summary>
public sealed class LightboxService
{
    public event Func<int, ElementReference, Task>? OpenRequested;

    public Task OpenAsync(Photo photo, ElementReference trigger)
    {
        var index = -1;
        for (var i = 0; i < SiteContent.LightboxPhotos.Count; i++)
        {
            if (ReferenceEquals(SiteContent.LightboxPhotos[i], photo)) { index = i; break; }
        }
        return OpenRequested?.Invoke(index, trigger) ?? Task.CompletedTask;
    }
}
