namespace Atividade13.Tests;
public class FactorialCalculatorTests
{
    private readonly FactorialCalculator _sut;
    public FactorialCalculatorTests()
    {
        _sut = new FactorialCalculator();
    }

    [Fact]
    public void Calculate_NegativeNumber_ShouldReturnError()
    {
        // Arrange
        int number = -1;

        // Act // Assert
        Assert.Throws<ArgumentException>(() => _sut.Calculate(number));
    }

    [Fact]
    public void Calculate_NumberZero_ShouldReturnOne()
    {
        // Arrange
        int number = 0;

        // Act
        var result = _sut.Calculate(number);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Calculate_NumberOne_ShouldReturnOne()
    {
        //Arrange
        int number = 1;

        //Act
        var result = _sut.Calculate(number);

        //Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Calculate_ValidNumber_ShouldReturnFactorial()
    {
        // Arrange
        int number = 6;

        // Act
        var result = _sut.Calculate(number);

        // Assert
        Assert.Equal(720, result);
    }
}
