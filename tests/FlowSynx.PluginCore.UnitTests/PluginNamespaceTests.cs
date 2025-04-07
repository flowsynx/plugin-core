using System;
using System.Collections.Generic;
namespace FlowSynx.PluginCore.UnitTests;

public class PluginNamespaceTests
{
    [Fact]
    public void PluginNamespace_ShouldContainExpectedValues()
    {
        // Check for presence of each expected enum value
        Assert.True(Enum.IsDefined(typeof(PluginNamespace), PluginNamespace.Logics));
        Assert.True(Enum.IsDefined(typeof(PluginNamespace), PluginNamespace.Connectors));
        Assert.True(Enum.IsDefined(typeof(PluginNamespace), PluginNamespace.Transformers));
    }

    [Fact]
    public void PluginNamespace_Values_ShouldHaveCorrectUnderlyingIntegers()
    {
        Assert.Equal(0, (int)PluginNamespace.Logics);
        Assert.Equal(1, (int)PluginNamespace.Connectors);
        Assert.Equal(2, (int)PluginNamespace.Transformers);
    }

    [Theory]
    [InlineData("Logics", PluginNamespace.Logics)]
    [InlineData("Connectors", PluginNamespace.Connectors)]
    [InlineData("Transformers", PluginNamespace.Transformers)]
    public void PluginNamespace_ShouldParseFromString(string input, PluginNamespace expected)
    {
        var result = Enum.Parse<PluginNamespace>(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PluginNamespace_InvalidParse_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => Enum.Parse<PluginNamespace>("InvalidValue"));
    }
}