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
            Category = PluginCategory.Api,
            CompanyName = "Test",
        };

        // Act
        var type = metadata.Type;

        // Assert
        Assert.Equal("Test.Api.MyPlugin", type);
    }

    [Fact]
    public void Properties_AreAssignedCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var version = new PluginVersion(1, 2, 3);
        var category = PluginCategory.Api;

        var metadata = new PluginMetadata
        {
            Id = id,
            Name = "AnalyticsPlugin",
            Version = version,
            Description = "Performs analytics",
            Authors = new List<string> { "DevTeam" },
            ProjectUrl = "https://registry.flowsynx.io/AnalyticsPlugin/",
            Category = category,
            CompanyName= "Test"
        };

        // Assert
        Assert.Equal(id, metadata.Id);
        Assert.Equal("AnalyticsPlugin", metadata.Name);
        Assert.Equal(version, metadata.Version);
        Assert.Equal("Performs analytics", metadata.Description);
        Assert.Equal("DevTeam", metadata.Authors[0]);
        Assert.Equal("https://registry.flowsynx.io/AnalyticsPlugin/", metadata.ProjectUrl);
        Assert.Equal(category, metadata.Category);
        Assert.Equal("Test.Api.AnalyticsPlugin", metadata.Type);
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
            Category = PluginCategory.AI,
            CompanyName = "Test",
        };

        // Act
        var type = metadata.Type;

        // Assert
        Assert.Equal("Test.AI.Processor", type);
    }
}