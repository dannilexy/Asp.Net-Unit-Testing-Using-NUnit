using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class FiboNUnitTests
    {
        private Fibo fibo;
        [SetUp]
        public void SetUp() { fibo = new Fibo(); }

        [Test]
        public void Fibo_WithRange_1()
        {
            //Arrange
            fibo.Range = 1;

            //Act
            List<int> fib = new List<int>();
            fib = fibo.GetFiboSeries();

            List<int> expectedRange = new() {0};

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(fib.Count, Is.GreaterThan(0)); //Not empty --- Done
                Assert.That(fib, Is.Ordered); // Checking if List is Ordered -- Done
                Assert.That(fib, Is.Not.Empty);  //Not empty --- Done
                Assert.That(fib, Is.Not.Null);  //Not empty --- Done
                Assert.That(fib, Is.EquivalentTo(expectedRange));
            });


        }

        [Test]
        public void Fibo_WithRange_6()
        {
            //Arrange
            fibo.Range = 6;

            //Act
            List<int> fib = new List<int>();
            fib = fibo.GetFiboSeries();
            List<int> expectedRange = new() { 0 , 1, 1, 2, 3, 5};

            //Assert
            Assert.That(fib.Contains(3), Is.True); //Checking if the list contains 3
            Assert.That(fib.Contains(4), Is.False); //Checking if the list does not contains 4
            Assert.That(fib, Has.No.Member(4)); //Checking if the list does not contains 4
            Assert.That(fib.Count(), Is.EqualTo(6)); //Checking if the list contains 6 objects
            Assert.That(fib, Is.EquivalentTo(expectedRange));
        }

    }
}
