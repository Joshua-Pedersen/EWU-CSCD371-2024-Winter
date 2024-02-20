namespace Calculate;
using System;
using System.Collections.Generic;

public class Calculator
{
    public readonly IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations = 
      new Dictionary<char, Func<int, int, double>>
    { 
      { '+', Add },
      { '-', Subtract },
      { '*', Multiple },
      { '/', Divide}
    };

    public static double Add(int a, int b)
    {
      return a + b;
    }

    public static double Subtract(int a, int b)
    {
      return a - b;
    } 

    public static double Multiple(int a, int b)
    {
      return a * b;
    }

    public static double Divide(int a, int b)
    {
      if (b == 0)
      {
        throw new ArgumentException("Cannot Divide by zero");
      }

      return (double) a / b; 
    }



   /*
    public static Func<int, int, double> Add { get; set; } = (valueX, valueY) => valueX + valueY;
    public static Func<int, int, double> Subtract { get; set; } = (valueX, valueY) => valueX - valueY;
    public static Func<int, int, double> Multiple { get; set; } = (valueX, valueY) => valueX * valueY;
    public static Func<int, int, double> Divide { get; set; } = (valueX, valueY) => valueX / valueY;
*/

    
    public bool TryCalculate(string input, out double output)
    {
        output = 0;
        

        // Split up the input
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Make sure correct amount of inputs
        if(parts.Length != 3)
        {
          return false;
        }

        // Make sure operands are integers
        int opperand1, opperand2;
        
        if((!int.TryParse(parts[0], out opperand1)) || (!int.TryParse(parts[2], out opperand2)))
        {
          return false;
        }

        // Get operator
        char mathSymbol = parts[1][0];

        // Make sure symbol is in the Dictionary
        if (MathematicalOperations.TryGetValue(mathSymbol, out var operation))
        {
          // Get result if in Dictionary
          output = operation(opperand1, opperand2);
          
          return true;
        }

        
        // Bad Symbol
        return false;
    }
  

}

/*
public static class HelperMethod
{
    public static bool IsInt(this string s)
    {
      int x = 0;
      return int.TryParse(s, out x);
    }
}
*/

