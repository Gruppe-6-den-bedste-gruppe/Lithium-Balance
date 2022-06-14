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
        //* vi definere hvad connectionstríng er.
        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06
            //*Vi opretter en create metode som indholder (BMStype og BMSversion)
        public BMS CreateBMS(string BMSType, string BMSVersion)
            //*Udføre en stans som hedder bms, hvor vi opretter en ny bms, som indholder (BMStyoer og BMSVersion)
        {
            BMS bms = new BMS(BMSType, BMSVersion);
            //* vi retunere instansen.
            return bms;
        }
        //*Vi opretter en save metode, med bms.hvor metoden kalder på intansen som er bms her.
        public void SaveBMS(BMS bms)
        {
            //*Vi opretter en ny conneciton via sqlconnection via hjælp af connectionstring som er defineret ovenoever.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //*  vi instanser command, som opretter vi en ny sql command.hvor sql command bruger "Insert into BMS" hvor vi angiver nogen parameterene (bmsType,bmsVersion), hvor vi så bruger "VALUES" hvor vi insætter vores værdier) hvor slutter med en ny sql connection.  
                SqlCommand command = new SqlCommand("INSERT INTO BMS (bmsType, bmsVersion)" + "VALUES(@BMSType, @BMSVersion)", connection);
                //* Vi vil gerne tilføje en value til  @BMSType og den henter informationer fra bms.BMSType
                command.Parameters.AddWithValue("@BMSType", bms.BMSType);
                //* Vi vil gerne tilføje en value til  @BMSVersion og den henter informationer fra bms.BMSVersion
                command.Parameters.AddWithValue("@BMSVersion", bms.BMSVersion);
                //* så går vi ind i databasen
                connection.Open();
                //* så execute vi det vil sige at vi tilføje values
                command.ExecuteNonQuery();
                //* vi lukker databasen 
                connection.Close();
                //* hej ahmed
            }
        }

    }
}