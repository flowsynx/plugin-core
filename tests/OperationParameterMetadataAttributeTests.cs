using System;
using System.Linq;
using FlowSynx.PluginCore;
using Xunit;

namespace FlowSynx.PluginCore.UnitTests
{
    public class OperationParameterMetadataAttributeTests
    {
        [Fact]
        public void DefaultValues_ShouldBeExpected()
        {
            var attr = new OperationParameterMetadataAttribute();

            // Runtime default is null because of null-forgiving operator on initialization
            Assert.Null(attr.Description);
            Assert.False(attr.IsRequired);
        }

        [Fact]
        public void Description_SetAndGet_ShouldPersistValue()
        {
            var attr = new OperationParameterMetadataAttribute
            {
                Description = "Parameter description"
            };

            Assert.Equal("Parameter description", attr.Description);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsRequired_SetAndGet_ShouldPersistValue(bool value)
        {
            var attr = new OperationParameterMetadataAttribute
            {
                IsRequired = value
            };

            Assert.Equal(value, attr.IsRequired);
        }

        [Fact]
        public void AttributeUsage_ShouldTargetProperty_AndNotInherited()
        {
            var usage = (AttributeUsageAttribute?)typeof(OperationParameterMetadataAttribute)
                .GetCustomAttributes(typeof(AttributeUsageAttribute), inherit: false)
                .Cast<AttributeUsageAttribute>()
                .FirstOrDefault();

            Assert.NotNull(usage);
            Assert.True(usage!.ValidOn.HasFlag(AttributeTargets.Property));
            Assert.False(usage.Inherited);
        }
    }
}
