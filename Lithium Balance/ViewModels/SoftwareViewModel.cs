using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Models;
using System.Data.SqlClient;

namespace Lithium_Balance.ViewModels
{
    internal class SoftwareViewModel
    {
        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";
        public Software CreateSoftware(string SoftwareType, string SoftwareVersion)
        {
            Software software = new Software(SoftwareType, SoftwareVersion);

            return software;
        }

        public void SaveSoftware(Software software)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("INSERT INTO Software (@SoftwareType, @SoftwareVersion)", connection);
                command.Parameters.AddWithValue("@SoftwareType", software.SoftwareType);
                command.Parameters.AddWithValue("@SoftwareVersion", software.SoftwareVersion);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

    }
}