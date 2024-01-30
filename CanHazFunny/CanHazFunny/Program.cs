namespace CanHazFunny;

class Program
{
    static void Main(string[] args)
    {
        JokeService jokeService = new();
        JokeOutput jokeOutput = new();
        Jester jester = new(jokeService, jokeOutput);

        jester.TellJoke();
    }
}
