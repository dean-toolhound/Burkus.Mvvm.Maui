namespace Burkus.Mvvm.Maui;

/// <summary>
/// Used to indicate that a navigation parameter should automatically be mapped to a property
/// when the OnNavigatedTo event is firing.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class MapNavigationParameterAttribute : Attribute
{
    public string PropertyName { get; }

    public string NavigationParameterKey { get; }

    public MapNavigationParameterAttribute(
        string propertyName,
        string navigationParameterKey)
    {
        PropertyName = propertyName;
        NavigationParameterKey = navigationParameterKey;
    }
}