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
    public class BMS : INotifyPropertyChanged
    {

        public string BMSType { get; set; }
        public string BMSVersion { get; set; }

        public BMS(string BMSType, string BMSVersion)
        {
            this.BMSType = BMSType;
            this.BMSVersion = BMSVersion;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }

}
