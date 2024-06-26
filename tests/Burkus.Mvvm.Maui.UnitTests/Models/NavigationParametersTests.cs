namespace Burkus.Mvvm.Maui.UnitTests.Models;

public class NavigationParametersTests
{
    public enum SampleEnum
    {
        Option1,
        Option2,
        Option3,
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void UseAnimatedNavigation_GetSet_ReturnsSetValue(
        bool setValue,
        bool expectedValue)
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters.UseAnimatedNavigation = setValue;

        // Act
        var result = navigationParameters.UseAnimatedNavigation;

        // Assert
        Assert.Equal(expectedValue, result);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void UseModalNavigation_GetSet_ReturnsSetValue(
        bool setValue,
        bool expectedValue)
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters.UseModalNavigation = setValue;

        // Act
        var result = navigationParameters.UseModalNavigation;

        // Assert
        Assert.Equal(expectedValue, result);
    }

    [Theory]
    [InlineData("AlphaPage", "AlphaPage")]
    [InlineData("BetaPage", "BetaPage")]
    public void SelectTab_GetSet_ReturnsSetValue(
        string setValue,
        string expectedValue)
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters.SelectTab = setValue;

        // Act
        var result = navigationParameters.SelectTab;

        // Assert
        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void GetValue_ExistingBooleanParameter_ReturnsValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["MyBoolParam"] = true;

        // Act
        var result = navigationParameters.GetValue<bool>("MyBoolParam");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetValue_NonExistentParameter_ReturnsDefaultValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();

        // Act
        var result = navigationParameters.GetValue<bool>("NonExistentParam");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetValue_InvalidConversion_ThrowsArgumentException()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["InvalidParam"] = "InvalidValue";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => navigationParameters.GetValue<int>("InvalidParam"));
    }

    [Fact]
    public void GetValue_EnumParameter_ReturnsEnumValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["EnumParam"] = SampleEnum.Option2;

        // Act
        var result = navigationParameters.GetValue<SampleEnum>("EnumParam");

        // Assert
        Assert.Equal(SampleEnum.Option2, result);
    }

    [Fact]
    public void GetValue_EnumParameterInvalidValue_ThrowsArgumentException()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["EnumParam"] = "InvalidValue";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => navigationParameters.GetValue<SampleEnum>("EnumParam"));
    }

    [Fact]
    public void GetValue_ObjectParameter_ReturnsObject()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        var testObject = new object();

        navigationParameters["ObjectParam"] = testObject;

        // Act
        var result = navigationParameters.GetValue<object>("ObjectParam");

        // Assert
        Assert.Same(testObject, result);
    }

    [Fact]
    public void GetValue_ObjectParameter_NullValue_ReturnsNull()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["ObjectParam"] = null;

        // Act
        var result = navigationParameters.GetValue<object>("ObjectParam");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetValue_NullableValueParameters_ReturnsNullValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["NullableCharParam"] = null;

        // Act
        var result = navigationParameters.GetValue<char?>("NullableCharParam");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetValue_NullableValueParameters_ReturnsCharValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["NullableCharParam"] = 'C';

        // Act
        var result = navigationParameters.GetValue<char?>("NullableCharParam");

        // Assert
        Assert.Equal('C', result);
    }

    // -----------------------------

    [Fact]
    public void TryGetValue_ExistingBooleanParameter_ReturnsValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["MyBoolParam"] = true;

        // Act
        var result = navigationParameters.TryGetValue<bool>("MyBoolParam", out var returnValue);

        // Assert
        Assert.True(result);
        Assert.True(returnValue);
    }

    [Fact]
    public void TryGetValue_NonExistentParameter_ReturnsDefaultValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();

        // Act
        var result = navigationParameters.TryGetValue<bool>("NonExistentParam", out var returnValue);

        // Assert
        Assert.False(result);
        Assert.False(returnValue);
    }

    [Fact]
    public void TryGetValue_InvalidConversion_ThrowsArgumentException()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["InvalidParam"] = "InvalidValue";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => navigationParameters.TryGetValue<int>("InvalidParam", out var returnValue));
    }

    [Fact]
    public void TryGetValue_EnumParameter_ReturnsEnumValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["EnumParam"] = SampleEnum.Option2;

        // Act
        var result = navigationParameters.TryGetValue<SampleEnum>("EnumParam", out var returnValue);

        // Assert
        Assert.True(result);
        Assert.Equal(SampleEnum.Option2, returnValue);
    }

    [Fact]
    public void TryGetValue_EnumParameterInvalidValue_ThrowsArgumentException()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["EnumParam"] = "InvalidValue";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => navigationParameters.TryGetValue<SampleEnum>("EnumParam", out var returnValue));
    }

    [Fact]
    public void TryGetValue_ObjectParameter_ReturnsObject()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        var testObject = new object();

        navigationParameters["ObjectParam"] = testObject;

        // Act
        var result = navigationParameters.TryGetValue<object>("ObjectParam", out var returnValue);

        // Assert
        Assert.True(result);
        Assert.Equal(testObject, returnValue);
    }

    [Fact]
    public void TryGetValue_ObjectParameter_NullValue_ReturnsNull()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["ObjectParam"] = null;

        // Act
        var result = navigationParameters.TryGetValue<object>("ObjectParam", out var returnValue);

        // Assert
        Assert.True(result);
        Assert.Null(returnValue);

    }

    [Fact]
    public void TryGetValue_NullableValueParameters_ReturnsNullValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["NullableCharParam"] = null;

        // Act
        var result = navigationParameters.TryGetValue<char?>("NullableCharParam", out var returnValue);

        // Assert
        Assert.True(result);
        Assert.Null(returnValue);
    }

    [Fact]
    public void TryGetValue_NullableValueParameters_ReturnsCharValue()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();
        navigationParameters["NullableCharParam"] = 'C';

        // Act
        var result = navigationParameters.TryGetValue<char?>("NullableCharParam", out var returnValue);

        // Assert
        Assert.True(result);
        Assert.Equal('C', returnValue);
    }

    // -----------------------------

    [Fact]
    public void MergeNavigationParameters_WhenCalledWithEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        var navParams1 = new NavigationParameters();
        var navParams2 = new NavigationParameters();

        // Act
        var result = navParams1.MergeNavigationParameters(navParams2);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void MergeNavigationParameters_WhenCalledWithNonEmptyDictionaries_ReturnsMergedDictionary()
    {
        // Arrange
        var navParams1 = new NavigationParameters { { "key1", "value1" } };
        var navParams2 = new NavigationParameters { { "key2", "value2" }, { "key3", "value3" } };
        var navParams3 = new NavigationParameters { { "key2", "value4" }, { "key4", "value5" } };

        // Act
        var result = navParams1.MergeNavigationParameters(navParams2, navParams3);

        // Assert
        Assert.Equal(4, result.Count);
        Assert.Equal("value1", result["key1"]);
        Assert.Equal("value2", result["key2"]);
        Assert.Equal("value3", result["key3"]);
        Assert.Equal("value5", result["key4"]);
    }

    [Fact]
    public void ToQueryString_ForEmptyParameters_ReturnsEmptyString()
    {
        // Arrange
        var navigationParameters = new NavigationParameters();

        // Act
        var result = navigationParameters.ToQueryString();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ToQueryString_ForMultipleParameters_CreatesValidQueryString()
    {
        // Arrange
        var navigationParameters = new NavigationParameters()
        {
            { "param1", "value1" },
            { "param2", 123 },
            { "param3", true },
        };

        // Act
        var result = navigationParameters.ToQueryString();

        // Assert
        Assert.Equal("?param1=value1&param2=123&param3=True", result);
    }
}