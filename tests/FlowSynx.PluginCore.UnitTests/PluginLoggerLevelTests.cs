namespace FlowSynx.PluginCore.UnitTests;

public class PluginLoggerLevelTests
{
    [Fact]
    public void Enum_Should_Have_Correct_Values()
    {
        Assert.Equal(0, (int)PluginLoggerLevel.Debug);
        Assert.Equal(1, (int)PluginLoggerLevel.Information);
        Assert.Equal(2, (int)PluginLoggerLevel.Warning);
        Assert.Equal(3, (int)PluginLoggerLevel.Error);
    }

    [Theory]
    [InlineData(0, PluginLoggerLevel.Debug)]
    [InlineData(1, PluginLoggerLevel.Information)]
    [InlineData(2, PluginLoggerLevel.Warning)]
    [InlineData(3, PluginLoggerLevel.Error)]
    public void Enum_Should_Parse_From_Int(int value, PluginLoggerLevel expected)
    {
        var level = (PluginLoggerLevel)value;
        Assert.Equal(expected, level);
    }

    [Theory]
    [InlineData("Debug", PluginLoggerLevel.Debug)]
    [InlineData("Information", PluginLoggerLevel.Information)]
    [InlineData("Warning", PluginLoggerLevel.Warning)]
    [InlineData("Error", PluginLoggerLevel.Error)]
    public void Enum_Should_Parse_From_String(string name, PluginLoggerLevel expected)
    {
        var result = Enum.Parse<PluginLoggerLevel>(name);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Enum_Parse_Invalid_String_Should_Throw()
    {
        Assert.Throws<ArgumentException>(() => Enum.Parse<PluginLoggerLevel>("Fatal"));
    }

    [Fact]
    public void Casting_Invalid_Int_To_Enum_Should_Work_But_Be_Unsafe()
    {
        var level = (PluginLoggerLevel)99;
        Assert.Equal((PluginLoggerLevel)99, level); // Value exists, but not defined in enum
        Assert.False(Enum.IsDefined(typeof(PluginLoggerLevel), level));
    }
}