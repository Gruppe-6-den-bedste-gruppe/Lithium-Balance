using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Models;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Lithium_Balance.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Order> OrderList { get; set; }
        

        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string LicenseDuration { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BMSType { get; set; }
        public string BMSVersion { get; set; }
        public string SoftwareVersion { get; set; }
        public string SoftwareType { get; set; }

        

        public OrderViewModel(Order order)
        {
            OrderNumber = order.OrderNumber;
            CompanyName = order.CompanyName;
            LicenseDuration = order.LicenseDuration;
            Date = order.Date;
            Email = order.Email;
            Address = order.Address;
            BMSType = order.BMSType;
            BMSVersion = order.BMSVersion;
            SoftwareVersion = order.SoftwareVersion;
            SoftwareType = order.SoftwareType;
        }

        public OrderViewModel()
        {
        }

        public OrderViewModel( string OrderNumber, string CompanyName, string LicenseDuration, string Date, string Email, string Address, string BMSType, string BMSVersion, string SoftwareType, string SoftwareVersion)
        {
            this.OrderNumber = OrderNumber;
            this.CompanyName = CompanyName;
            this.LicenseDuration = LicenseDuration;
            this.Date = Date;
            this.Email = Email;
            this.Address = Address;
            this.BMSType = BMSType;
            this.BMSVersion = BMSVersion;
            this.SoftwareType = SoftwareType;
            this.SoftwareVersion = SoftwareVersion;

        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
