namespace FlowSynx.PluginCore.Exceptions;

/// <summary>
/// Represents errors that occur during FlowSynX operations and includes an error code and message.
/// </summary>
public class FlowSynxException : Exception
{
    /// <summary>
    /// Gets the custom error code associated with this exception.
    /// </summary>
    public int ErrorCode { get; }

    /// <summary>
    /// Gets the human-readable error message associated with this exception.
    /// </summary>
    public string ErrorMessage { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FlowSynxException"/> class using an <see cref="ErrorMessage"/> object.
    /// </summary>
    /// <param name="errorMessage">The structured error message object containing the code and message.</param>
    public FlowSynxException(ErrorMessage errorMessage) : this(errorMessage.Code, errorMessage.Message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FlowSynxException"/> class with a specified error code and message.
    /// </summary>
    /// <param name="errorCode">The custom error code.</param>
    /// <param name="errorMessage">The human-readable error message.</param>
    public FlowSynxException(int errorCode, string errorMessage)
        : base(errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FlowSynxException"/> class with a specified error code, message, and inner exception.
    /// </summary>
    /// <param name="errorCode">The custom error code.</param>
    /// <param name="errorMessage">The human-readable error message.</param>
    /// <param name="innerException">The exception that is the cause of this exception.</param>
    public FlowSynxException(int errorCode, string errorMessage, Exception innerException)
        : base(errorMessage, innerException)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Returns a formatted string representation of the exception, including the prefixed error code and message.
    /// </summary>
    /// <returns>A string in the format "[FSX{Code}] {Message}".</returns>
    public override string ToString() => new ErrorMessage(ErrorCode, ErrorMessage).ToString();
}