using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class OrderInfo
    {
        public string OrderNumber { get; set; }
        public string Date { get; set; }
        public string LicenseDuration { get; set; }

        public OrderInfo(string orderNo, string date, string licenseDuration )
        {
            OrderNumber = orderNo;
            Date = date;
            LicenseDuration = licenseDuration;
        }

        public OrderInfo()
        {
        }
    }
}
