using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{

    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            int result = calc.AddNumbers(10, 20);


            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddChecker_InputEvenNumber_OutputFalse()
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(10);


            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(41)]
        [InlineData(13)]
        [InlineData(11)]
        public void IsOddChecker_InputOddNumber_OutputTrue(int a)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(a);


            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNum_ReturnTrueIfNumberIsOdd(int a, bool res)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(a);


            //Assert
            //return result;
            Assert.Equal(res, result);


        }

        [Theory]
        [InlineData(5.4, 6.9)] //12.3
        [InlineData(13.4, 6.4)] //19.8
        [InlineData(1.9, 10.18)] //12.08
        [InlineData(43.7, 6.5)] //50.2
        public void AddNumbersDouble_InputTwoDoubles_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            double result = calc.AddNumbersDoubles(a, b);


            //Assert
            Assert.Equal(12.3, result, 0);
            //The third parameter is the Delta which gives a range within which the result is considered
            //Acurate
        }

        [Fact]
        public void OddRanger_InputMinAndMax_ReturnsValidOddNumberRange()
        {
            //Arrange
            Calculator calculator = new Calculator();
            List<int> ExpectedResult = new() { 5, 7, 9 }; //5-10

            //Act
            List<int> result = calculator.GetOddRange(5, 10);

            //Assert
            Assert.Equal(result, ExpectedResult);

        }
    }
}
