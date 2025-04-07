namespace FlowSynx.PluginCore.UnitTests;

public class PluginTests
{
    [Fact]
    public async Task Initialize_SetsInitializedFlag()
    {
        // Arrange
        var plugin = new FakePlugin();

        // Act
        await plugin.Initialize();

        // Assert
        Assert.True(plugin.Initialized);
    }

    [Fact]
    public void Metadata_IsNotNullAndHasCorrectValues()
    {
        // Arrange
        var plugin = new FakePlugin();

        // Assert
        Assert.NotNull(plugin.Metadata);
        Assert.Equal("FakePlugin", plugin.Metadata.Name);
        Assert.Equal(new PluginVersion(1, 0, 0), plugin.Metadata.Version);
        Assert.Equal("Test", plugin.Metadata.Author);
    }

    [Fact]
    public void Specifications_CanBeSetAndRetrieved()
    {
        // Arrange
        var plugin = new FakePlugin();
        var specs = new FakeSpecifications { ExampleSetting = "TestValue" };

        // Act
        plugin.Specifications = specs;

        // Assert
        Assert.Equal(specs, plugin.Specifications);
        Assert.Equal("TestValue", ((FakeSpecifications)plugin.Specifications!).ExampleSetting);
    }

    [Fact]
    public void SpecificationsType_IsCorrect()
    {
        // Arrange
        var plugin = new FakePlugin();

        // Assert
        Assert.Equal(typeof(FakeSpecifications), plugin.SpecificationsType);
    }

    [Fact]
    public async Task ExecuteAsync_ReturnsExpectedResult()
    {
        // Arrange
        var plugin = new FakePlugin();
        var parameters = new PluginParameters();

        // Act
        var result = await plugin.ExecuteAsync(parameters, CancellationToken.None);

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
            plugin.ExecuteAsync(new PluginParameters(), cts.Token));
    }
}


public class FakePlugin : IPlugin
{
    public PluginMetadata Metadata { get; private set; }
    public PluginSpecifications? Specifications { get; set; }
    public Type SpecificationsType => typeof(FakeSpecifications);

    public bool Initialized { get; private set; }

    public FakePlugin()
    {
        Metadata = new PluginMetadata
        {
            Id = Guid.NewGuid(),
            Name = "FakePlugin",
            Version =  new PluginVersion(1, 0, 0),
            Namespace = PluginNamespace.Connectors,
            Author = "Test"
        };
    }

    public Task Initialize()
    {
        Initialized = true;
        return Task.CompletedTask;
    }

    public Task<object?> ExecuteAsync(PluginParameters parameters, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return Task.FromCanceled<object?>(cancellationToken);

        return Task.FromResult<object?>("Executed");
    }
}

public class FakeSpecifications : PluginSpecifications
{
    public string? ExampleSetting { get; set; }
}
