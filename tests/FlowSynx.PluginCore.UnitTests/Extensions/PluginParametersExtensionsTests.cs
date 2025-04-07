using FlowSynx.PluginCore.Extensions;
using System.Reflection;

namespace FlowSynx.PluginCore.UnitTests.Extensions;

public class PluginParametersExtensionsTests
{
    private class TestClass
    {
        public string? Name { get; set; } = null;
        public int Age { get; set; }
        public List<string>? Tags { get; set; }
        public Dictionary<string, object>? MetaData { get; set; }
    }

    [Fact]
    public void ToObject_ReturnsNewInstance_WhenSourceIsNull()
    {
        // Arrange
        PluginParameters? source = null;

        // Act
        var result = source.ToObject<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Null(result.Name);
        Assert.Equal(0, result.Age);
        Assert.Null(result.Tags);
        Assert.Null(result.MetaData);
    }

    [Fact]
    public void ToObject_PopulatesProperties_WhenSourceIsNotNull()
    {
        // Arrange
        var source = new PluginParameters
        {
            { "Name", "Amin Ziagham" },
            { "Age", 30 },
            { "Tags", "[\"Tag1\", \"Tag2\"]" },
            { "MetaData", "{\"Key1\":\"Value1\",\"Key2\":2}" }
        };

        // Act
        var result = source.ToObject<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Amin Ziagham", result.Name);
        Assert.Equal(30, result.Age);
        Assert.NotNull(result.Tags);
        Assert.Contains("Tag1", result.Tags);
        Assert.Contains("Tag2", result.Tags);
        Assert.NotNull(result.MetaData);
        Assert.Contains("Key1", result.MetaData);
        Assert.Equal("Value1", result.MetaData["Key1"]);
        Assert.Equal(2, Convert.ToInt32(result.MetaData["Key2"]));
    }

    [Fact]
    public void SetPropertyValue_SetsValue_WhenPropertyIsValid()
    {
        // Arrange
        var instance = new TestClass();
        var property = typeof(TestClass).GetProperty("Name");

        // Act
        instance.SetPropertyValue(property, "Jane Doe");

        // Assert
        Assert.Equal("Jane Doe", instance.Name);
    }

    [Fact]
    public void SetPropertyValue_DoesNotSetValue_WhenPropertyIsNull()
    {
        // Arrange
        var instance = new TestClass();
        PropertyInfo? property = null;

        // Act
        instance.SetPropertyValue(property, "Some Value");

        // Assert
        // Property is null, so nothing should have changed.
        Assert.Null(instance.Name);
    }

    [Fact]
    public void SetPropertyValue_HandlesNullValueForNullableType()
    {
        // Arrange
        var instance = new TestClass();
        var property = typeof(TestClass).GetProperty("Age");

        // Act
        instance.SetPropertyValue(property, null);

        // Assert
        Assert.Equal(0, instance.Age); // Default value for int is 0.
    }

    [Fact]
    public void SetPropertyValue_HandlesNonNullableTypeWithNullValue()
    {
        // Arrange
        var instance = new TestClass();
        var property = typeof(TestClass).GetProperty("Age");

        // Act
        instance.SetPropertyValue(property, "null");

        // Assert
        Assert.Equal(0, instance.Age); // Default value for int is 0.
    }

    [Fact]
    public void SetPropertyValue_ThrowsException_WhenConversionFails()
    {
        // Arrange
        var instance = new TestClass();
        var property = typeof(TestClass).GetProperty("Age");

        // Act & Assert
        var exception = Record.Exception(() => instance.SetPropertyValue(property, "Invalid"));
        Assert.Null(exception); // No exception should be thrown, but value should not be set properly
        Assert.Equal(0, instance.Age); // Default value for int is 0
    }

    [Fact]
    public void IsJson_ReturnsTrue_WhenStringIsValidJson()
    {
        // Arrange
        string validJsonObject = "{\"Key\":\"Value\"}";
        string validJsonArray = "[1,2,3]";

        // Act
        bool resultObject = validJsonObject.IsJson();
        bool resultArray = validJsonArray.IsJson();

        // Assert
        Assert.True(resultObject);
        Assert.True(resultArray);
    }

    [Fact]
    public void IsJson_ReturnsFalse_WhenStringIsNotValidJson()
    {
        // Arrange
        string invalidJson = "This is not JSON";

        // Act
        bool result = invalidJson.IsJson();

        // Assert
        Assert.False(result);
    }
}