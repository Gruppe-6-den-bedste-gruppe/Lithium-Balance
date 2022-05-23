using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Views;
using Lithium_Balance.Models;
using System.ComponentModel;

namespace Lithium_Balance.Models
{
    public class Software : INotifyPropertyChanged
    {

        public string SoftwareType { get; set; }
        public string SoftwareVersion { get; set; }

        public Software(string SoftwareType, string SoftwareVersion)
        {
            this.SoftwareType = SoftwareType;
            this.SoftwareVersion = SoftwareVersion;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
