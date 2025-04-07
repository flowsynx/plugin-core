namespace FlowSynx.PluginCore;

public interface IPlugin
{
    PluginMetadata Metadata { get; }
    PluginSpecifications? Specifications { get; set; }
    Type SpecificationsType { get; }
    Task Initialize(IPluginLogger logger);
    Task<object?> ExecuteAsync(PluginParameters parameters, CancellationToken cancellationToken);
}