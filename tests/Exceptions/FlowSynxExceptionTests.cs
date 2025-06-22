using FlowSynx.PluginCore.Exceptions;

namespace FlowSynx.PluginCore.UnitTests.Exceptions;

public class FlowSynxExceptionTests
{
    [Fact]
    public void FlowSynxException_ShouldInitializeCorrectly_WhenUsingErrorMessage()
    {
        // Arrange
        var errorMessage = new ErrorMessage(123, "Sample error message");

        // Act
        var exception = new FlowSynxException(errorMessage);

        // Assert
        Assert.Equal(123, exception.ErrorCode);
        Assert.Equal("Sample error message", exception.ErrorMessage);
        Assert.Equal("Sample error message", exception.Message);
    }

    [Fact]
    public void FlowSynxException_ShouldInitializeCorrectly_WhenUsingErrorCodeAndMessage()
    {
        // Arrange
        int errorCode = 123;
        string errorMessage = "Sample error message";

        // Act
        var exception = new FlowSynxException(errorCode, errorMessage);

        // Assert
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.ErrorMessage);
        Assert.Equal(errorMessage, exception.Message);
    }

    [Fact]
    public void FlowSynxException_ShouldInitializeCorrectly_WhenUsingErrorCodeMessageAndInnerException()
    {
        // Arrange
        int errorCode = 123;
        string errorMessage = "Sample error message";
        var innerException = new InvalidOperationException("Inner exception");

        // Act
        var exception = new FlowSynxException(errorCode, errorMessage, innerException);

        // Assert
        Assert.Equal(errorCode, exception.ErrorCode);
        Assert.Equal(errorMessage, exception.ErrorMessage);
        Assert.Equal(errorMessage, exception.Message);
        Assert.Equal(innerException, exception.InnerException);
    }

    [Fact]
    public void FlowSynxException_ToString_ShouldReturnFormattedString()
    {
        // Arrange
        int errorCode = 123;
        string errorMessage = "Sample error message";
        var exception = new FlowSynxException(errorCode, errorMessage);

        // Act
        var result = exception.ToString();

        // Assert
        Assert.Equal($"[FSX{errorCode}] {errorMessage}", result);
    }
}