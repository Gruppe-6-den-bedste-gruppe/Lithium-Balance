using Lithium_Balance.ViewModels;  //  Models --> ViewModel
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Lithium_Balance.Models
{
    public class BMSRepo
    {


        public string bmsID { get; set; }
        public string BMSType { get; set; }
        public string BMSVersion { get; set; }


        private Database db = new();
        private List<BMS> bMS = new();

        public BMSRepo()
        {
            bMS = GetAllBMS();
        }

        public List<BMS> GetAllBMS()
        {

            List<BMS> result = new();
            if (db.connectionString is null)
            {
                return result;
            }
            using (SqlConnection connection = new(db.connectionString))
            {
                connection.Open();

                try
                {
                    SqlCommand sql = new(@"
                          SELECT * FROM bms", connection);
                    using (SqlDataReader DR = sql.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            result.Add(new BMS((string)DR[0], (string)DR[1], (string)DR[2]));
                        }
                    }
                }
                catch
                {

                    SqlCommand sql = new(@"
                            CREATE TABLE bms (
                                   bmsID INT  IDENTITY (1,1) IS NOT NULL,
                                   bmsType NVARCHAR,
                                   bmsVersion NVARCHAR) ", connection);
                    sql.ExecuteNonQuery();
                }
            }
            return result;

        }

        public bool Add(BMS bms)
        {
            bool result = false;

            using (SqlConnection connection = new(db.connectionString))
            {


                try
                {
                    connection.Open();
                    string saveBMS = @"
                        INSERT INTO bms (
                            bmsType,
                            bmsVersion,
                        ) VALUES ("; // VERBATIM STRING - SO CANT USE CONCATION TO JOIN SENTENCES - MIGHT USE REPLACE THO?
                    saveBMS += bms.ToSql();
                    saveBMS += ");";
                    SqlCommand sql = new(saveBMS, connection);
                    sql.ExecuteNonQuery();
                    bMS.Add(bms.ToBMS());
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        public bool Add(BMSViewModel bms)
        {
            bool result = false;
            // I DONT GET WHY YOU GET AN INT BACK? IS IT THE INDEX INSIDE OUR LIST?
            using (SqlConnection connection = new(db.connectionString))
            {
                try
                {
                    connection.Open();
                    string saveBMS = @"
                        INSERT INTO calipers (
                            bmsType,
                            bmsVersion,

                        ) VALUES ("; // VERBATIM STRING - SO CANT USE CONCATION TO JOIN SENTENCES - MIGHT USE REPLACE THO?
                    saveBMS += bms.ToSql();
                    saveBMS += ");";
                    SqlCommand sql = new(saveBMS, connection);
                    sql.ExecuteNonQuery();
                    bMS.Add(bms.ToBMS());
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        //public BMS GetById(int id)
        //{
        //    BMS result = null;
        //    using (SqlConnection connection = new(db.connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            string sqlString = "SELECT * FROM bms WHERE bms = " + id + ";";
        //            SqlCommand sql = new(sqlString, connection);
        //            using (SqlDataReader DR = sql.ExecuteReader())
        //            {
        //                while (DR.Read())
        //                {
        //                    result.Add(new BMS((string)DR[0], (string)DR[1], (string)DR[2]));
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            result = null;
        //        }
        //    }
        //    return result;
        //}
    }
}
