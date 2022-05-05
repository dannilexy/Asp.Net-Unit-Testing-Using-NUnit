using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator gCalc;
        public GradingCalculatorXUnitTests() { gCalc = new GradingCalculator(); }

        [Fact]
        public void GradingCalculator_Score70_Attendance95_ReturnA()
        {
            //Arrange
            gCalc.AttendancePercentage = 95;
            gCalc.Score = 95;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            Assert.Equal("A",result);
        }

        [Fact]
        public void GradingCalculator_Score80_Attendance60_ReturnsB()
        {
            //Arrange
            gCalc.AttendancePercentage = 62;
            gCalc.Score = 82;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            Assert.Equal("B",result);
        }

        [Fact]
        public void GradingCalculator_Score60_Attendance60_ReturnsC()
        {
            //Arrange
            gCalc.AttendancePercentage = 65;
            gCalc.Score = 65;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            Assert.Equal("C",result);
        }

        [Fact]
        public void GradingCalculator_Score50_Attendance50_ReturnF()
        {
            //Arrange
            gCalc.AttendancePercentage = 50;
            gCalc.Score = 45;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            Assert.Equal("F",result);
        }


        [Theory]
        [InlineData(95, 95, "A")]
        [InlineData(82, 62, "B")]
        [InlineData(65, 65, "C")]
        [InlineData(45, 50, "F")]
        public void GradingCalculator_GeneralTest(int score, int attendance ,string expectedResult)
        {
            //Arrange
            gCalc.AttendancePercentage = attendance;
            gCalc.Score = score;


            //Act
            var result = gCalc.GetGrade();

            //Assert

            //return result;
            Assert.Equal(expectedResult, result);
            //Assert.That(result, Is.EqualTo("A"));
        }
    }
}
