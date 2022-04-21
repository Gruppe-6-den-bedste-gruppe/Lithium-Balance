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
        public string Email { get; set; }
        public string CompanyName { get; set; }

        public Customer(string email, string name)
        {
            Email = email;
            CompanyName = name;
        }

        public string Format()
        {
            return $"{Email};{CompanyName}";
        }
        
    }
}
