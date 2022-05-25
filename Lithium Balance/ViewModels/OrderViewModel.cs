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
        //    public event PropertyChangedEventHandler PropertyChanged;

        //    protected void NotifyPropertyChanged(string propertyName)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //    //Missing (null)? correction, refference: Jan video: "Databind 4 - XAML to Object2.mp4"


        //    public OrderViewModel()
        //    {
        //    }

        //    public ObservableCollection<BMS> GetBMS { get; set; }
        //    public ObservableCollection<Customer> GetCustomer { get; set; }
        //    public ObservableCollection<Software> GetSoftware { get; set; }


        //    /*
        //    ==================================================================================================================
        //                                   DATABASE "CreateOrder" and "SaveOrder" from SQL Table
        //    ==================================================================================================================
        //    */

        //    private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";

        //    public Order CreateOrder(string OrderNumber, string CompanyName, string Email, string BMSType,string BMSVersion, string SoftwareVersion, string SoftwareType, string LicenseDuration, string Address, string Date)
        //    {
        //        Order order = new Order(OrderNumber, CompanyName, Email, BMSType, BMSVersion, SoftwareVersion, SoftwareType, LicenseDuration , Address, Date);

        //        return order;
        //    }

        //    public void SaveOrder(Order order)
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {

        //            SqlCommand command = new SqlCommand("INSERT INTO orders (orderNumber, licenseDuration, date)" +
        //                " VALUES(@orderNumber, @licenseDuration , @date)" + " Insert into Customer (companyName, email, address)"
        //                + " VALUES(@companyName, @email, @address)" + " insert into bms (bmsType, bmsVersion)" + " VALUES(@bmsType, @bmsVersion)"
        //                + " Insert Into software (softwareType, softwareVersion)" + " VALUES(@softwareType, @softwareVersion)" ,connection);
        //            command.Parameters.AddWithValue("@orderNumber", order.OrderNumber);
        //            command.Parameters.AddWithValue("@companyName", order.CompanyName);
        //            command.Parameters.AddWithValue("@email", order.Email);
        //            command.Parameters.AddWithValue("@bmsType", order.BMSType);
        //            command.Parameters.AddWithValue("@bmsVersion", order.BMSVersion);
        //            command.Parameters.AddWithValue("@softwareVersion", order.SoftwareVersion);
        //            command.Parameters.AddWithValue("@softwareType", order.SoftwareType);
        //            command.Parameters.AddWithValue("@licenseDuration", order.LicenseDuration);
        //            command.Parameters.AddWithValue("@address", order.Address);
        //            command.Parameters.AddWithValue("@date", order.Date);

        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            connection.Close();

        //        }
        //    }

        public OrderViewModel()
        {
            return;
        }

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

        public string ToSql()
        {
            return $"{OrderNumber},'{CompanyName}','{LicenseDuration},'{Date},'{Email},'{Address},'{BMSType},'{BMSVersion},'{SoftwareVersion},'{SoftwareType}";
        }
        public Order ToOrders()
        {
            return new Order(OrderNumber,CompanyName, Email,BMSType,BMSVersion,SoftwareVersion,SoftwareType,LicenseDuration,Address,Date);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
