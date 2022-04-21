using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    internal class Order
    {

        public string FileStatus { get; set; }
        public float OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Receiver { get; set; }
        public string LicenseDuration { get; set; }
        public DateTime OrderDate { get; set; }


        public Order(string fileStatus,float orderNumber,string companyName,string receiver,string licensDuration, DateTime orderDate)
        {
            FileStatus = fileStatus;
            OrderNumber = orderNumber;
            CompanyName = companyName;
            Receiver = receiver;
            LicenseDuration = licensDuration;
            OrderDate = orderDate;

        }

        public override string ToString()
        {
            return $"{FileStatus},{OrderNumber},{CompanyName},{Receiver},{LicenseDuration},{OrderDate}";
        }
    }
}
