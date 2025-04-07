namespace FlowSynx.PluginCore;

public interface IPluginLogger
{
    void Log(PluginLoggerLevel level, string message);
}