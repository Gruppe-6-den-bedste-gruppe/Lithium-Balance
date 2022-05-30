﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.ViewModels;
using Lithium_Balance.Views;

namespace Lithium_Balance.Models
{
    public class Order : INotifyPropertyChanged
    {
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

        public Order(string OrderNumber, string CompanyName, string Email, string BMSType, string BMSVersion,string SoftwareVersion, string SoftwareType, string LicenseDuration, string Address, string Date)
        {
            this.OrderNumber = OrderNumber;
            this.CompanyName = CompanyName;
            this.Email = Email;
            this.BMSType = BMSType;
            this.BMSVersion = BMSVersion;
            this.SoftwareVersion = SoftwareVersion;
            this.SoftwareType = SoftwareType;
            this.LicenseDuration = LicenseDuration;
            this.Address = Address;
            this.Date = Date;
        }

        public Order()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
