using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class Order
    {
        public int  OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Receiver { get; set; }
        public string LicenseDuration { get; set; }
        public DateTime OrderDate { get; set; }
        public string Email { get; set; }
        public string BMSType { get; set; }
        public string SoftwareType { get; set; }
        public string SoftwareVersion { get; set; }
    }
}
