using System;
using System.IO;
using Xunit;
using Moq;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void GetJoke_CreateJoke_ReturnsJoke()
    {
        var mockJokeService = new Mock<ICreateJokes>();
        var mockOutput = new Mock<IOutputJokes>();
        string testJoke = "foo";
        mockJokeService.SetupSequence(x => x.GetJoke()).Returns(testJoke);
        Jester jester = new(mockJokeService.Object, mockOutput.Object);

        jester.TellJoke();
        mockOutput.Verify(x => x.SayJoke(testJoke));
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
        var mockJokeService = new Mock<ICreateJokes>();
        var mockOutput = new Mock<IOutputJokes>();
        string testJoke = "foo";
        string badJoke = "I dislike Chuck Norris jokes";
        mockJokeService.SetupSequence(x => x.GetJoke()).Returns(badJoke).Returns(testJoke);
        Jester jester = new(mockJokeService.Object, mockOutput.Object);

        jester.TellJoke();
        mockOutput.Verify(x => x.SayJoke(testJoke));
    }
}
