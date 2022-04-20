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
    }
}