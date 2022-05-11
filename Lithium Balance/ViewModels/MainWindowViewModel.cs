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
        public List<Order> OrdersList = new();
        public ObservableCollection<Order> OrdersCollection = new();


        public MainWindowViewModel()
        {
            OrdersCollection = new ObservableCollection<Order>(OrdersList);
            GetOrderInfo();
            for (int i = 0; i < OrdersList.Count; i++)
            {
                OrdersCollection.Add(OrdersList[i]);
            }
        }


        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";

        


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


        public List<Order> GetOrderInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT OrderNumber, Date, CompanyName, Receiver, Email, Address, BMSType, BMSVersion, SoftwareVersion, SoftwareType, LicenseDuration FROM Orders, Customer, BMS, Software", connection);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Order order = new Order();
                        order.OrderNumber = dr["OrderNo"].ToString();
                        order.Date = dr["Date"].ToString();
                        order.CompanyName = dr["CompanyName"].ToString();
                        order.Receiver = dr["Receiver"].ToString();
                        order.Email = dr["Email"].ToString();
                        order.Address = dr["Address"].ToString();
                        order.BMSType = dr["BMSType"].ToString();
                        order.BMSVersion = dr["BMSVersion"].ToString();
                        order.SoftwareType = dr["SoftwareType"].ToString();
                        order.SoftwareVersion = dr["SoftwareVersion"].ToString();
                        order.LicenseDuration = dr["LicenseDuration"].ToString();

                        OrdersList.Add(order);

                    }
                }
            }
            return OrdersList;
        }
    }
}