namespace FlowSynx.PluginCore.UnitTests;

public class PluginContextTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        var context = new PluginContext("test-id", "Database");

        Assert.Equal("test-id", context.Id);
        Assert.Equal("Database", context.SourceType);
        Assert.Empty(context.Metadata);
    }

    [Fact]
    public void TryAddMetadata_Single_ShouldAddValidKeyValue()
    {
        var context = new PluginContext("id", "type");

        context.TryAddMetadata("key", "value");

        Assert.True(context.Metadata.ContainsKey("key"));
        Assert.Equal("value", context.Metadata["key"]);
    }

    [Fact]
    public void TryAddMetadata_Single_ShouldNotAddNullKeyOrValue()
    {
        var context = new PluginContext("id", "type");

        context.TryAddMetadata(null, "value");
        context.TryAddMetadata("key", null);

        Assert.Empty(context.Metadata);
    }

    [Fact]
    public void TryAddMetadata_Multiple_ShouldAddValidPairs()
    {
        var context = new PluginContext("id", "type");

        context.TryAddMetadata("Key1", "Value1", "Key2", "Value2");

        Assert.Equal("Value1", context.Metadata["Key1"]);
        Assert.Equal("Value2", context.Metadata["Key2"]);
    }

    [Fact]
    public void TryAddMetadata_Multiple_ShouldIgnoreEmptyStringValues()
    {
        var context = new PluginContext("id", "type");

        context.TryAddMetadata("Key1", "", "Key2", "Value2");

        Assert.False(context.Metadata.ContainsKey("Key1"));
        Assert.True(context.Metadata.ContainsKey("Key2"));
    }

    [Fact]
    public void TryGetMetadata_ShouldReturnValueIfExistsAndCorrectType()
    {
        var context = new PluginContext("id", "type");
        context.TryAddMetadata("Timeout", 30);

        var result = context.TryGetMetadata("Timeout", out int value, -1);

        Assert.True(result);
        Assert.Equal(30, value);
    }

    [Fact]
    public void TryGetMetadata_ShouldReturnDefaultIfNotExists()
    {
        var context = new PluginContext("id", "type");

        var result = context.TryGetMetadata("MissingKey", out int value, -1);

        Assert.False(result);
        Assert.Equal(-1, value);
    }

    [Fact]
    public void TryGetMetadata_ShouldReturnDefaultIfWrongType()
    {
        var context = new PluginContext("id", "type");
        context.TryAddMetadata("Timeout", "thirty");

        var result = context.TryGetMetadata("Timeout", out int value, -1);

        Assert.False(result);
        Assert.Equal(-1, value);
    }

    [Fact]
    public void Equals_ShouldReturnTrueForSameIdAndSourceType()
    {
        var a = new PluginContext("id", "type");
        var b = new PluginContext("id", "type");

        Assert.True(a.Equals(b));
        Assert.True(a.Equals((object)b));
        Assert.True(a == b);
        Assert.False(a != b);
    }

    [Fact]
    public void Equals_ShouldReturnFalseForDifferentIdOrSourceType()
    {
        var a = new PluginContext("id1", "type");
        var b = new PluginContext("id2", "type");

        Assert.False(a.Equals(b));
        Assert.False(a == b);
    }

    [Fact]
    public void Clone_ShouldReturnDeepCopy()
    {
        var context = new PluginContext("id", "type");
        context.TryAddMetadata("Key", "Value");
        context.Content = "Text";
        context.RawData = new byte[] { 1, 2, 3 };
        context.StructuredData = new List<Dictionary<string, object>> { new Dictionary<string, object> { { "col", "val" } } };

        var clone = (PluginContext)context.Clone();

        Assert.NotSame(context, clone);
        Assert.Equal(context.Id, clone.Id);
        Assert.Equal(context.SourceType, clone.SourceType);
        Assert.Equal(context.Content, clone.Content);
        Assert.Equal(context.RawData, clone.RawData);
        Assert.Equal(context.Metadata["Key"], clone.Metadata["Key"]);
    }

    [Fact]
    public void GetHashCode_ShouldCombineIdAndSourceType()
    {
        var a = new PluginContext("id", "type");
        var b = new PluginContext("id", "type");

        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        var context = new PluginContext("my-id", "File");

        Assert.Equal("File:my-id", context.ToString());
    }

    [Fact]
    public void ImplicitConversionToString_ShouldReturnId()
    {
        var context = new PluginContext("abc123", "Blob");

        string id = context;

        Assert.Equal("abc123", id);
    }
}