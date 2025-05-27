using System.Text.RegularExpressions;

namespace FlowSynx.PluginCore;

/// <summary>
/// Represents metadata information about a plugin including its identity, version,
/// company, descriptive details, and repository information.
/// Constructs a fully-qualified plugin type identifier based on the company name, namespace, and plugin name.
/// </summary>
public class PluginMetadata
{
    private string _companyName = default!;
    private string _name = default!;

    /// <summary>
    /// A regular expression to validate identifiers.
    /// Identifiers must start with a letter and contain only letters and digits.
    /// </summary>
    private static readonly Regex ValidIdentifierRegex = new(@"^[A-Za-z][A-Za-z0-9]*$", RegexOptions.Compiled);

    /// <summary>
    /// Gets or sets the unique identifier of the plugin.
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the plugin.
    /// The name must start with a letter and contain only letters and digits.
    /// </summary>
    public required string Name
    {
        get => _name;
        set => _name = ValidateIdentifier(value, nameof(Name));
    }

    /// <summary>
    /// Gets or sets the version of the plugin.
    /// </summary>
    public required PluginVersion Version { get; set; }

    /// <summary>
    /// Gets or sets the name of the company that created the plugin.
    /// The name must start with a letter and contain only letters and digits.
    /// </summary>
    public required string CompanyName
    {
        get => _companyName;
        set => _companyName = ValidateIdentifier(value, nameof(CompanyName));
    }

    /// <summary>
    /// Gets or sets an optional description of the plugin.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the list of authors or maintainers of the plugin.
    /// </summary>
    public List<string> Authors { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the license name under which the plugin is distributed.
    /// </summary>
    public string? License { get; set; }

    /// <summary>
    /// Gets or sets the URL to the license text or license information.
    /// </summary>
    public string? LicenseUrl { get; set; }

    /// <summary>
    /// Gets or sets the relative or absolute path/URL to the plugin icon.
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    /// Gets or sets the URL to the project or documentation related to the plugin.
    /// </summary>
    public string? ProjectUrl { get; set; }

    /// <summary>
    /// Gets or sets the copyright notice for the plugin.
    /// </summary>
    public string? Copyright { get; set; }

    /// <summary>
    /// Gets or sets a simicolon-delimited list of tags used to categorize or describe the plugin.
    /// Useful for search and filtering.
    /// </summary>
    public List<string> Tags { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the URL to the source code repository of the plugin.
    /// </summary>
    public string? RepositoryUrl { get; set; }

    /// <summary>
    /// Gets or sets the namespace the plugin belongs to.
    /// Used as the middle component in the plugin's type identifier.
    /// </summary>
    public required PluginNamespace Namespace { get; set; }

    /// <summary>
    /// Gets the full plugin type name in the format: CompanyName.Namespace.PluginName.
    /// This is used for plugin resolution, identification, or registration.
    /// </summary>
    public string Type => $"{CompanyName}.{Namespace}.{Name}";

    /// <summary>
    /// Validates that an identifier is non-empty, starts with a letter,
    /// and contains only letters and digits.
    /// </summary>
    /// <param name="input">The string to validate.</param>
    /// <param name="fieldName">The name of the field being validated, used in the error message.</param>
    /// <returns>The validated input string.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the input is null, whitespace, or contains invalid characters.
    /// </exception>
    private static string ValidateIdentifier(string input, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException($"{fieldName} cannot be null or whitespace.");

        if (!ValidIdentifierRegex.IsMatch(input))
            throw new ArgumentException($"{fieldName} must start with a letter and contain only letters and " +
                $"digits (no underscores, spaces, or symbols).");

        return input;
    }
}