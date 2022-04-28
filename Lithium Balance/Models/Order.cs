using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class Order
    {
        private Order order;

        public int OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Receiver { get; set; }
        public string LicenseDuration { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public string BMSType { get; set; }
        public string SoftwareType { get; set; }
        public string SoftwareVersion { get; set; }

        public void Parse(string line)
        {
            string[] data = line.Split(';');
            OrderNumber = int.Parse(data[0]);
            CompanyName = data[1];
            Receiver = data[2];
            LicenseDuration = data[3];
            OrderDate = DateTime.Parse(data[4]);
            Email = data[5];
            BMSType = data[6];
            SoftwareVersion = data[7];
        }

        public string Format()
        {
            return $"{OrderNumber};{CompanyName};{Receiver};{LicenseDuration};{OrderDate};{Email};{BMSType};{SoftwareVersion}";
        }
    }
}
