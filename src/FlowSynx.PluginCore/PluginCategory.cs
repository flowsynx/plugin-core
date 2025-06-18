namespace FlowSynx.PluginCore;

public sealed class PluginCategory
{
    /// <summary>
    /// Gets the unique identifier or key of the category (optional).
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the human-readable title of the category.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the description of the category.
    /// </summary>
    public string Description { get; }

    private PluginCategory(string id, string title, string description)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public override bool Equals(object? obj) =>
        obj is PluginCategory other && Id == other.Id;

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString() => $"{Title} ({Id})";

    internal static PluginCategory Create(string id, string title, string description) =>
        new PluginCategory(id, title, description);
}