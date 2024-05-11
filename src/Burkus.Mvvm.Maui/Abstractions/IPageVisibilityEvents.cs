namespace Burkus.Mvvm.Maui;

public interface IPageVisibilityEvents
{
    /// <summary>
    /// Is triggered by the <see cref="Page.OnAppearing"/> event.
    /// </summary>
    /// <returns>A completed task</returns>
    Task OnAppearing();

    /// <summary>
    /// Is triggered by the <see cref="Page.OnDisappearing"/> event.
    /// </summary>
    /// <returns>A completed task</returns>
    Task OnDisappearing();
}
