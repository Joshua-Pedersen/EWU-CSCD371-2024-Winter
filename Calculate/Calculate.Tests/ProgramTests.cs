using Xunit;
using System;
using System.IO;

namespace Calculate.Tests;

public class ProgramTests
{
    [Fact]
    public void Program_WriteLine_OutputIsEqual()
    {
        // Arrange
        StringWriter capture = new();
        Console.SetOut(capture);

        Program testProg = new();

        string testMessage = "foo";

        // Act
        testProg.WriteLine(testMessage);

        // Assert
        Assert.Equal(testMessage, capture.ToString().Trim());
    }

    [Fact]
    public void Program_ReadLine_InputIsEqual()
    {
        // Arrange
        string testMessage = "foo";
        StringReader capture = new(testMessage);
        Console.SetIn(capture);
        Program testProg = new();

        // Act
        string? readString = testProg.ReadLine();

        // Assert
        Assert.Equal(testMessage, readString);
    }
}
