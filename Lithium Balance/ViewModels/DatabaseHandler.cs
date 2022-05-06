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
    public class DatabaseHandler : INotifyPropertyChanged
    {
        public List<Order> OrdersList = new();
        public ObservableCollection<Order> OrdersCollection = new();


        public DatabaseHandler()
        {
            OrdersCollection = new ObservableCollection<Order>(OrdersList);
            GetOrderInfo();
            for (int i = 0; i < OrdersList.Count; i++)
            {
                OrdersCollection.Add(OrdersList[i]);
            }
            OrdersCollection.Add(null);
        }


        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(ObservableCollection<Order> orders)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrdersCollection)));
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


        public List<Order> GetOrderInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT OrderNo, Date, CompanyName, Receiver, Email, Address, BMSType, SoftwareVersion, LicenseDuration FROM Orders", connection);
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
                        order.SoftwareVersion = dr["SoftwareVersion"].ToString();
                        order.LicenseDuration = dr["LicenseDuration"].ToString();

                        OrdersList.Add(order);

                    }
                }
            }
            return OrdersList;
        }
        public void SaveOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand("INSERT INTO Orders (OrderNo, CompanyName, Receiver, Email, BMSType, SoftwareVersion, SoftwareType , LicenseDuration)" +
                    "VALUES(@OrderNo, @CompanyName, @Receiver, @Email, @BMSType, @SoftwareVersion,@SoftwareType , @LicenseDuration)", connection);
                command.Parameters.AddWithValue("@OrderNo", order.OrderNumber);
                command.Parameters.AddWithValue("@CompanyName", order.CompanyName);
                command.Parameters.AddWithValue("@Receiver", order.Receiver);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@BMSTYpe", order.BMSType);
                command.Parameters.AddWithValue("@SoftwareVersion", order.SoftwareVersion);
                command.Parameters.AddWithValue("@SoftwareType", order.SoftwareType);
                command.Parameters.AddWithValue("@LicenseDuration", order.LicenseDuration);
                command.Parameters.AddWithValue("@Adress", order.Address);
                command.Parameters.AddWithValue("@Date", order.Date);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}