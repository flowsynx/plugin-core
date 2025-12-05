namespace FlowSynx.PluginCore;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class OperationParameterMetadataAttribute : Attribute
{
    /// <summary>
    /// Gets the description of the parameter.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Gets a value indicating whether the parameter is required.
    /// </summary>
    public bool IsRequired { get; set; } = false;
}