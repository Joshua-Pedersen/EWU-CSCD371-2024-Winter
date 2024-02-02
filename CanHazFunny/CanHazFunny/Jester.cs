using System;

namespace CanHazFunny;

public class Jester
{
    private ICreateJokes _jokeService;
    private IOutputJokes _jokeOutput;

    public Jester(ICreateJokes createJoke, IOutputJokes outputJoke) 
    {
        _jokeService = createJoke ?? throw new ArgumentNullException(nameof(createJoke));
        _jokeOutput = outputJoke ?? throw new ArgumentNullException(nameof(outputJoke));
    }

    public void TellJoke()
    {
        string joke = _jokeService.GetJoke();

        while (joke.Contains("Chuck Norris")) {joke = _jokeService.GetJoke();}

        _jokeOutput.SayJoke(joke);
    }
}
