namespace FlowSynx.PluginCore.Extensions;

public static class PluginLoggerExtensions
{
    public static void LogInfo(this IPluginLogger logger, string message)
    {
        logger.Log(PluginLoggerLevel.Information, message);
    }

    public static void LogError(this IPluginLogger logger, string message)
    {
        logger.Log(PluginLoggerLevel.Error, message);
    }

    public static void LogDebug(this IPluginLogger logger, string message)
    {
        logger.Log(PluginLoggerLevel.Debug, message);
    }

    public static void LogWarning(this IPluginLogger logger, string message)
    {
        logger.Log(PluginLoggerLevel.Warning, message);
    }
}