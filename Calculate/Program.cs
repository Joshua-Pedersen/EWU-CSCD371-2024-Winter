
namespace Calculate;

public class Program
{
    public Program() { }

    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public static void Main(string[] args)
    {
        Program program = new();
        Calculator calculator = new();
        string? input;

        do
        {
            do
            {
                program.WriteLine("Enter an equation in the format 'x + y' \n or enter 'quit' to quit.");
                input = program.ReadLine();
            } while (input == null || input == "");

            if (input != "quit")
            {
                if (Calculator.TryCalculate(input, out double output))
                {
                    program.WriteLine(input + " = " + output);
                } else { program.WriteLine("Invalid equation"); }
            }

        } while (input != "quit");
    }
}
