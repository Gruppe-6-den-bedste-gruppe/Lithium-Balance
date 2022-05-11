using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Views;
using Lithium_Balance.Models;

namespace Lithium_Balance.Models
{
    public class Customer
    {
        public String CompanyName { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }

        public Customer(string CompanyName, string Address, string Email)
        {
            this.CompanyName = CompanyName;
            this.Address = Address;
            this.Email = Email;
        }
    }
}
