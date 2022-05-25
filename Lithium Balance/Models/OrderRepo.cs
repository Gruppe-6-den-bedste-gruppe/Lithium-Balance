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


        private Database db = new();
        private List<Order> orders = new();

        public OrderRepo()
        {
            orders = GetAllOrder();
        }

        public List<Order> GetAllOrder()
        {

            List<Order> result = new();
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
                          SELECT * FROM orders", connection);
                    using (SqlDataReader DR = sql.ExecuteReader())
                    {
                        while (DR.Read())
                        {
                            result.Add(new Order((string)DR[0], (string)DR[1], (string)DR[2], (string)DR[3], (string)DR[4], (string)DR[5], (string)DR[6], (string)DR[7], (string)DR[8], (string)DR[9]));
                        }
                    }
                }
                catch
                {

                    SqlCommand sql = new(@"
                            CREATE TABLE orders (
                                      orderNumber]    NVARCHAR (255) NULL,
                                      date]           NVARCHAR (255) NULL,
                                      licenseduration NVARCHAR (255) NULL,
                                      customerID      INT            NULL,
                                      responsibleID   INT            NULL,
                                      softwareID      INT            NULL,
                                      bmsID           INT            NULL, ", connection);
                    sql.ExecuteNonQuery();
                }
            }
            return result;

        }

        public bool Add(Order order)
        {
            bool result = false;

            using (SqlConnection connection = new(db.connectionString))
            {


                try
                {
                    connection.Open();
                    string saveOrder = @"
                        INSERT INTO orders (
                                   orderNumber     NVARCHAR (255) NULL,
                                   date            NVARCHAR (255) NULL,
                                   licenseduration NVARCHAR (255) NULL,
                                   customerID      INT            NULL,
                                   responsibleID   INT            NULL,
                                   softwareID      INT            NULL,
                                   bmsID           INT            NULL, 
                        ) VALUES ("; // VERBATIM STRING - SO CANT USE CONCATION TO JOIN SENTENCES - MIGHT USE REPLACE THO?
                    saveOrder += order.ToSql();
                    saveOrder += ");";
                    SqlCommand sql = new(saveOrder, connection);
                    sql.ExecuteNonQuery();
                    orders.Add(order.ToOrders());
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        public bool Add(OrderViewModel order)
        {
            bool result = false;
            // I DONT GET WHY YOU GET AN INT BACK? IS IT THE INDEX INSIDE OUR LIST?
            using (SqlConnection connection = new(db.connectionString))
            {
                try
                {
                    connection.Open();
                    string saveOrder = @"
                        INSERT INTO calipers (
                            bmsType,
                            bmsVersion,

                        ) VALUES ("; // VERBATIM STRING - SO CANT USE CONCATION TO JOIN SENTENCES - MIGHT USE REPLACE THO?
                    saveOrder += order.ToSql();
                    saveOrder += ");";
                    SqlCommand sql = new(saveOrder, connection);
                    sql.ExecuteNonQuery();
                    orders.Add(order.ToOrders());
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
