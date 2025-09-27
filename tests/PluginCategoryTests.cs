namespace FlowSynx.PluginCore.UnitTests;

public class PluginCategoryTests
{
    [Fact]
    public void PluginCategory_ShouldContainAllExpectedValues()
    {
        var expected = new[]
        {
            "AI", "Api", "Authentication", "BusinessIntelligence", "Blockchain", "Cloud",
            "Communication", "Data", "Database", "DevOps", "Finance", "ML", "Monitoring",
            "Logging", "Networking", "ProjectWorkflow", "ResourcePlanning", "Security",
            "Storage", "Compression", "Testing", "Web", "Execution", "IoT", "Media"
        };

        var actual = Enum.GetNames(typeof(PluginCategory));
        Assert.Equal(expected.Length, actual.Length);
        foreach (var name in expected)
        {
            Assert.Contains(name, actual);
        }
    }

    [Theory]
    [InlineData("AI", PluginCategory.AI)]
    [InlineData("Api", PluginCategory.Api)]
    [InlineData("Authentication", PluginCategory.Authentication)]
    [InlineData("BusinessIntelligence", PluginCategory.BusinessIntelligence)]
    [InlineData("Blockchain", PluginCategory.Blockchain)]
    [InlineData("Cloud", PluginCategory.Cloud)]
    [InlineData("Communication", PluginCategory.Communication)]
    [InlineData("Data", PluginCategory.Data)]
    [InlineData("Database", PluginCategory.Database)]
    [InlineData("DevOps", PluginCategory.DevOps)]
    [InlineData("Finance", PluginCategory.Finance)]
    [InlineData("ML", PluginCategory.ML)]
    [InlineData("Monitoring", PluginCategory.Monitoring)]
    [InlineData("Logging", PluginCategory.Logging)]
    [InlineData("Networking", PluginCategory.Networking)]
    [InlineData("ProjectWorkflow", PluginCategory.ProjectWorkflow)]
    [InlineData("ResourcePlanning", PluginCategory.ResourcePlanning)]
    [InlineData("Security", PluginCategory.Security)]
    [InlineData("Storage", PluginCategory.Storage)]
    [InlineData("Compression", PluginCategory.Compression)]
    [InlineData("Testing", PluginCategory.Testing)]
    [InlineData("Web", PluginCategory.Web)]
    [InlineData("Execution", PluginCategory.Execution)]
    [InlineData("IoT", PluginCategory.IoT)]
    [InlineData("Media", PluginCategory.Media)]
    public void PluginCategory_ShouldParseFromString(string name, PluginCategory expected)
    {
        var parsed = Enum.Parse<PluginCategory>(name);
        Assert.Equal(expected, parsed);
    }

    [Fact]
    public void PluginCategory_InvalidValue_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => Enum.Parse<PluginCategory>("NonExistentCategory"));
    }
}
