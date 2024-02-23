using Xunit;
using System;

namespace Calculate.Tests;

public class CalculatorTests
{
  [Fact]
  public void Add_ValidInput_Success()
  {
    // Arrange & Act
    double result = Calculator.Add(1, 2);

    // Assert
    Assert.Equal(3, result);
  }

  [Fact]
  public void Subtract_ValidInput_Success()
  {
    // Arrange & Act
    double result = Calculator.Subtract(3, 2);
    
    // Assert
    Assert.Equal(1, result);
  }

  [Fact]
  public void Multiple_ValidInput_Success()
  {
    // Arrange & Act
    double result = Calculator.Multiple(3, 2);
    
    // Assert
    Assert.Equal(6, result);
  }

  [Fact]
  public void Divide_ValidInput_Success()
  {
    // Arrange & Act
    double result = Calculator.Divide(4, 2);
    
    // Assert
    Assert.Equal(2, result);
  }

  [Fact]
  public void Divide_InvalidInput_ThrowsException()
  {
    // Arrange & Act & Assert
    Assert.Throws<ArgumentException>(() => Calculator.Divide(4, 0));
  }


  [Theory]
  [InlineData("1 + 2", 3)]
  [InlineData("2 - 1", 1)]
  [InlineData("2 * 2", 4)]
  [InlineData("4 / 2", 2)]
  public void TryCalculate_ValidInputs_Succeeds(string inputs, double correctOutput)
  {
    // Arrange
    // Act
    bool result = Calculator.TryCalculate(inputs, out double output);

    // Assert
    Assert.True(result);
    Assert.Equal(correctOutput, output);
  }


  [Theory]
  [InlineData("5 / 0")]
  public void TryCalculate_DivideByZero_ThrowsException(string input)
  {
    // Arrange 
    // Act & Assert
    Assert.Throws<ArgumentException>(() => Calculator.TryCalculate(input, out double output));
  }


  [Theory]
  [InlineData("invalid input")]
  [InlineData("2 +")]
  public void TryCalculate_InvalidInputs_IsFalse(string input)
  {
    // Arrange
    // Act
    bool result = Calculator.TryCalculate(input, out double output);

    // Assert
    Assert.False(result);
  }

}
