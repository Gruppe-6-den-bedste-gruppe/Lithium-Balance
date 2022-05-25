using Lithium_Balance.ViewModels; // Models --> ViewModels
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class OrderRepo
    {

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

        /*
        ==================================================================================================================
                                       DATABASE "CreateOrder" and "SaveOrder" from SQL Table
        ==================================================================================================================
        */

        
        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";

        public Order CreateOrder(string OrderNumber, string CompanyName, string Email, string BMSType,string BMSVersion, string SoftwareVersion, string SoftwareType, string LicenseDuration, string Address, string Date)
        {
            Order order = new Order(OrderNumber, CompanyName, Email, BMSType, BMSVersion, SoftwareVersion, SoftwareType, LicenseDuration , Address, Date);
            
            return order;
        }

        public void SaveOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("INSERT INTO orders (orderNumber, licenseDuration, date)" +
                    " VALUES(@orderNumber, @licenseDuration , @date)" + " Insert into Customer (companyName, email, address)"
                    + " VALUES(@companyName, @email, @address)" + " insert into bms (bmsType, bmsVersion)" + " VALUES(@bmsType, @bmsVersion)"
                    + " Insert Into software (softwareType, softwareVersion)" + " VALUES(@softwareType, @softwareVersion)" ,connection);
                command.Parameters.AddWithValue("@orderNumber", order.OrderNumber);
                command.Parameters.AddWithValue("@companyName", order.CompanyName);
                command.Parameters.AddWithValue("@email", order.Email);
                command.Parameters.AddWithValue("@bmsType", order.BMSType);
                command.Parameters.AddWithValue("@bmsVersion", order.BMSVersion);
                command.Parameters.AddWithValue("@softwareVersion", order.SoftwareVersion);
                command.Parameters.AddWithValue("@softwareType", order.SoftwareType);
                command.Parameters.AddWithValue("@licenseDuration", order.LicenseDuration);
                command.Parameters.AddWithValue("@address", order.Address);
                command.Parameters.AddWithValue("@date", order.Date);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }
        


    }
}
