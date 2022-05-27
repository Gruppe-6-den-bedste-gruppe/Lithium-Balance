using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Lithium_Balance.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;





namespace Lithium_Balance.ViewModels
{
    public class MainWindowViewModel
    {
        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";        
        public List<Order> OrdersList = new();
        public ObservableCollection<Order> OrdersCollection = new();
      
        public MainWindowViewModel()
        {
            OrdersCollection = new ObservableCollection<Order>(OrdersList);
            ShowOrders();
            for (int i = 0; i < OrdersList.Count; i++)
            {
                OrdersCollection.Add(OrdersList[i]);
            }
        }


       

        


        public bool IsDbConnected()
        {
            string connectionStringLowTimeout = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06;Connect Timeout=1";
            using SqlConnection con = new SqlConnection(connectionStringLowTimeout);
            try
            {
                con.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }


        public List<Order> ShowOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select orderNumber, date, licenseDuration, companyName, Email, Address, bmsType, bmsVersion, softwareType, softwareVersion from orders join customer on customer.customerID = orders.customerID join bms on bms.bmsID = orders.bmsID join software on software.softwareID = orders.softwareID", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        Order order = new();
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