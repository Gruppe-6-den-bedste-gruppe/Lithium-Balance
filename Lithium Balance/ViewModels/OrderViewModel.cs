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


        public OrderViewModel(string OrderNumber, string CompanyName, string LicenseDuration, string Date, string Email, string Address, string BMSType, string BMSVersion, string SoftwareType, string SoftwareVersion)
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


        public List<Order> OrdersList = new();
        public ObservableCollection<Order> OrdersCollection = new();


        public OrderViewModel()
        {
            OrdersCollection = new ObservableCollection<Order>(OrdersList);
            GetOrderInfo();
            for (int i = 0; i < OrdersList.Count; i++)
            {
                OrdersCollection.Add(OrdersList[i]);
            }
        }
        private readonly string connectionString = $"Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";
        public List<Order> GetOrderInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select orderNumber, date, licenseDuration, companyName, Email, Address, bmsType, bmsVersion, softwareType, softwareVersion from orders join customer on customer.customerID = orders.customerID join bms on bms.bmsID = orders.bmsID join software on software.softwareID = orders.softwareID", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        Order order = new Order();
                        order.OrderNumber = dr["orderNumber"].ToString();
                        order.Date = dr["date"].ToString();
                        order.CompanyName = dr["companyName"].ToString();
                        order.Email = dr["email"].ToString();
                        order.Address = dr["address"].ToString();
                        order.BMSType = dr["bmsType"].ToString();
                        order.BMSVersion = dr["bmsVersion"].ToString();
                        order.SoftwareType = dr["softwareType"].ToString();
                        order.SoftwareVersion = dr["softwareVersion"].ToString();
                        order.LicenseDuration = dr["licenseDuration"].ToString();

                        OrdersList.Add(order);
                    }
                }
                return OrdersList;
            }
        }
    }
        

}

