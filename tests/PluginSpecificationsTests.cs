using System;
using System.Collections.Generic;
using FlowSynx.PluginCore;
using Xunit;

namespace FlowSynx.PluginCore.UnitTests
{
    // Concrete implementation for testing PluginSpecifications
    public class TestSpecifications : PluginSpecifications
    {
        public int IntProp { get; set; }
        public string? StringProp { get; set; }
        public double DoubleProp { get; set; }
        public DateTime DateProp { get; set; }
        public bool BoolProp { get; set; }

        // Read-only property should not be set by FromDictionary
        public string ReadOnlyProp => "readonly";

        public override void Validate()
        {
            if (IntProp < 0)
                throw new ArgumentOutOfRangeException(nameof(IntProp));
        }
    }

    public class PluginSpecificationsTests
    {
        [Fact]
        public void FromDictionary_AssignsMatchingTypes()
        {
            var spec = new TestSpecifications();
            var dict = new Dictionary<string, object?>
            {
                { nameof(TestSpecifications.IntProp), 42 },
                { nameof(TestSpecifications.StringProp), "hello" },
                { nameof(TestSpecifications.DoubleProp), 3.14 },
                { nameof(TestSpecifications.BoolProp), true },
            };

            spec.FromDictionary(dict);

            Assert.Equal(42, spec.IntProp);
            Assert.Equal("hello", spec.StringProp);
            Assert.Equal(3.14, spec.DoubleProp);
            Assert.True(spec.BoolProp);
        }

        [Fact]
        public void FromDictionary_ConvertsTypes_WhenAssignableFails()
        {
            var spec = new TestSpecifications();
            var now = DateTime.UtcNow;
            var dict = new Dictionary<string, object?>
            {
                { nameof(TestSpecifications.IntProp), "123" },
                { nameof(TestSpecifications.DoubleProp), "2.5" },
                { nameof(TestSpecifications.BoolProp), "true" },
                { nameof(TestSpecifications.DateProp), now.ToString("O") },
            };

            spec.FromDictionary(dict);

            Assert.Equal(123, spec.IntProp);
            Assert.Equal(2.5, spec.DoubleProp);
            Assert.True(spec.BoolProp);
            Assert.Equal(now, spec.DateProp);
        }

        [Fact]
        public void FromDictionary_IgnoresUnknownKeys()
        {
            var spec = new TestSpecifications();
            spec.IntProp = 1;

            var dict = new Dictionary<string, object?>
            {
                { "DoesNotExist", 999 },
            };

            spec.FromDictionary(dict);

            Assert.Equal(1, spec.IntProp);
        }

        [Fact]
        public void FromDictionary_DoesNotSetReadOnlyProperties()
        {
            var spec = new TestSpecifications();
            var original = spec.ReadOnlyProp;

            var dict = new Dictionary<string, object?>
            {
                { nameof(TestSpecifications.ReadOnlyProp), "changed" },
            };

            spec.FromDictionary(dict);

            Assert.Equal(original, spec.ReadOnlyProp);
        }

        [Fact]
        public void FromDictionary_NullValuesAreIgnored()
        {
            var spec = new TestSpecifications { StringProp = "initial" };

            var dict = new Dictionary<string, object?>
            {
                { nameof(TestSpecifications.StringProp), null },
            };

            spec.FromDictionary(dict);

            Assert.Equal("initial", spec.StringProp);
        }

        [Fact]
        public void FromDictionary_InvalidConversion_Throws()
        {
            var spec = new TestSpecifications();
            var dict = new Dictionary<string, object?>
            {
                { nameof(TestSpecifications.IntProp), "not-an-int" },
            };

            Assert.ThrowsAny<Exception>(() => spec.FromDictionary(dict));
        }

        [Fact]
        public void Validate_ThrowsWhenInvalid()
        {
            var spec = new TestSpecifications { IntProp = -1 };
            Assert.Throws<ArgumentOutOfRangeException>(() => spec.Validate());
        }

        [Fact]
        public void Validate_SucceedsWhenValid()
        {
            var spec = new TestSpecifications { IntProp = 0 };
            spec.Validate();
        }
    }
}