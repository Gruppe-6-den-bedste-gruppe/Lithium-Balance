using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Lithium_Balance.Models;

namespace Lithium_Balance.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {

        OrderRepo orderRepo = new OrderRepo();

        public ObservableCollection<BMS> GetBMS { get; set; }
        public ObservableCollection<Customer> GetCustomer { get; set; }   // Rename from GetCustomer to CustomerViewModel? / CustomerVM
        public ObservableCollection<Software> GetSoftware { get; set; }

        //public string SelectedCustomer { get; set; }         Skal ændres til "SelectedCompanyName" fra tabellen Customer.. Ellers ved WPF ikke
        //public string SelectedBMS { get; set; }               hvilket data der er selected, og skal opdateres
        //public string SelectedSoftware { get; set; }

        /*
        ================================================================================================================================================================================================================

        Hvordan adskiller vi "CompanyName" fra binding GetCustomer, som henter hele SQL Tabel?... Vi bliver vel nødt til at lave en "SelectedCompanyName" som refference til det objekt der bliver valgt i WPF vinduet.
        Eller kan man lave en GetCustomer.CompanyName?

        ================================================================================================================================================================================================================
        */

        public OrderViewModel()
        {
            GetBMS = new ObservableCollection<BMS>();
            GetCustomer = new ObservableCollection<Customer>();
            GetSoftware = new ObservableCollection<Software>();
        }





        #region
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
