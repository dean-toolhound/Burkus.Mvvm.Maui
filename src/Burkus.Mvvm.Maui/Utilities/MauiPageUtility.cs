namespace Burkus.Mvvm.Maui;

internal static class MauiPageUtility
{
    internal static Page GetTopPage()
    {
        var navigationStack = Application.Current.MainPage?.Navigation.NavigationStack;

        var modalStack = Application.Current.MainPage?.Navigation.ModalStack;

        if (modalStack != null && modalStack.Any())
        {
            // return a modal as the modals are on top
            return modalStack.Last();
        }

        if (navigationStack != null && navigationStack.Any())
        {

            return navigationStack.Last();
        }

        return null;
    }

    internal static object GetTopPageBindingContext()
    {
        return GetTopPage()?.BindingContext;
    }

    /// <summary>
    /// This method searches for and tries to find a TabbedPage that is visible to the user.
    /// </summary>
    /// <param name="page">Page to search for a TabbedPage in</param>
    /// <returns>A tabbeed page if found</returns>
    internal static TabbedPage FindVisibleTabbedPage(Page page)
    {
        return page switch
        {
            TabbedPage tabbedPage => tabbedPage,
            FlyoutPage { Detail: TabbedPage flyoutTabbedPage } => flyoutTabbedPage,
            FlyoutPage { Detail: var detail } => GetTabbedPageFromNavigationPage(detail),
            _ => GetTabbedPageFromNavigationPage(page)
        };
    }

    internal static TabbedPage GetTabbedPageFromNavigationPage(Page page)
    {
        if (page is NavigationPage { CurrentPage: TabbedPage tabbedPage })
        {
            return tabbedPage;
        }

        return null;
    }
}