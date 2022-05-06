using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Views;
using Lithium_Balance.Models;

namespace Lithium_Balance.Models
{
    public class Software
    {

        public string SoftwareType { get; set; }
        public string SoftwareVersion { get; set; }

        public Software(string softwareType, string softwareVersion)
        {
            SoftwareType = softwareType;
            SoftwareVersion = softwareVersion;

        }

        public void Parse(string line)
        {
            string []data = line.Split(';');
            SoftwareType = data[0];
            SoftwareVersion = data[1];

        }

        public string Format()
        {
            return $"{SoftwareType};{SoftwareVersion}";
        }
    }

}
