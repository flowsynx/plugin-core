using System.Diagnostics;

namespace FlowSynx.PluginCore.Helpers;

public static class ReflectionHelper
{
    public static bool IsCalledViaReflection()
    {
        // Check only the immediate caller to avoid xUnit/testhost infrastructure
        var callingMethod = new StackFrame(1).GetMethod();
        return callingMethod?.DeclaringType?.Namespace?.StartsWith("System.Reflection") == true;
    }
}