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
            for (int i = 0; i < OrdersList.Count; i++)
            {
                OrdersCollection.Add(new Order(OrdersList[i]));
            }
            OrdersCollection.Add(new Order(null));
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
                SqlCommand command = new SqlCommand("SELECT OrderNo, Date, CompanyName, Receiver, Email, BMSType, SoftwareVersion, LicenseDuration FROM Orders", connection);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Order order = new Order();
                        order.OrderNumber = (int)dr["OrderNo"];
                        order.OrderDate = (DateTime)(dr["Date"]);
                        order.CompanyName = dr["CompanyName"].ToString();
                        order.Receiver = dr["Receiver"].ToString();
                        order.Email = dr["Email"].ToString();
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
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Order (OrderNO, Date, CopmanyName, Receiver, Email, BMSType, SoftwareVersion, LicensDuration)" +
                    "VALUES(@OrderNO, @Date, @CopmanyName, @Receiver, @Email, @BMSType, @SoftwareVersion, @LicensDuration)", connection);
                command.Parameters.AddWithValue("@OrderNO", order.OrderNumber);
                command.Parameters.AddWithValue("@Date", order.OrderDate);
                command.Parameters.AddWithValue("@CopmanyName", order.CompanyName);
                command.Parameters.AddWithValue("@Recevier", order.Receiver);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@BMSTYpe", order.BMSType);
                command.Parameters.AddWithValue("@SoftwareVersion", order.SoftwareVersion);
                command.Parameters.AddWithValue("@LicensDuration", order.LicenseDuration);

                connection.Close();

            }
        }
    }
}