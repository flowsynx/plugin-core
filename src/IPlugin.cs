namespace FlowSynx.PluginCore;

/// <summary>
/// Represents a plugin with metadata, specifications, and execution capabilities.
/// </summary>
public interface IPlugin
{
    /// <summary>
    /// Gets the metadata describing the plugin, including its name, version, author, and other identifying information.
    /// </summary>
    PluginMetadata Metadata { get; }

    /// <summary>
    /// Gets or sets the plugin-specific configuration or specifications used during execution.
    /// </summary>
    PluginSpecifications? Specifications { get; set; }

    /// <summary>
    /// Gets the <see cref="Type"/> of the <see cref="Specifications"/> object.
    /// Useful for deserialization or dynamic creation of the specification instance.
    /// </summary>
    Type SpecificationsType { get; }

    /// <summary>
    /// Gets the set of supported operation names.
    /// </summary>
    /// <remarks>
    /// Operation names are case-insensitive and typically represent actions such as "create", "read", "update", or "delete".
    /// </remarks>
    IReadOnlyCollection<string> SupportedOperations { get; }

    /// <summary>
    /// Initializes the plugin with the provided logger. This method is called once before execution.
    /// </summary>
    /// <param name="logger">The logger to be used by the plugin for diagnostics and tracing.</param>
    /// <returns>A task representing the asynchronous initialization operation.</returns>
    Task Initialize(IPluginLogger logger);

    /// <summary>
    /// Executes the plugin asynchronously with the provided parameters.
    /// </summary>
    /// <param name="parameters">The input parameters required for plugin execution.</param>
    /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing an optional result object.</returns>
    Task<object?> ExecuteAsync(PluginParameters parameters, CancellationToken cancellationToken);
}