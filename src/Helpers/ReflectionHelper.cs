using System.Diagnostics;

namespace FlowSynx.PluginCore.Helpers;

public static class ReflectionHelper
{
    public static bool IsCalledViaReflection()
    {
        var stack = new StackTrace();
        var frames = stack.GetFrames();

        if (frames == null)
            return false;

        foreach (var frame in frames)
        {
            var callingMethod = frame.GetMethod();
            if (callingMethod == null) continue;

            if (callingMethod.DeclaringType?.Namespace?.StartsWith("System.Reflection") == true)
                return true;
        }

        return false;
    }
}