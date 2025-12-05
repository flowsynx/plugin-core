namespace FlowSynx.PluginCore;

public interface IPluginOperation
{
    string Name { get; }
    string Description { get; }
}

public interface IPluginOperation<TParameters, TResult> : IPluginOperation
{
    Task<TResult?> ExecuteAsync(TParameters parameters, CancellationToken cancellationToken);
}