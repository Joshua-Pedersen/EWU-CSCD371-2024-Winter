namespace Calculate;

public class Calculator
{
    // private IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { }

    public static Func<int, int, double> Add { get; set; } = (valueX, valueY) => valueX + valueY;
    public static Func<int, int, double> Subtract { get; set; } = (valueX, valueY) => valueX - valueY;
    public static Func<int, int, double> Multiple { get; set; } = (valueX, valueY) => valueX * valueY;
    public static Func<int, int, double> Divide { get; set; } = (valueX, valueY) => valueX / valueY;

    public bool TryCalculate(string input, out double output)
    {
        // TO BE DELETED
        output = 0;
        return true;
    }
}
