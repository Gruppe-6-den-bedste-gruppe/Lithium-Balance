using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Models;
using System.Data.SqlClient;

namespace Lithium_Balance.ViewModels
{
    internal class CustomerViewModel
    {
        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";
        public Customer CreateCustomer(string CompanyName, string Email, string Address)
        {
            Customer customer = new Customer(CompanyName, Email, Address);

            return customer;
        }

        public void SaveCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("INSERT INTO Customer (CompanyName, Email, Address)" +
                    "VALUES(@CompanyName, @Email, @Address)", connection);
                command.Parameters.AddWithValue("@CompanyName", customer.CompanyName );
                command.Parameters.AddWithValue("@Email", customer.Email);
                command.Parameters.AddWithValue("@Receiver", customer.Address);
                
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

    }
}
