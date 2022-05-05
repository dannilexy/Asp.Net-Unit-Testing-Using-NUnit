using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class ProductNUnitTests
    {
        [Test]
        public void GetProductPrice_PlatniumCustomer_Return20Discount()
        {
            var product = new Product() { Price = 50 };

            var Result = product.GetPrice(new Customer() { IsPlatinium = true});

            Assert.That(Result, Is.EqualTo(40));
        }
    }
}
