namespace FlowSynx.PluginCore;

public interface IPlugin
{
    PluginMetadata Metadata { get; }
    IPluginSpecifications? Specifications { get; }
    IReadOnlyCollection<IPluginOperation> SupportedOperations { get; }

    Task InitializeAsync(
        IPluginLogger logger,
        IDictionary<string, object?>? specifications);

    Task<object?> ExecuteAsync(
        string? operationName,
        PluginParameters parameters,
        CancellationToken cancellationToken);
}