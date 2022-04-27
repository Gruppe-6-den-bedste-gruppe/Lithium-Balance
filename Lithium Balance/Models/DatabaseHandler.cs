using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;




namespace Lithium_Balance.Models
{
    public class DatabaseHandler
    {
        public List<Order> Orders = new List<Order>();
        private string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";

        public bool IsDbConnected()
        {
            string connectionStringLowTimeout = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06;Connect Timeout=1";
            using (SqlConnection con = new SqlConnection(connectionStringLowTimeout))
            {
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
        }


        public List<Order> GetOrderInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT OrderNo, Date, CompanyName, Receiver, Email, BMSType, SoftwareVersion, LicensDuration FROM Order", connection);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Order order = new Order();
                        order.OrderNumber = dr["OrderNo"].ToString();
                        order.OrderDate = DateTime.Parse(dr["Date"].ToString());
                        order.CompanyName = dr["CompanyName"].ToString();
                        order.Receiver = dr["Receiver"].ToString();
                        order.Email = dr["Email"].ToString();
                        order.BMSType = dr["BMSType"].ToString();
                        order.SoftwareVersion = dr["SoftwareVersion"].ToString();
                        order.LicensDuration = dr["LicensDuration"].ToString();

                        Orders.Add(order);

                    }
                }
            }
            return Orders;
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
                command.Parameters.AddWithValue("@LicensDuration", order.LicensDuration);

                connection.Close();

            }
        }
    }
}