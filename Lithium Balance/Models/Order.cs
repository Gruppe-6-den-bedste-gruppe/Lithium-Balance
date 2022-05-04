using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class Order : IPersistable
    {
        private string orderNumber;

        public int OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Receiver { get; set; }
        public string LicenseDuration { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string BMSType { get; set; }
        public string SoftwareVersion { get; set; }

        public Order(int orderNumber, string companyName, string receiver, string licenseDuration, DateTime date, string email, string bmsType, string softwareVersion)
        {
            OrderNumber = orderNumber;
            CompanyName = companyName;
            Receiver = receiver;
            LicenseDuration = licenseDuration;
            Date = date;
            Email = email;
            BMSType = bmsType;
            SoftwareVersion = softwareVersion;
        }

        public Order(string orderNumber, string companyName, string receiver, string email, string bMSType, string softwareVersion)
        {
            this.orderNumber = orderNumber;
            CompanyName = companyName;
            Receiver = receiver;
            Email = email;
            BMSType = bMSType;
            SoftwareVersion = softwareVersion;
        }

        public Order()
        {
        }

        public void Parse(string line)
        {
            string[] data = line.Split(';');
            OrderNumber = int.Parse(data[0]);
            CompanyName = data[1];
            Receiver = data[2];
            LicenseDuration = data[3];
            Date = DateTime.Parse(data[4]);
            Email = data[5];
            BMSType = data[6];
            SoftwareVersion = data[7];
        }

        public string Format()
        {
            return $"{OrderNumber};{CompanyName};{Receiver};{LicenseDuration};{Date};{Email};{BMSType};{SoftwareVersion}";
        }
    }
}
