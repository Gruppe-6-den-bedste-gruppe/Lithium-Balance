using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Models;

namespace Lithium_Balance.ViewModels
{
    internal class OrderViewModel
    {
        private readonly Order order;
        public Order CreateOrder(string OrderNumber, string CompanyName, string Receiver, string Email, string BMSType, string SoftwareVersion, string SoftwareType, string LicenseDuration, string adress, string date)
        {
            Order order = new Order(OrderNumber, CompanyName, Receiver, Email, BMSType, SoftwareVersion, SoftwareType, LicenseDuration ,adress, date);
            
            return order;
        }
        
        
        
    }
}
