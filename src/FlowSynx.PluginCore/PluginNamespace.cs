namespace FlowSynx.PluginCore;

/// <summary>
/// Defines the logical categorization or role of a plugin within the system.
/// </summary>
public enum PluginNamespace
{
    /// <summary>
    /// Represents plugins that contain core business logic or decision-making rules.
    /// </summary>
    Logics,

    /// <summary>
    /// Represents plugins that connect to external systems, services, or data sources.
    /// </summary>
    Connectors,

    /// <summary>
    /// Represents plugins that modify, transform, or enrich data as it flows through the system.
    /// </summary>
    Transformers
}