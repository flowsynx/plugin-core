namespace FlowSynx.PluginCore.UnitTests;

public class PluginMetadataTests
{
    [Fact]
    public void TypeProperty_ReturnsCorrectFormat()
    {
        // Arrange
        var metadata = new PluginMetadata
        {
            Id = Guid.NewGuid(),
            Name = "MyPlugin",
            Version = new PluginVersion(1, 0, 0),
            Namespace = PluginNamespace.Connectors
        };

        // Act
        var type = metadata.Type;

        // Assert
        Assert.Equal("FlowSynx.Connectors.MyPlugin", type);
    }

    [Fact]
    public void Properties_AreAssignedCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var version = new PluginVersion(1, 2, 3);
        var ns = PluginNamespace.Connectors;

        var metadata = new PluginMetadata
        {
            Id = id,
            Name = "AnalyticsPlugin",
            Version = version,
            Description = "Performs analytics",
            Author = "DevTeam",
            Url = "https://registry.flowsynx.io/AnalyticsPlugin/",
            Namespace = ns
        };

        // Assert
        Assert.Equal(id, metadata.Id);
        Assert.Equal("AnalyticsPlugin", metadata.Name);
        Assert.Equal(version, metadata.Version);
        Assert.Equal("Performs analytics", metadata.Description);
        Assert.Equal("DevTeam", metadata.Author);
        Assert.Equal("https://registry.flowsynx.io/AnalyticsPlugin/", metadata.Url);
        Assert.Equal(ns, metadata.Namespace);
        Assert.Equal("FlowSynx.Connectors.AnalyticsPlugin", metadata.Type);
    }

    [Fact]
    public void TypeProperty_HandlesDifferentNamespacesAndNames()
    {
        // Arrange
        var metadata = new PluginMetadata
        {
            Id = Guid.NewGuid(),
            Name = "Processor",
            Version = new PluginVersion(0, 1, 1),
            Namespace = PluginNamespace.Transformers
        };

        // Act
        var type = metadata.Type;

        // Assert
        Assert.Equal("FlowSynx.Transformers.Processor", type);
    }
}