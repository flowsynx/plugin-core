namespace FlowSynx.PluginCore;

/// <summary>
/// Represents a case-insensitive dictionary of specifications or configuration values for a plugin.
/// Implements <see cref="ICloneable"/> for shallow cloning.
/// </summary>
public class PluginSpecifications : Dictionary<string, object?>, ICloneable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginSpecifications"/> class
    /// using the specified dictionary. Keys are compared case-insensitively.
    /// </summary>
    /// <param name="dictionary">The dictionary whose elements are copied to the new instance.</param>
    public PluginSpecifications(IDictionary<string, object?> dictionary)
        : base(dictionary, StringComparer.OrdinalIgnoreCase)
    {
    }

    /// <summary>
    /// Initializes a new, empty instance of the <see cref="PluginSpecifications"/> class.
    /// Keys are compared case-insensitively.
    /// </summary>
    public PluginSpecifications()
        : base(StringComparer.OrdinalIgnoreCase)
    {
    }

    /// <summary>
    /// Creates a shallow copy of the current <see cref="PluginSpecifications"/> instance.
    /// Note: The values in the dictionary are not deep-cloned.
    /// </summary>
    /// <returns>A shallow copy of the current instance.</returns>
    public object Clone()
    {
        var clone = (PluginSpecifications)MemberwiseClone();
        return clone;
    }
}