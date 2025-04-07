namespace FlowSynx.PluginCore.UnitTests;

public class PluginVersionTests
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        var version = new PluginVersion(1, 2, 3);

        Assert.Equal(1, version.Major);
        Assert.Equal(2, version.Minor);
        Assert.Equal(3, version.Patch);
    }

    [Theory]
    [InlineData("1.0.0", 1, 0, 0)]
    [InlineData("10.20.30", 10, 20, 30)]
    [InlineData("0.0.1", 0, 0, 1)]
    public void Parse_ValidString_ReturnsCorrectVersion(string input, int major, int minor, int patch)
    {
        var version = PluginVersion.Parse(input);

        Assert.Equal(major, version.Major);
        Assert.Equal(minor, version.Minor);
        Assert.Equal(patch, version.Patch);
    }

    [Theory]
    [InlineData("1.0")]
    [InlineData("1")]
    [InlineData("1.0.0.0")]
    [InlineData("abc.def.ghi")]
    [InlineData("")]
    public void Parse_InvalidString_ThrowsFormatException(string input)
    {
        Assert.Throws<FormatException>(() => PluginVersion.Parse(input));
    }

    [Theory]
    [InlineData(1, 0, 0, 2, 0, 0, -1)]
    [InlineData(2, 1, 0, 2, 0, 5, 1)]
    [InlineData(1, 2, 3, 1, 2, 3, 0)]
    [InlineData(1, 0, 0, 1, 0, 1, -1)]
    public void CompareTo_WorksAsExpected(
        int major1, int minor1, int patch1,
        int major2, int minor2, int patch2,
        int expected)
    {
        var v1 = new PluginVersion(major1, minor1, patch1);
        var v2 = new PluginVersion(major2, minor2, patch2);

        Assert.Equal(expected, Math.Sign(v1.CompareTo(v2)));
    }

    [Fact]
    public void Equals_True_WhenVersionsMatch()
    {
        var v1 = new PluginVersion(1, 2, 3);
        var v2 = new PluginVersion(1, 2, 3);

        Assert.True(v1.Equals(v2));
        Assert.True(v1 == v2);
        Assert.False(v1 != v2);
    }

    [Fact]
    public void Equals_False_WhenVersionsDiffer()
    {
        var v1 = new PluginVersion(1, 2, 3);
        var v2 = new PluginVersion(1, 2, 4);

        Assert.False(v1.Equals(v2));
        Assert.False(v1 == v2);
        Assert.True(v1 != v2);
    }

    [Theory]
    [InlineData(1, 0, 0, 2, 0, 0, true)]
    [InlineData(2, 0, 0, 1, 0, 0, false)]
    public void OperatorLessThan_WorksCorrectly(int a1, int a2, int a3, int b1, int b2, int b3, bool expected)
    {
        var v1 = new PluginVersion(a1, a2, a3);
        var v2 = new PluginVersion(b1, b2, b3);

        Assert.Equal(expected, v1 < v2);
    }

    [Theory]
    [InlineData(1, 0, 0, 2, 0, 0, false)]
    [InlineData(2, 0, 0, 1, 0, 0, true)]
    public void OperatorGreaterThan_WorksCorrectly(int a1, int a2, int a3, int b1, int b2, int b3, bool expected)
    {
        var v1 = new PluginVersion(a1, a2, a3);
        var v2 = new PluginVersion(b1, b2, b3);

        Assert.Equal(expected, v1 > v2);
    }

    [Theory]
    [InlineData(1, 2, 3, "1.2.3")]
    [InlineData(0, 0, 1, "0.0.1")]
    public void ToString_ReturnsExpectedFormat(int major, int minor, int patch, string expected)
    {
        var version = new PluginVersion(major, minor, patch);

        Assert.Equal(expected, version.ToString());
    }
}