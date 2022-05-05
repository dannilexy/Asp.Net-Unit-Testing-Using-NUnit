using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator gCalc;
        [SetUp]
        public void Setup() { gCalc = new GradingCalculator(); }

        [Test]
        public void GradingCalculator_Score70_Attendance95_ReturnA()
        {
            //Arrange
            gCalc.AttendancePercentage = 95;
            gCalc.Score = 95;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GradingCalculator_Score80_Attendance60_ReturnsB()
        {
            //Arrange
            gCalc.AttendancePercentage = 62;
            gCalc.Score = 82;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void GradingCalculator_Score60_Attendance60_ReturnsC()
        {
            //Arrange
            gCalc.AttendancePercentage = 65;
            gCalc.Score = 65;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void GradingCalculator_Score50_Attendance50_ReturnF()
        {
            //Arrange
            gCalc.AttendancePercentage = 50;
            gCalc.Score = 45;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            Assert.That(result, Is.EqualTo("F"));
        }


        [Test]
        [TestCase(95,95, ExpectedResult  ="A")]
        [TestCase(82,62, ExpectedResult = "B")]
        [TestCase(65,65, ExpectedResult = "C")]
        [TestCase(45,50, ExpectedResult = "F")]
        public string GradingCalculator_GeneralTest(int score, int attendance)
        {
            //Arrange
            gCalc.AttendancePercentage = attendance;
            gCalc.Score = score;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            return result;
            //Assert.That(result, Is.EqualTo("A"));
        }
    }
}
