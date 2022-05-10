using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Models;
using System.Data.SqlClient;

namespace Lithium_Balance.ViewModels
{
    internal class OrderViewModel
    {
        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";
        public Order CreateOrder(string OrderNumber, string CompanyName, string Receiver, string Email, string BMSType,string BMSVersion, string SoftwareVersion, string SoftwareType, string LicenseDuration, string Address, string Date)
        {
            Order order = new Order(OrderNumber, CompanyName, Receiver, Email, BMSType, BMSVersion, SoftwareVersion, SoftwareType, LicenseDuration , Address, Date);
            
            return order;
        }

        public void SaveOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("INSERT INTO Orders (OrderNo, CompanyName, Receiver, Email, BMSType, BMSVersion, SoftwareVersion, SoftwareType, LicenseDuration, Address, Date)" +
                    "VALUES(@OrderNo, @CompanyName, @Receiver, @Email, @BMSType, @BMSVersion, @SoftwareVersion,@SoftwareType , @LicenseDuration , @Address, @Date)", connection);
                command.Parameters.AddWithValue("@OrderNo", order.OrderNumber);
                command.Parameters.AddWithValue("@CompanyName", order.CompanyName);
                command.Parameters.AddWithValue("@Receiver", order.Receiver);
                command.Parameters.AddWithValue("@Email", order.Email);
                command.Parameters.AddWithValue("@BMSTYpe", order.BMSType);
                command.Parameters.AddWithValue("@BMSVersion", order.BMSVersion);
                command.Parameters.AddWithValue("@SoftwareVersion", order.SoftwareVersion);
                command.Parameters.AddWithValue("@SoftwareType", order.SoftwareType);
                command.Parameters.AddWithValue("@LicenseDuration", order.LicenseDuration);
                command.Parameters.AddWithValue("@Address", order.Address);
                command.Parameters.AddWithValue("@Date", order.Date);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

    }
}
