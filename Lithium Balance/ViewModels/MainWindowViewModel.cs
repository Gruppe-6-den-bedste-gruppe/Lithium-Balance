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
        OrderViewModel ovm = new OrderViewModel();
        MainWindowViewModel mWVM = new MainWindowViewModel();
        public List<Order> OrdersList = new();
        public ObservableCollection<Order> OrdersCollection = new();

        public MainWindowViewModel()
        {

            CreateOrderList();
            OrdersCollection = new ObservableCollection<Order>(OrdersList);
            
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


        public OrderInfo GetOrderInfo()
        {
            OrderInfo orderInfo = new();            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT orderNumber, date, licenseDuration FROM orders", connection);
                
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        
                        orderInfo.OrderNumber = dr["orderNumber"].ToString();
                        orderInfo.Date = dr["date"].ToString();
                        orderInfo.LicenseDuration = dr["licenseDuration"].ToString();


                        
                    }
                }
                connection.Close();
            }
            return orderInfo;
        }
        
        public Customer GetCustomer()
        {
            Customer customer = new();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CompanyName, Address, Email FROM Customer", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        customer.CompanyName = dr["CompanyName"].ToString();
                        customer.Address = dr["Address"].ToString();
                        customer.Email = dr["Email"].ToString();



                    }
                }
                connection.Close();

                return customer;
            }
        }
        
        public BMS GetBMS()
        {
            BMS bms = new();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT bmsType, bmsVersion FROM bms", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        bms.BMSType = dr["bmsType"].ToString();
                        bms.BMSVersion = dr["bmsVersion"].ToString();
                    }
                }
                connection.Close();

                return bms;
            }
        }
        
        public Software GetSoftware()
        {
            Software software = new();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT softwareType, softwareVersion FROM software", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        software.SoftwareType= dr["softwareType"].ToString();
                        software.SoftwareVersion= dr["softwareVersion"].ToString();
                    }
                }
                connection.Close();
            }
            return software;
        }
        public List<Order> CreateOrderList()
        {
            MainWindowViewModel mwvm = new();
            Order order = new();
            OrderViewModel ovm = new();
            order.CompanyName = mwvm.GetCustomer().CompanyName;
            order.Address = mwvm.GetCustomer().Address;
            order.Email = mwvm.GetCustomer().Email;
            order.BMSType = mwvm.GetBMS().BMSType;
            order.BMSVersion = mwvm.GetBMS().BMSVersion;
            order.SoftwareType = mwvm.GetSoftware().SoftwareType;
            order.SoftwareVersion = mwvm.GetSoftware().SoftwareVersion;
            order.LicenseDuration = mwvm.GetOrderInfo().LicenseDuration;
            order.Date = mwvm.GetOrderInfo().Date;
            order.OrderNumber = mwvm.GetOrderInfo().OrderNumber;
            ovm.CreateOrder(order.OrderNumber, order.CompanyName, order.Address, order.Email, order.BMSType, order.BMSVersion, order.SoftwareType, order.SoftwareVersion, order.LicenseDuration, order.Date);
            OrdersList.Add(order);
            return OrdersList;
        }
    }

   
}