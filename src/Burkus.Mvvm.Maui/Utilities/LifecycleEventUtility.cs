namespace Burkus.Mvvm.Maui;

internal static class LifecycleEventUtility
{
    #region INavigatingEvents

    internal static async Task TriggerOnNavigatingFrom(object bindingContext, NavigationParameters navigationParameters)
    {
        var navigatingFromViewModel = bindingContext as INavigatingEvents;

        if (navigatingFromViewModel != null)
        {
            await navigatingFromViewModel.OnNavigatingFrom(navigationParameters);
        }
    }

    #endregion INavigatingEvents

    #region INavigatedEvents

    internal static async Task TriggerOnNavigatedFrom(object bindingContext, NavigationParameters navigationParameters)
    {
        var navigatedFromViewModel = bindingContext as INavigatedEvents;

        if (navigatedFromViewModel != null)
        {
            await navigatedFromViewModel.OnNavigatedFrom(navigationParameters);
        }
    }

    internal static async Task TriggerOnNavigatedTo(object bindingContext, NavigationParameters navigationParameters)
    {
        var navigatedToViewModel = bindingContext as INavigatedEvents;

        if (navigatedToViewModel != null)
        {
            await navigatedToViewModel.OnNavigatedTo(navigationParameters);
        }
    }

    #endregion INavigatedEvents

    #region IPageVisibilityEvents

    internal static void SubscribeToPageVisibilityEvents(Page page)
    {
        page.Behaviors.Add(new PageVisibilityEventBehavior());
    }

    #endregion IPageVisibilityEvents
}