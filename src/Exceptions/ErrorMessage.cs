namespace FlowSynx.PluginCore.Exceptions;

/// <summary>
/// Represents a structured error message with a numeric code and descriptive text.
/// </summary>
public class ErrorMessage
{
    /// <summary>
    /// The prefix used in the formatted error message, typically identifying the system (e.g., "FSX" for FlowSynX).
    /// </summary>
    private const string PrefixErrorMessage = "FSX"; // Abbreviation for FlowSynX

    /// <summary>
    /// Gets the numeric error code associated with the error.
    /// </summary>
    public int Code { get; }

    /// <summary>
    /// Gets the descriptive message explaining the error.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ErrorMessage"/> class with the specified code and message.
    /// </summary>
    /// <param name="code">The unique error code.</param>
    /// <param name="message">A human-readable message describing the error.</param>
    public ErrorMessage(int code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Returns a formatted string representation of the error message.
    /// </summary>
    /// <returns>A string in the format "[FSX{Code}] {Message}".</returns>
    public override string ToString() => $"[{PrefixErrorMessage}{Code}] {Message}";
}