namespace FlowSynx.PluginCore;

/// <summary>
/// Defines a logging interface for plugins to emit messages with various log levels.
/// </summary>
public interface IPluginLogger
{
    /// <summary>
    /// Logs a message with the specified severity level.
    /// </summary>
    /// <param name="level">The severity level of the log message (e.g., Debug, Info, Warning, Error).</param>
    /// <param name="message">The log message to record.</param>
    void Log(PluginLoggerLevel level, string message);
}