using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class FiboXUnitTests
    {
        private Fibo fibo;
        public FiboXUnitTests() { fibo = new Fibo(); }

        [Fact]
        public void Fibo_WithRange_1()
        {
            //Arrange
            fibo.Range = 1;

            //Act
            List<int> fib = new List<int>();
            fib = fibo.GetFiboSeries();

            List<int> expectedRange = new() { 0 };

            //Assert
            Assert.Multiple(() =>
            {
                Assert.NotEmpty(fib); //Not empty --- Done
                Assert.Equal(expectedRange.OrderBy(u=>u), fib);
                Assert.NotEmpty(fib);  //Not empty --- Done
                Assert.NotNull(fib);  //Not empty --- Done
                Assert.Equal(fib,expectedRange);
            });


        }

        [Fact]
        public void Fibo_WithRange_6()
        {
            //Arrange
            fibo.Range = 6;

            //Act
            List<int> fib = new List<int>();
            fib = fibo.GetFiboSeries();
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };

            //Assert
            Assert.Contains(3, fib); //Checking if the list contains 3
            Assert.DoesNotContain(4,fib); //Checking if the list does not contains 4
            //Assert.That(fib, Has.No.Member(4)); //Checking if the list does not contains 4
            Assert.Equal(6,fib.Count()); //Checking if the list contains 6 objects
            Assert.Equal(fib, expectedRange);
        }

    }
}
