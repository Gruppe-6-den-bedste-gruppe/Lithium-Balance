using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.ViewModels;
using Lithium_Balance.Views;

namespace Lithium_Balance.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string LicenseDuration { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BMSType { get; set; }
        public string BMSVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string SoftwareType { get; set; }

        public Order(string orderNumber, string companyName, string email, string bMSType, string bMSVersion,string softwareVersion, string softwareType, string licenseDuration, string address, string date)
        {
            OrderNumber = orderNumber;
            CompanyName = companyName;
            Email = email;
            BMSType = bMSType;
            BMSVersion = bMSVersion;
            SoftwareVersion = softwareVersion;
            SoftwareType = softwareType;
            LicenseDuration = licenseDuration;
            Address = address;
            Date = date;
        }

        public Order()
        {
        }
    }
}
