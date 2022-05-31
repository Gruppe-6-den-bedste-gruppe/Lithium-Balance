using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class Database
    {

        //"Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06"
        
        public string connectionString { get; set; }
        public string Db { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Host { get; set; }

        public Database(string User, string Pass, string Host, string Db)
        {
            User = "PE-06";
            Pass = "OPENDB_06";
            Host = "0.56.8.36";

            connectionString = $"Server{Host},user id={User},password={Pass},database={Db}";
        }

        public bool IsDbConnected()
        {
            string connectionStringLowTimeout = connectionString;
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



    }
}
