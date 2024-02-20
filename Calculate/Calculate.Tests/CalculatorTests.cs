using Xunit;
using System;

namespace Calculate.Tests;

public class CalculatorTests
{

  [Theory]
  [InlineData('+', 3, 4, 7)]
  [InlineData('-', 8, 2, 6)]
  [InlineData('*', 5, 6, 30)]
  [InlineData('/', 9, 3, 3)]
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
  public void Divide_ByZero_ThrowsException()
  {
    // Arrange
    Calculator calculator = new();

    // Act & Assert
    Assert.Throws<ArgumentException>(() => calculator.MathematicalOperations['/'](1, 0));
  }

}
