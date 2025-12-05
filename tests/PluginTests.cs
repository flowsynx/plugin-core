using Moq;

namespace FlowSynx.PluginCore.UnitTests;

public class PluginTests
{
    [Fact]
    public async Task Initialize_SetsInitializedFlag()
    {
        // Arrange
        var plugin = new FakePlugin();
        var loggerMock = new Mock<IPluginLogger>();

        // Act
        await plugin.InitializeAsync(loggerMock.Object, null);

        // Assert
        loggerMock.Verify(l => l.Log(PluginLoggerLevel.Information, "Initializing SamplePlugin"), Times.Once);
    }

    [Fact]
    public void Metadata_IsNotNullAndHasCorrectValues()
    {
        // Arrange
        var plugin = new FakePlugin();

        // Assert
        Assert.NotNull(plugin.Metadata);
        Assert.Equal("FakePlugin", plugin.Metadata.Name);
        Assert.Equal(new Version(1, 0, 0), plugin.Metadata.Version);
        Assert.Equal("Test", plugin.Metadata.Authors[0]);
    }

    [Fact]
    public async Task ExecuteAsync_ReturnsExpectedResult()
    {
        // Arrange
        var plugin = new FakePlugin();
        var parameters = new PluginParameters();

        // Act
        var result = await plugin.ExecuteAsync("TestOperation", parameters, CancellationToken.None);

        // Assert
        Assert.Equal("Executed", result);
    }

    [Fact]
    public async Task ExecuteAsync_CancellationRequested_ThrowsTaskCanceledException()
    {
        // Arrange
        var plugin = new FakePlugin();
        var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert
        await Assert.ThrowsAsync<TaskCanceledException>(() =>
            plugin.ExecuteAsync("TestOperation", new PluginParameters(), cts.Token));
    }
}

public class FakePlugin : IPlugin
{
    public PluginMetadata Metadata { get; private set; }
    public IReadOnlyCollection<IPluginOperation> SupportedOperations => new List<IPluginOperation>();
    public IPluginSpecifications Specifications => new FakeSpecifications();

    public FakePlugin()
    {
        Metadata = new PluginMetadata
        {
            Id = Guid.NewGuid(),
            Name = "FakePlugin",
            Version =  new Version(1, 0, 0),
            Category = PluginCategory.Api,
            Authors = new List<string> { "Test" },
            CompanyName = "Test",
            MinimumFlowSynxVersion = new Version(1, 0, 0)
        };
    }

    public Task InitializeAsync(IPluginLogger logger, IDictionary<string, object?>? specifications)
    {
        logger.Log(PluginLoggerLevel.Information, "Initializing SamplePlugin");
        return Task.CompletedTask;
    }

    public Task<object?> ExecuteAsync(
        string operationName, 
        PluginParameters parameters, 
        CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return Task.FromCanceled<object?>(cancellationToken);

        return Task.FromResult<object?>("Executed");
    }
}

public class FakeSpecifications : PluginSpecifications
{
    public string ExampleSetting { get; set; } = string.Empty;

    public override void Validate()
    {
        if (string.IsNullOrWhiteSpace(ExampleSetting)) throw new Exception("ExampleSetting is required.");
    }
}