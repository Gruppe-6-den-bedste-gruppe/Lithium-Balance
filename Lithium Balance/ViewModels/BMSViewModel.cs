using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Models;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lithium_Balance.ViewModels
{
    public class BMSViewModel : INotifyPropertyChanged
    {


        public ObservableCollection<BMS> BMSList { get; set; }

        public BMSViewModel()
        {
            return;
        }

        public BMSViewModel(BMS bms)
        {
            BMSType = bms.BMSType;
            BMSVersion = bms.BMSVersion;

        }

        public string BMSType { get; set; }
        public string BMSVersion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}