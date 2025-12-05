using FlowSynx.PluginCore.Helpers;
using System.Reflection;

namespace FlowSynx.PluginCore.UnitTests.Helpers;

public class ReflectionHelperTests
{
    [Fact]
    public void IsCalledViaReflection_ReturnsFalse_WhenCalledDirectly()
    {
        // Act
        var result = ReflectionHelper.IsCalledViaReflection();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsCalledViaReflection_ReturnsTrue_WhenInvokedViaReflection()
    {
        // Arrange
        var method = typeof(ReflectionHelper).GetMethod(nameof(ReflectionHelper.IsCalledViaReflection), BindingFlags.Public | BindingFlags.Static);
        Assert.NotNull(method);

        // Act
        var result = (bool)method!.Invoke(null, null)!;

        // Assert
        Assert.True(result);
    }
}