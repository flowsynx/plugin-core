# FlowSynx PluginCore

**FlowSynx PluginCore** is a lightweight, extensible plugin execution framework designed for modular application architecture. 
It supports structured error handling, versioning, logging, and flexible plugin execution with parameter and specification support.

---

## ✨ Features

- 🔌 **Plugin Interface**: Define reusable plugins with metadata, specifications, and execution logic.
- ⚙️ **Execution Parameters**: Pass dynamic parameters and retrieve results using a standardized dictionary.
- 📋 **Specifications Model**: Configure plugins with reusable specifications.
- 🪵 **Plugin Logging**: Built-in logger interface with multiple severity levels.
- 🧪 **Versioning System**: Compare and manage plugin versions (`Major.Minor.Patch`).
- ❗ **Custom Error Handling**: Structured exceptions and codes via `FlowSynxException` and `ErrorMessage`.
- 🏷️ **Required Attributes**: Decorate required specification fields with `RequiredMemberAttribute`.

---

## 🧩 Core Concepts

### ✅ IPlugin Interface

The heart of the framework, the `IPlugin` interface, enforces a contract for plugin implementation:

```csharp
public interface IPlugin
{
    PluginMetadata Metadata { get; }
    PluginSpecifications? Specifications { get; set; }
    Type SpecificationsType { get; }
    Task Initialize(IPluginLogger logger);
    Task<object?> ExecuteAsync(PluginParameters parameters, CancellationToken cancellationToken);
}
```

- Metadata: Descriptive data like name, description, author, etc.
- Specifications: Custom configuration for plugin behavior.
- SpecificationsType: Strongly typed representation of specifications (with validation).
- Initialize: Called before execution, typically for setup or validation.
- ExecuteAsync: The main execution method, receiving input parameters and returning results.


## ⚙️ Plugin Metadata & Specifications
A case-insensitive dictionary allowing plugins to define required and optional configuration options. Supports deep cloning and dynamic usage:

```csharp
public class PluginSpecifications : Dictionary<string, object?>, ICloneable
```

Supports `[RequiredMember]` attribute for validation:

```csharp
[RequiredMember]
public string RequiredSetting { get; set; }
```

### Create simple specifications
```csharp
public class MyPluginSpecs : PluginSpecifications
{
    [RequiredMember]
    public string RequiredSetting { get; set; } = "default";
}
```


## 📦 Parameters and Cloning
`PluginParameters` provides a flexible, case-insensitive dictionary to pass runtime data to plugins:

```csharp
public class PluginParameters : Dictionary<string, object?>, ICloneable
```
Use `.Clone()` for safe state reuse.


## 🛠 Logging
Plugins receive a logging abstraction to emit structured logs:
```csharp
public interface IPluginLogger
{
    void Log(PluginLoggerLevel level, string message);
}
```

### Log Levels
Use the logger with severity levels or extension methods:
```csharp
public enum PluginLoggerLevel
{
    Debug,
    Information,
    Warning,
    Error
}
```

#### Logger Extensions
```csharp
logger.LogInfo("Started processing...");
logger.LogError("An error occurred.");
```

## 🧭 Namespacing Support
To organize plugins by type or domain, use the `PluginNamespace` enum:

```csharp
public enum PluginNamespace
{
    Logics,
    Connectors,
    Transformers
}
```

## 🧪 Example Plugin
```csharp
public class SampleGreetingPlugin : IPlugin
{
    public PluginMetadata Metadata => new("GreetingPlugin", "Returns a greeting message.");

    public PluginSpecifications? Specifications { get; set; }

    public Type SpecificationsType => typeof(GreetingSpecs);

    public Task Initialize(IPluginLogger logger)
    {
        logger.LogInfo("Initializing GreetingPlugin...");
        return Task.CompletedTask;
    }

    public Task<object?> ExecuteAsync(PluginParameters parameters, CancellationToken cancellationToken)
    {
        string name = parameters.TryGetValue("name", out var value) ? value?.ToString() ?? "World" : "World";
        return Task.FromResult<object?>($"Hello, {name}!");
    }
}
```