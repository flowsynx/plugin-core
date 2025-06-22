namespace FlowSynx.PluginCore;

/// <summary>
/// Specifies the severity level of a log message emitted by a plugin.
/// </summary>
public enum PluginLoggerLevel
{
    /// <summary>
    /// Debug-level messages used for development and diagnostic purposes.
    /// Typically only enabled in development environments.
    /// </summary>
    Debug = 0,

    /// <summary>
    /// Informational messages that highlight the progress or state of the plugin at a high level.
    /// </summary>
    Information,

    /// <summary>
    /// Warning messages that indicate a potential issue or important situation that does not prevent execution.
    /// </summary>
    Warning,

    /// <summary>
    /// Error messages that indicate a failure or problem that has impacted or halted execution.
    /// </summary>
    Error
}