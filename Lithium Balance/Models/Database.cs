using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class Database
    {

        public string connectionString { get; set; }
        public string Db { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Host { get; set; }

        public Database(string User = "", string Pass = "", string Host = "", string Db = "")
        {
            User = "PE-06";
            Pass = "OPENDB_06";
            Host = "0.56.8.36";

            connectionString = $"Server{Host},user id={User},password={Pass},database={Db}";
        }


     
    }
}
