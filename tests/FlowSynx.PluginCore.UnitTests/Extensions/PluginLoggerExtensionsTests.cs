using Moq;
using FlowSynx.PluginCore.Extensions;

namespace FlowSynx.PluginCore.UnitTests.Extensions;

public class PluginLoggerExtensionsTests
{
    [Fact]
    public void LogInfo_ShouldCallLogWithInformationLevel()
    {
        // Arrange
        var mockLogger = new Mock<IPluginLogger>();
        var message = "Info message";

        // Act
        mockLogger.Object.LogInfo(message);

        // Assert
        mockLogger.Verify(logger => logger.Log(PluginLoggerLevel.Information, message), Times.Once);
    }

    [Fact]
    public void LogError_ShouldCallLogWithErrorLevel()
    {
        // Arrange
        var mockLogger = new Mock<IPluginLogger>();
        var message = "Error message";

        // Act
        mockLogger.Object.LogError(message);

        // Assert
        mockLogger.Verify(logger => logger.Log(PluginLoggerLevel.Error, message), Times.Once);
    }

    [Fact]
    public void LogDebug_ShouldCallLogWithDebugLevel()
    {
        // Arrange
        var mockLogger = new Mock<IPluginLogger>();
        var message = "Debug message";

        // Act
        mockLogger.Object.LogDebug(message);

        // Assert
        mockLogger.Verify(logger => logger.Log(PluginLoggerLevel.Debug, message), Times.Once);
    }

    [Fact]
    public void LogWarning_ShouldCallLogWithWarningLevel()
    {
        // Arrange
        var mockLogger = new Mock<IPluginLogger>();
        var message = "Warning message";

        // Act
        mockLogger.Object.LogWarning(message);

        // Assert
        mockLogger.Verify(logger => logger.Log(PluginLoggerLevel.Warning, message), Times.Once);
    }
}