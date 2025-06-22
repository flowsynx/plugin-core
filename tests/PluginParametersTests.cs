namespace FlowSynx.PluginCore.UnitTests;

public class PluginParametersTests
{
    [Fact]
    public void Constructor_Default_CreatesEmptyDictionary()
    {
        // Arrange & Act
        var parameters = new PluginParameters();

        // Assert
        Assert.Empty(parameters);
    }

    [Fact]
    public void Constructor_FromDictionary_CopiesAllValues()
    {
        // Arrange
        var source = new Dictionary<string, object?>
        {
            { "Key1", 123 },
            { "Key2", "value" }
        };

        // Act
        var parameters = new PluginParameters(source);

        // Assert
        Assert.Equal(2, parameters.Count);
        Assert.Equal(123, parameters["Key1"]);
        Assert.Equal("value", parameters["Key2"]);
    }

    [Fact]
    public void Dictionary_IsCaseInsensitive()
    {
        // Arrange
        var parameters = new PluginParameters
        {
            { "TestKey", "value" }
        };

        // Act & Assert
        Assert.True(parameters.ContainsKey("testkey"));
        Assert.Equal("value", parameters["TESTKEY"]);
    }

    [Fact]
    public void Clone_CreatesShallowCopy()
    {
        // Arrange
        var parameters = new PluginParameters
        {
            { "A", new List<int> { 1, 2, 3 } },
            { "B", "string" }
        };

        // Act
        var clone = (PluginParameters)parameters.Clone();

        // Assert
        Assert.NotSame(parameters, clone);
        Assert.Equal(parameters.Count, clone.Count);
        Assert.Equal(parameters["B"], clone["B"]);

        // Reference equality for values (shallow copy)
        Assert.Same(parameters["A"], clone["A"]);
    }
}