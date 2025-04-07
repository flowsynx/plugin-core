using FlowSynx.PluginCore.Exceptions;

namespace FlowSynx.PluginCore.UnitTests.Exceptions;

public class ErrorMessageTests
{
    [Fact]
    public void Constructor_ShouldSetCodeAndMessage()
    {
        // Arrange
        int expectedCode = 1001;
        string expectedMessage = "Something went wrong";

        // Act
        var errorMessage = new ErrorMessage(expectedCode, expectedMessage);

        // Assert
        Assert.Equal(expectedCode, errorMessage.Code);
        Assert.Equal(expectedMessage, errorMessage.Message);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedMessage()
    {
        // Arrange
        int code = 42;
        string message = "Unexpected error occurred";
        var errorMessage = new ErrorMessage(code, message);
        string expected = "[FSX42] Unexpected error occurred";

        // Act
        var actual = errorMessage.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, "Zero error", "[FSX0] Zero error")]
    [InlineData(9999, "Max code", "[FSX9999] Max code")]
    [InlineData(-1, "Negative code", "[FSX-1] Negative code")]
    [InlineData(100, "", "[FSX100] ")]
    public void ToString_ShouldHandleVariousInputs(int code, string message, string expected)
    {
        // Arrange
        var errorMessage = new ErrorMessage(code, message);

        // Act
        var result = errorMessage.ToString();

        // Assert
        Assert.Equal(expected, result);
    }
}