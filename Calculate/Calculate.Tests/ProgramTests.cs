using Xunit;
using System;
using System.IO;
using IntelliTect.TestTools.Console;

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

    [Fact]
    public void ReadLine_EmptyInput_IsNull()
    {
        // Arrange
        StringReader input = new("");
        Console.SetIn(input);

        // Act
        Program testProg = new();

        // Assert
        Assert.Null(testProg.ReadLine());
    }

/* This library don't work, tried
 * 
    [Fact]
    public void Main_SampleUserInteraction_Success()
    {
        string view = @"Enter an equation or enter 'quit' <<2 + 2
>>
2 + 2 = 4";

        ConsoleAssert.Expect(view, Program.Main);
    }
*/
}
