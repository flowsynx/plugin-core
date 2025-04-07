namespace FlowSynx.PluginCore.Exceptions;

public class ErrorMessage
{
    private const string PrefixErrorMessage = "FSX"; // Abbreviation for FlowSynX

    public int Code { get; }
    public string Message { get; }

    public ErrorMessage(int code, string message)
    {
        Code = code;
        Message = message;
    }

    public override string ToString() => $"[{PrefixErrorMessage}{Code}] {Message}";
}
