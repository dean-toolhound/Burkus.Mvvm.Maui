using CommunityToolkit.Mvvm.ComponentModel;

namespace DemoApp.ViewModels;

public partial class PageVisibilityEventViewModel : BaseViewModel, IPageVisibilityEvents
{
    #region Properties

    [ObservableProperty]
    private bool showLabel;

    #endregion Properties

    #region Constructors

    public PageVisibilityEventViewModel(
        INavigationService navigationService)
        : base(navigationService)
    {
    }

    #endregion Constructors

    #region Lifecycle events

    public void OnAppearing()
    {
        ShowLabel = true;
    }

    public void OnDisappearing()
    {
        ShowLabel = false;
    }

    #endregion Lifecycle events
}
