using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Views;
using Lithium_Balance.Models;
using System.Data.SqlClient;
using Lithium_Balance.ViewModels;
using System.Data;

namespace Lithium_Balance.Models
{
    public class BMSRepo
    {

        private readonly Database db;
        private List<BMS> BMSList;

        private BMSRepo() // Constructor er private så man ikke kan lave flere instanser af BMSRepo.
        {
            BMSList = new List<BMS>();
            using (SqlConnection connection = new(db.connectionString))
            {
                connection.Open();
                string values = "bmsType, bmsVersion";
                string table = "bms";
                string CommandText = $"SELECT {values} FROM {table}";
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        string BMSType = sqldatareader.GetString("bmsType");
                        string BMSVersion = sqldatareader.GetString("bmsVersion");
                        BMS bms = new(BMSType, BMSVersion);
                        BMSList.Add(bms);
                    }
                }
            }
        }

        public BMS Create(string BMSType, string BMSVersion)
        {
            BMS bms;

            using (SqlConnection connection = new(db.connectionString))
            {
                connection.Open();

                string table = "bms";
                string coloumns = "bmsType, bmsVersion";
                string values = "@bmsType, @bmsVersion";
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("bmsType", BMSType));
                sqlCommand.Parameters.Add(new SqlParameter("bmsVersion", BMSVersion));

                bms = new(BMSType,BMSVersion);
            }

            return bms;
        }

        public List<BMS> GetAll()
        {
            return BMSList;
        }
    }
}

