namespace FlowSynx.PluginCore;

public abstract class PluginSpecifications : IPluginSpecifications
{
    /// <summary>
    /// Validate the specification values
    /// </summary>
    public abstract void Validate();

    /// <summary>
    /// Load values from a dictionary dynamically
    /// </summary>
    /// <param name="dict">Dictionary of parameter values</param>
    public virtual void FromDictionary(IDictionary<string, object?> dict)
    {
        // Default implementation using reflection
        var properties = this.GetType().GetProperties()
            .Where(p => p.CanWrite)
            .ToDictionary(p => p.Name, p => p);

        foreach (var kvp in dict)
        {
            if (properties.TryGetValue(kvp.Key, out var prop))
            {
                var value = kvp.Value;
                if (value == null)
                    continue;

                var targetType = prop.PropertyType;
                var valueType = value.GetType();

                if (targetType.IsAssignableFrom(valueType))
                {
                    prop.SetValue(this, value);
                    continue;
                }

                try
                {
                    object converted;
                    if (targetType == typeof(DateTime) && value is string s)
                    {
                        // Preserve Kind from roundtrip (ISO 8601) strings.
                        converted = DateTime.Parse(s, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.RoundtripKind);
                    }
                    else if (targetType == typeof(bool) && value is string sb)
                    {
                        converted = bool.Parse(sb);
                    }
                    else if (targetType == typeof(int) && value is string si)
                    {
                        converted = int.Parse(si, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else if (targetType == typeof(double) && value is string sd)
                    {
                        converted = double.Parse(sd, System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        converted = Convert.ChangeType(value, targetType, System.Globalization.CultureInfo.InvariantCulture);
                    }

                    prop.SetValue(this, converted);
                }
                catch
                {
                    // Rethrow to preserve original behavior of failing on invalid conversion
                    throw;
                }
            }
        }
    }
}