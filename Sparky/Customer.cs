using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int discount { get; set; } = 15;
        public int OrderTotal { get; set; }
        public string GreetMessage { get; set; }
        public bool IsPlatinium { get; set; }

        public Customer()
        {
            IsPlatinium = false;
        }

        public string GreetAndCombineNames(string FirstName, string LastName)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                throw new ArgumentException("Empty FirstName");
            }
            //return FirstName + LastName;
            GreetMessage =  $"Hello, {FirstName} {LastName}";
            discount = 20;
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PlatiniumCustomer();
        }
    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatiniumCustomer : CustomerType { }
}
