namespace FlowSynx.PluginCore;

/// <summary>
/// Represents a case-insensitive dictionary of parameters passed to a plugin during execution.
/// Implements <see cref="ICloneable"/> for shallow cloning.
/// </summary>
public class PluginParameters : Dictionary<string, object?>, ICloneable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginParameters"/> class
    /// with the contents of an existing dictionary. Keys are compared case-insensitively.
    /// Filters out reserved keys like `OperationName`.
    /// </summary>
    /// <param name="dictionary">The dictionary whose elements are copied to the new instance.</param>
    public PluginParameters(IDictionary<string, object?> dictionary)
        : base(StringComparer.OrdinalIgnoreCase)
    {
        // Copy only non-reserved keys
        foreach (var kvp in dictionary)
        {
            if (!string.Equals(kvp.Key, "OperationName", StringComparison.OrdinalIgnoreCase))
            {
                this[kvp.Key] = kvp.Value;
            }
        }
    }

    /// <summary>
    /// Initializes a new, empty instance of the <see cref="PluginParameters"/> class.
    /// Keys are compared case-insensitively.
    /// </summary>
    public PluginParameters()
        : base(StringComparer.OrdinalIgnoreCase)
    {
    }

    /// <summary>
    /// Creates a shallow copy of the current <see cref="PluginParameters"/> instance.
    /// Note: The dictionary values themselves are not deep-cloned.
    /// </summary>
    /// <returns>A shallow copy of the current instance.</returns>
    public object Clone()
    {
        var clone = new PluginParameters();
        foreach (var kvp in this)
        {
            clone[kvp.Key] = kvp.Value; // shallow copy of values
        }
        return clone;
    }
}