namespace FlowSynx.PluginCore.Extensions;

/// <summary>
/// Provides extension methods for simplified logging using <see cref="IPluginLogger"/>.
/// </summary>
public static class PluginLoggerExtensions
{
    /// <summary>
    /// Logs an informational message using the <see cref="PluginLoggerLevel.Information"/> level.
    /// </summary>
    /// <param name="logger">The logger to write to.</param>
    /// <param name="message">The message to log.</param>
    public static void LogInfo(this IPluginLogger logger, string message)
    {
        logger.Log(PluginLoggerLevel.Information, message);
    }

    /// <summary>
    /// Logs an error message using the <see cref="PluginLoggerLevel.Error"/> level.
    /// </summary>
    /// <param name="logger">The logger to write to.</param>
    /// <param name="message">The message to log.</param>
    public static void LogError(this IPluginLogger logger, string message)
    {
        logger.Log(PluginLoggerLevel.Error, message);
    }

    /// <summary>
    /// Logs a debug message using the <see cref="PluginLoggerLevel.Debug"/> level.
    /// </summary>
    /// <param name="logger">The logger to write to.</param>
    /// <param name="message">The message to log.</param>
    public static void LogDebug(this IPluginLogger logger, string message)
    {
        logger.Log(PluginLoggerLevel.Debug, message);
    }

    /// <summary>
    /// Logs a warning message using the <see cref="PluginLoggerLevel.Warning"/> level.
    /// </summary>
    /// <param name="logger">The logger to write to.</param>
    /// <param name="message">The message to log.</param>
    public static void LogWarning(this IPluginLogger logger, string message)
    {
        logger.Log(PluginLoggerLevel.Warning, message);
    }
}