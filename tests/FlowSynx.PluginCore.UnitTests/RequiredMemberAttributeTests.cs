using System.Reflection;

namespace FlowSynx.PluginCore.UnitTests;

public class RequiredMemberAttributeTests
{
    // A dummy class to test attribute application
    private class TestClass
    {
        [RequiredMember]
        public string Name { get; set; }

        public int Age { get; set; }
    }

    [Fact]
    public void Attribute_CanBeAppliedToProperty()
    {
        // Arrange
        PropertyInfo property = typeof(TestClass).GetProperty(nameof(TestClass.Name));

        // Act
        var attribute = property.GetCustomAttribute<RequiredMemberAttribute>();

        // Assert
        Assert.NotNull(attribute);
    }

    [Fact]
    public void Attribute_IsNotAppliedToOtherProperties()
    {
        // Arrange
        PropertyInfo property = typeof(TestClass).GetProperty(nameof(TestClass.Age));

        // Act
        var attribute = property.GetCustomAttribute<RequiredMemberAttribute>();

        // Assert
        Assert.Null(attribute);
    }

    [Fact]
    public void Attribute_HasCorrectUsage()
    {
        // Arrange
        var usage = typeof(RequiredMemberAttribute)
            .GetCustomAttribute<AttributeUsageAttribute>();

        // Assert
        Assert.NotNull(usage);
        Assert.True(usage.ValidOn.HasFlag(AttributeTargets.Property));
        Assert.False(usage.AllowMultiple); // Default is false unless specified
    }
}