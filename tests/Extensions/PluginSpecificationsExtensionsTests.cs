using FlowSynx.PluginCore.Extensions;

namespace FlowSynx.PluginCore.UnitTests.Extensions;

public class PluginSpecificationsExtensionsTests
{
    public class TestClass
    {
        public string? Property1 { get; set; }
        public int Property2 { get; set; }
    }

    [Fact]
    public void ToObject_WithNullSource_ReturnsNewInstance()
    {
        // Arrange
        PluginSpecifications? source = null;

        // Act
        var result = source.ToObject<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<TestClass>(result);
        Assert.Null(result.Property1);
        Assert.Equal(0, result.Property2);
    }

    [Fact]
    public void ToObject_WithValidSource_ReturnsMappedObject()
    {
        // Arrange
        var source = new PluginSpecifications
        {
            { "Property1", "Test Value" },
            { "Property2", 42 }
        };

        // Act
        var result = source.ToObject<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Value", result.Property1);
        Assert.Equal(42, result.Property2);
    }

    [Fact]
    public void ToObject_WithMissingPropertyInSource_LeavesPropertyUnchanged()
    {
        // Arrange
        var source = new PluginSpecifications
        {
            { "Property1", "Test Value" }
        };

        // Act
        var result = source.ToObject<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Value", result.Property1);
        Assert.Equal(0, result.Property2); // Property2 is not set
    }

    [Fact]
    public void ToObject_WithPropertyNamesCaseMismatch_SetsValueCorrectly()
    {
        // Arrange
        var source = new PluginSpecifications
        {
            { "property1", "Test Value" },
            { "property2", 42 }
        };

        // Act
        var result = source.ToObject<TestClass>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Value", result.Property1);
        Assert.Equal(42, result.Property2);
    }

    [Fact]
    public void ToObject_WithNonMatchingProperty_DoNotThrowException()
    {
        // Arrange
        var source = new PluginSpecifications
        {
            { "NonMatchingProperty", "Some Value" }
        };

        // Act & Assert
        var result = source.ToObject<TestClass>();

        // The test ensures that no exception is thrown and the object is created with default values
        Assert.NotNull(result);
        Assert.Null(result.Property1);
        Assert.Equal(0, result.Property2);
    }
}