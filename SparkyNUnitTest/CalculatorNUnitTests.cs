using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            int result = calc.AddNumbers(10, 20);


            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_OutputFalse()
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(10);


            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(7)]
        [TestCase(41)]
        [TestCase(13)]
        [TestCase(11)]
        public void IsOddChecker_InputOddNumber_OutputTrue(int a)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(a);


            //Assert
            Assert.IsTrue(result);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNum_ReturnTrueIfNumberIsOdd(int a)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(a);


            //Assert
            return result;


        }

        [Test]
        [TestCase(5.4, 6.9)] //12.3
        [TestCase(13.4, 6.4)] //19.8
        [TestCase(1.9, 10.18)] //12.08
        [TestCase(43.7, 6.5)] //50.2
        public void AddNumbersDouble_InputTwoDoubles_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            double result = calc.AddNumbersDoubles(a, b);


            //Assert
            Assert.AreEqual(12.3, result, 50);
            //The third parameter is the Delta which gives a range within which the result is considered
            //Acurate
        }

        [Test]
        public void OddRanger_InputMinAndMax_ReturnsValidOddNumberRange()
        {
            //Arrange
            Calculator calculator = new Calculator();
            List<int> ExpectedResult = new() { 5, 7, 9 }; //5-10

            //Act
            List<int> result = calculator.GetOddRange(5,10);

            //Assert
            Assert.That(result, Is.EquivalentTo(ExpectedResult));

        }
    }
}
