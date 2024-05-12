namespace Burkus.Mvvm.Maui.UnitTests.Attributes;

public class MapNavigationParameterAttributeTests
{
    [Fact]
    public void Constructor_WithParameters_SetsPropertyValues()
    {
        // Arrange

        // Act
        var attribute = new MapNavigationParameterAttribute(
            "PropertyName",
            "navigation_key");

        // Assert
        Assert.Equal("PropertyName", attribute.PropertyName);
        Assert.Equal("navigation_key", attribute.NavigationParameterKey);
    }
}