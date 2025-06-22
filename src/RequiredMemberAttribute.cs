namespace FlowSynx.PluginCore;

using System;

/// <summary>
/// Indicates that the decorated property is a required member and must be provided
/// during validation, serialization, or configuration processing.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class RequiredMemberAttribute : Attribute
{
}