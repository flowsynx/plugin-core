namespace FlowSynx.PluginCore.UnitTests
{
    public class SpecificationMetadataAttributeTests
    {
        private class Sample
        {
            [SpecificationMetadataAttribute]
            public string? Value { get; set; }
        }

        [Fact]
        public void Defaults_Are_Correct()
        {
            var attr = new SpecificationMetadataAttribute();

            Assert.Null(attr.Description);
            Assert.False(attr.IsRequired);
        }

        [Fact]
        public void Properties_Can_Be_Set()
        {
            var attr = new SpecificationMetadataAttribute
            {
                Description = "desc",
                IsRequired = true
            };

            Assert.Equal("desc", attr.Description);
            Assert.True(attr.IsRequired);
        }

        [Fact]
        public void Attribute_Is_Applied_To_Property()
        {
            var prop = typeof(Sample).GetProperty(nameof(Sample.Value))!;
            var attr = prop.GetCustomAttributes(typeof(SpecificationMetadataAttribute), inherit: false)
                           .OfType<SpecificationMetadataAttribute>()
                           .SingleOrDefault();

            Assert.NotNull(attr);
        }

        [Fact]
        public void AttributeUsage_Targets_Property_And_Is_Not_Inherited()
        {
            var usage = (AttributeUsageAttribute?)Attribute.GetCustomAttribute(
                typeof(SpecificationMetadataAttribute), typeof(AttributeUsageAttribute));

            Assert.NotNull(usage);
            Assert.Equal(AttributeTargets.Property, usage!.ValidOn);
            Assert.False(usage.Inherited);
        }

        private class BaseSample
        {
            [SpecificationMetadataAttribute]
            public virtual string? BaseProp { get; set; }
        }

        private class DerivedSample : BaseSample
        {
            public override string? BaseProp { get; set; }
        }

        [Fact]
        public void Attribute_Is_Not_Inherited_On_Override()
        {
            var derivedProp = typeof(DerivedSample).GetProperty(nameof(DerivedSample.BaseProp))!;
            var attr = derivedProp.GetCustomAttributes(typeof(SpecificationMetadataAttribute), inherit: true)
                                   .OfType<SpecificationMetadataAttribute>()
                                   .SingleOrDefault();

            Assert.Null(attr);
        }
    }
}
