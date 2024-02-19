
namespace Calculate;

public class Program
{
    public Program() { }

    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public static void Main(string[] args)
    {

    }
}
