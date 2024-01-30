using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void GetJoke_CreateJoke_ReturnsJoke()
    {
        JokeService jokeService = new();
        string joke = jokeService.GetJoke();
        Assert.NotNull(joke);
    }

    [Fact]
    public void Jester_NullJokeService_ThrowsException()
    {
        JokeOutput jokeOutput = new();
        Assert.Throws<ArgumentNullException>(() => new Jester(null!, jokeOutput));
    }

    [Fact]
    public void Jester_NullJokeOutput_ThrowsException()
    {
        JokeService jokeService = new();
        Assert.Throws<ArgumentNullException>(() => new Jester(jokeService, null!));
    }

    [Fact]
    public void SayJoke_GivenJoke_WritesJoke()
    {

        JokeOutput jokeOutput = new();
        string joke = "42";

        var output = new StringWriter();
        Console.SetOut(output);

        jokeOutput.SayJoke(joke);
        string outputConversion = (output.ToString()).Replace(System.Environment.NewLine, "");
        

        Assert.Equal(joke, outputConversion);
    }

    [Fact]
    public void TellJoke_CreateJoke_DoesNotContainChuckNorris()
    {
        JokeService jokeService = new();
        JokeOutput output = new();
        Jester jester = new(jokeService, output);

        var consoleOut = new StringWriter();
        Console.SetOut(consoleOut);

        jester.TellJoke();
        string outputConversion = (consoleOut.ToString()).Replace(System.Environment.NewLine, "");

        Assert.DoesNotContain("Chuck Norris", outputConversion);
    }
}
