using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void SetUp()
        {
            customer = new Customer();
        }

        [Test]
        public void CombineNames_InputFirstNameLastName_OutputFullName()
        {
            //Arrange

            //Act
            customer.GreetAndCombineNames("Jack", "Daniel");

            // Assert

            //Using Assert Multiple
            Assert.Multiple(() =>
            {
            Assert.AreEqual(customer.GreetMessage, "Hello, Jack Daniel");
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Jack daniel").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.Contain("Hello").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.StartWith("Hello,").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.EndWith("Daniel").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            //Arrange

            //Act

            //Assert
            Assert.IsNull(customer.GreetMessage);

        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnDiscountInRange()
        {
            int result = customer.discount;

            Assert.That(result, Is.InRange(15, 25));
        }

        [Test]
        public void GreetMessage_GreetWithoutLastName_ReturnsNotNull()
        {
            customer.GreetAndCombineNames("Dan", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_throwException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Dan"));
            Assert.That("Empty FirstName", Is.EqualTo(exceptionDetails.Message));
            Assert.That(()=>customer.GreetAndCombineNames("", "Dan"), 
                Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Empty FirstName"));
            
            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Dan"));
            Assert.That(() => customer.GreetAndCombineNames("", "Dan"),
                Throws.TypeOf<ArgumentException>());

        }

        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWithOver100Order_ReturnPlatiniumCustomer()
        {
            customer.OrderTotal = 110;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatiniumCustomer>());
        }
    }
}
