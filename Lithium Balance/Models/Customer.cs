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
    public class Customer : INotifyPropertyChanged
    {
        public String CompanyName { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }

        public Customer(string CompanyName, string Address, string Email)
        {
            this.CompanyName = CompanyName;
            this.Address = Address;
            this.Email = Email;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
