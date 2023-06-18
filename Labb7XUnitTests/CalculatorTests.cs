namespace Labb7XUnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Addtition_50Minus371_Return_Minus321()
        {
            // Arrange
            double actual;
            double expected = -321;

            // Act
            actual = Labb7XUnit.Calculator.Addition(50, -371);

            // Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void Subtraction_100Minus390_Return_490()
        {
            double actual;
            double expected = 490;

            actual = Labb7XUnit.Calculator.Subtraction(100, -390);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Division_100Divideby0_Return_0()
        {
            double actual;
            double expected = 0;

            actual = Labb7XUnit.Calculator.Division(100, 0);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Multiplication_50Times50_Return_2500()
        {
            double actual;
            double expected = 2500;

            actual = Labb7XUnit.Calculator.Multiplication(50, 50);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("1", '+')]
        [InlineData("2", '-')]
        [InlineData("3", '/')]
        [InlineData("4", '*')]
        [InlineData("b", '0')]
        [InlineData("0", '0')]
        [InlineData("5", '0')]
        public void GetOperationSymbol_ReturnPlusMinusSlashAsterisk(string choice, char expected)
        {
            char actual = Labb7XUnit.Calculator.GetOperationSymbol(choice);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData("1", 5, 10)]
        [InlineData("2", 3, 6)]
        [InlineData("3", 100, 5)]
        [InlineData("4", 20, 2)]
        [InlineData("0", 5, 10)]
        public void AddCalculationsToList(string choice, double n1, double n2)
        {
            char operation = Labb7XUnit.Calculator.GetOperationSymbol(choice);
            double result = Labb7XUnit.Program.RunMethod(choice, n1, n2);

            Labb7XUnit.Calculator.CreateResult(choice, n1, n2, result);
            string expected = $"{n1}{operation}{n2} = {result}";

            Assert.Contains(expected, Labb7XUnit.Calculator.calculations.Last());
        }
    }
}