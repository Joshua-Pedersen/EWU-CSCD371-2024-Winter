using Xunit;
using System;

namespace Calculate.Tests;

public class CalculatorTests
{

  [Theory]
  [InlineData('+', 3, 4, 7)]
  [InlineData('-', 8, 2, 6)]
  [InlineData('*', 5, 6, 30)]
  [InlineData('/', 6, 4, 1.5)]
  public void MathematicalOperations_ReturnsCorrectResult(char mathSymbol, int operand1, int operand2, double resultsExpected)
  {
    // Arrange
    Calculator calculator = new();

    // Act
    var result = calculator.MathematicalOperations[mathSymbol](operand1, operand2);

    // Assert
    Assert.Equal(resultsExpected, result);
  }


  [Fact]
  public void MathematicalOperations_Divide_ByZero_ThrowsException()
  {
    // Arrange
    Calculator calculator = new();

    // Act & Assert
    Assert.Throws<ArgumentException>(() => calculator.MathematicalOperations['/'](1, 0));
  }



  [Theory]
  [InlineData("1 + 2", 3)]
  [InlineData("2 - 1", 1)]
  [InlineData("2 * 2", 4)]
  [InlineData("4 / 2", 2)]
  public void TryCalculate_ValidInputs_Succeeds(string inputs, double correctOutput)
  {
    // Arrange
    Calculator calculator = new();

    // Act
    var result = calculator.TryCalculate(inputs, out double output);

    // Assert
    Assert.True(result);
    Assert.Equal(correctOutput, output);
  }


  [Theory]
  [InlineData("5 / 0")]
  public void TryCalculate_DivideByZero_ThrowsException(string input)
  {
    // Arrange 
    Calculator calculator = new();

    // Act & Assert
    Assert.Throws<ArgumentException>(() => calculator.TryCalculate(input, out double output));
  }


  [Theory]
  [InlineData("invalid input")]
  [InlineData("2 +")]
  public void TryCalculate_InvalidInputs_IsFalse(string input)
  {
    // Arrange
    Calculator calculator = new();

    // Act
    var result = calculator.TryCalculate(input, out double output);

    // Assert
    Assert.False(result);
  }

}
