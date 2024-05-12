namespace Burkus.Mvvm.Maui;

internal static class LifecycleEventUtility
{
    internal static async Task TriggerOnNavigatingFrom(object bindingContext, NavigationParameters navigationParameters)
    {
        var navigatingFromViewModel = bindingContext as INavigatingEvents;

        if (navigatingFromViewModel != null)
        {
            await navigatingFromViewModel.OnNavigatingFrom(navigationParameters);
        }
    }

    internal static async Task TriggerOnNavigatedFrom(object bindingContext, NavigationParameters navigationParameters)
    {
        var navigatedFromViewModel = bindingContext as INavigatedEvents;

        if (navigatedFromViewModel != null)
        {
            await navigatedFromViewModel.OnNavigatedFrom(navigationParameters);
        }
    }

    #region IPageVisibilityEvents

    internal static async Task TriggerOnNavigatedTo(object bindingContext, NavigationParameters navigationParameters)
    {
        var navigatedToViewModel = bindingContext as INavigatedEvents;

        if (navigatedToViewModel != null)
        {
            await navigatedToViewModel.OnNavigatedTo(navigationParameters);
        }
    }

    internal static void SubscribeToPageVisibilityEvents(Page page)
    {
        // todo: unsubscribe from these events - use https://stackoverflow.com/a/70869441/3991315 ?
        page.Appearing += Page_Appearing;
        page.Disappearing += Page_Disappearing;
    }

    internal static void Page_Appearing(object? sender, EventArgs e)
    {
        var onAppearingViewModel = GetPageVisibilityEventsViewModel(sender);

        if (onAppearingViewModel != null)
        {
            onAppearingViewModel.OnAppearing();
        }
    }

    internal static void Page_Disappearing(object? sender, EventArgs e)
    {
        var onDisappearingViewModel = GetPageVisibilityEventsViewModel(sender);

        if (onDisappearingViewModel != null)
        {
            onDisappearingViewModel.OnDisappearing();
        }
    }

    internal static IPageVisibilityEvents GetPageVisibilityEventsViewModel(object? sender)
    {
        var page = sender as Page;
        return page?.BindingContext as IPageVisibilityEvents;
    }

    #endregion IPageVisibilityEvents
}