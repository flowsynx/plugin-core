namespace FlowSynx.PluginCore;

public interface IPluginSpecifications
{
    /// <summary>
    /// Validate the specification values.
    /// </summary>
    void Validate();

    /// <summary>
    /// Load values from a dictionary dynamically.
    /// </summary>
    void FromDictionary(IDictionary<string, object?> dict);
}