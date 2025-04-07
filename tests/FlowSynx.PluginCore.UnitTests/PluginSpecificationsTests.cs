namespace FlowSynx.PluginCore.UnitTests;

public class PluginSpecificationsTests
{
    [Fact]
    public void Constructor_ShouldInitializeEmptyDictionary()
    {
        // Arrange & Act
        var specs = new PluginSpecifications();

        // Assert
        Assert.Empty(specs);
    }

    [Fact]
    public void Constructor_WithDictionary_ShouldCopyValues()
    {
        // Arrange
        var input = new Dictionary<string, object?>
            {
                { "Key1", "Value1" },
                { "Key2", 42 }
            };

        // Act
        var specs = new PluginSpecifications(input);

        // Assert
        Assert.Equal(2, specs.Count);
        Assert.Equal("Value1", specs["Key1"]);
        Assert.Equal(42, specs["Key2"]);
    }

    [Fact]
    public void Dictionary_ShouldBeCaseInsensitive()
    {
        // Arrange
        var specs = new PluginSpecifications
        {
            ["TestKey"] = "value"
        };

        // Act & Assert
        Assert.True(specs.ContainsKey("testkey"));
        Assert.True(specs.ContainsKey("TESTKEY"));
        Assert.Equal("value", specs["testKEY"]);
    }

    [Fact]
    public void Clone_ShouldCreateShallowCopy()
    {
        // Arrange
        var specs = new PluginSpecifications
        {
            ["Key"] = new List<string> { "A", "B" }
        };

        // Act
        var clone = (PluginSpecifications)specs.Clone();

        // Assert
        Assert.NotSame(specs, clone); // Different reference
        Assert.Equal(specs["Key"], clone["Key"]); // Same value reference (shallow copy)
        Assert.Same(specs["Key"], clone["Key"]);
    }
}