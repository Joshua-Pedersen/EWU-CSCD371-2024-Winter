using System;

namespace CanHazFunny;

public class JokeOutput : IOutputJokes
{
    public void SayJoke(string joke)
    {
        Console.WriteLine(joke);
    }
}
