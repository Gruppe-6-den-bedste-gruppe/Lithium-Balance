using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Views;
using Lithium_Balance.Models;

namespace Lithium_Balance.Models
{
    public class BMS
    {

        public string BMSType { get; set; }
        public string BMSVersion { get; set; }

        public BMS(string bmsType, string bmsVersion)
        {
            BMSType = bmsType;
            BMSVersion = bmsVersion;

        }

        public BMS()
        {
        }

        public void Parse(string line)
        {
            string[] data = line.Split(';');
            BMSType = data[0];
            BMSVersion = data[1];

        }

        public string Format()
        {
            return $"{BMSType};{BMSVersion}";
        }
    }

}
