using VibeCoding.Core.Services;
using Xunit;

namespace VibeCoding.Tests;

public class CodeExecutionServiceTests
{
    private readonly CodeExecutionService _service;

    public CodeExecutionServiceTests()
    {
        _service = new CodeExecutionService();
    }

    [Fact]
    public async Task ExecuteCodeAsync_WithValidCode_ReturnsSuccessResult()
    {
        // Arrange
        var code = @"
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine(""Hello, World!"");
    }
}";

        // Act
        var result = await _service.ExecuteCodeAsync(code);

        // Assert
        Assert.True(result.Success);
        Assert.Contains("Hello, World!", result.Output);
    }

    [Fact]
    public async Task ExecuteCodeAsync_WithInvalidCode_ReturnsFailureResult()
    {
        // Arrange
        var code = @"
using System;
class Program
{
    static void Main()
    {
        This is invalid syntax
    }
}";

        // Act
        var result = await _service.ExecuteCodeAsync(code);

        // Assert
        Assert.False(result.Success);
        Assert.NotNull(result.ErrorMessage);
    }

    [Fact]
    public async Task ExecuteCodeAsync_WithEmptyCode_ReturnsFailureResult()
    {
        // Arrange
        var code = string.Empty;

        // Act
        var result = await _service.ExecuteCodeAsync(code);

        // Assert
        Assert.False(result.Success);
        Assert.Equal("No code provided.", result.Output);
    }

    [Fact]
    public async Task ExecuteCodeAsync_WithRuntimeError_ReturnsFailureResult()
    {
        // Arrange
        var code = @"
using System;
class Program
{
    static void Main()
    {
        throw new Exception(""Runtime error"");
    }
}";

        // Act
        var result = await _service.ExecuteCodeAsync(code);

        // Assert
        Assert.False(result.Success);
    }

    [Fact]
    public async Task ExecuteCodeAsync_WithMultipleOutputLines_CapturesAllOutput()
    {
        // Arrange
        var code = @"
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine(""Line 1"");
        Console.WriteLine(""Line 2"");
        Console.WriteLine(""Line 3"");
    }
}";

        // Act
        var result = await _service.ExecuteCodeAsync(code);

        // Assert
        Assert.True(result.Success);
        Assert.Contains("Line 1", result.Output);
        Assert.Contains("Line 2", result.Output);
        Assert.Contains("Line 3", result.Output);
    }
}
