namespace FlowSynx.PluginCore.UnitTests;

public class PluginLoggerTests
{
    [Fact]
    public void Log_ShouldAddMessageToLogs()
    {
        // Arrange
        var logger = new InMemoryPluginLogger();
        var expectedLevel = PluginLoggerLevel.Warning;
        var expectedMessage = "This is a warning";

        // Act
        logger.Log(expectedLevel, expectedMessage);

        // Assert
        Assert.Single(logger.Logs);
        var log = logger.Logs[0];
        Assert.Equal(expectedLevel, log.Level);
        Assert.Equal(expectedMessage, log.Message);
    }

    [Theory]
    [InlineData(PluginLoggerLevel.Information, "Information log")]
    [InlineData(PluginLoggerLevel.Error, "Error occurred")]
    [InlineData(PluginLoggerLevel.Debug, "Debugging message")]
    public void Log_ShouldLogCorrectLevelAndMessage(PluginLoggerLevel level, string message)
    {
        // Arrange
        var logger = new InMemoryPluginLogger();

        // Act
        logger.Log(level, message);

        // Assert
        Assert.Contains(logger.Logs, l => l.Level == level && l.Message == message);
    }
}

public class InMemoryPluginLogger : IPluginLogger
{
    public List<(PluginLoggerLevel Level, string Message)> Logs { get; } = new();

    public void Log(PluginLoggerLevel level, string message)
    {
        Logs.Add((level, message));
    }
}