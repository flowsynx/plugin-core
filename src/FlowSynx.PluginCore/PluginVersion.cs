namespace FlowSynx.PluginCore;

/// <summary>
/// Represents a semantic version for a plugin, consisting of major, minor, and patch components.
/// Provides parsing, comparison, and string representation.
/// </summary>
public class PluginVersion
{
    /// <summary>
    /// Gets the major version component.
    /// </summary>
    public int Major { get; }

    /// <summary>
    /// Gets the minor version component.
    /// </summary>
    public int Minor { get; }

    /// <summary>
    /// Gets the patch version component.
    /// </summary>
    public int Patch { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PluginVersion"/> class with the specified version numbers.
    /// </summary>
    /// <param name="major">The major version number.</param>
    /// <param name="minor">The minor version number.</param>
    /// <param name="patch">The patch version number.</param>
    public PluginVersion(int major, int minor, int patch)
    {
        Major = major;
        Minor = minor;
        Patch = patch;
    }

    /// <summary>
    /// Parses a version string in the format "Major.Minor.Patch" into a <see cref="PluginVersion"/> object.
    /// </summary>
    /// <param name="version">The version string (e.g., "1.0.0").</param>
    /// <returns>A <see cref="PluginVersion"/> object representing the parsed version.</returns>
    /// <exception cref="FormatException">Thrown when the version string is not in the expected format.</exception>
    public static PluginVersion Parse(string version)
    {
        var parts = version.Split('.');

        if (parts.Length != 3)
            throw new FormatException("Invalid version format. Expected format: Major.Minor.Patch");

        return new PluginVersion(
            int.Parse(parts[0]),
            int.Parse(parts[1]),
            int.Parse(parts[2])
        );
    }

    /// <summary>
    /// Compares this version to another <see cref="PluginVersion"/> instance.
    /// </summary>
    /// <param name="other">The other version to compare with.</param>
    /// <returns>
    /// A value less than 0 if this version is less than <paramref name="other"/>,
    /// 0 if they are equal, or greater than 0 if this version is greater than <paramref name="other"/>.
    /// </returns>
    public int CompareTo(PluginVersion other)
    {
        if (other is null) return 1;

        if (Major != other.Major)
            return Major.CompareTo(other.Major);

        if (Minor != other.Minor)
            return Minor.CompareTo(other.Minor);

        return Patch.CompareTo(other.Patch);
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current version.
    /// </summary>
    /// <param name="obj">The object to compare with.</param>
    /// <returns><c>true</c> if the versions are equal; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        return obj is PluginVersion version && CompareTo(version) == 0;
    }

    /// <summary>
    /// Returns a hash code for the current version.
    /// </summary>
    /// <returns>A hash code.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Major, Minor, Patch);
    }

    /// <summary>
    /// Returns the version as a string in the format "Major.Minor.Patch".
    /// </summary>
    /// <returns>A string representation of the version.</returns>
    public override string ToString()
    {
        return $"{Major}.{Minor}.{Patch}";
    }

    /// <summary>
    /// Determines whether one version is less than another.
    /// </summary>
    public static bool operator <(PluginVersion v1, PluginVersion v2) => v1.CompareTo(v2) < 0;

    /// <summary>
    /// Determines whether one version is greater than another.
    /// </summary>
    public static bool operator >(PluginVersion v1, PluginVersion v2) => v1.CompareTo(v2) > 0;

    /// <summary>
    /// Determines whether one version is less than or equal to another.
    /// </summary>
    public static bool operator <=(PluginVersion v1, PluginVersion v2) => v1.CompareTo(v2) <= 0;

    /// <summary>
    /// Determines whether one version is greater than or equal to another.
    /// </summary>
    public static bool operator >=(PluginVersion v1, PluginVersion v2) => v1.CompareTo(v2) >= 0;

    /// <summary>
    /// Determines whether two versions are equal.
    /// </summary>
    public static bool operator ==(PluginVersion v1, PluginVersion v2) => v1?.CompareTo(v2) == 0;

    /// <summary>
    /// Determines whether two versions are not equal.
    /// </summary>
    public static bool operator !=(PluginVersion v1, PluginVersion v2) => !(v1 == v2);
}