namespace FlowSynx.PluginCore;

/// <summary>
/// Describes a single specification definition for a plugin.
/// </summary>
[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public sealed class SpecificationMetadataAttribute : Attribute
{
    /// <summary>
    /// Gets the optional textual description associated with the object.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// True if the user must explicitly provide this value.
    /// </summary>
    public bool IsRequired { get; set; } = false;
}