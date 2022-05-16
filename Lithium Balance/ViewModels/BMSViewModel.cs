using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Models;
using System.Data.SqlClient;

namespace Lithium_Balance.ViewModels
{
    internal class BMSViewModel
    {
        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";
        
        public BMS CreateBMS(string BMSType, string BMSVersion)
        {
            BMS bms = new BMS(BMSType, BMSVersion);

            return bms;
        }

        public void SaveBMS(BMS bms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("INSERT INTO BMS (bmsType, bmsVersion)" + "VALUES(@BMSType, @BMSVersion)", connection);
                command.Parameters.AddWithValue("@BMSType", bms.BMSType);
                command.Parameters.AddWithValue("@BMSVersion", bms.BMSVersion);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

    }
}