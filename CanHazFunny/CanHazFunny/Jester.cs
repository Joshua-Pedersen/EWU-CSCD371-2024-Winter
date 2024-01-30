using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public class Jester
{
    private JokeService _jokeService;
    private JokeOutput _jokeOutput;

    public Jester(JokeService createJoke, JokeOutput outputJoke) 
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
