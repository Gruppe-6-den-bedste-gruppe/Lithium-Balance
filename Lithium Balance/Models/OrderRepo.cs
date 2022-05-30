using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lithium_Balance.Models
{
    public class OrderRepo
    {
        private readonly Database db;

        private List<Order> OrderList;


        private OrderRepo() // Constructor er private så man ikke kan lave flere instanser af OrderRepo.
        {
            OrderList = new List<Order>();
            using (SqlConnection connection = new(db.connectionString))
            {
                connection.Open();
                string values = "orderNumber, companyName, email, bmsType, bmsVersion, softwareVersion, softwareType, licenseDuration, address, date";
                string table = "orders";
                string CommandText = $"SELECT {values} FROM {table}";
                SqlCommand sQLCommand = new(CommandText, connection);
                using (SqlDataReader sqldatareader = sQLCommand.ExecuteReader())
                {
                    while (sqldatareader.Read() != false)
                    {
                        string OrderNumber = sqldatareader.GetString("orderNumber");
                        string CompanyName = sqldatareader.GetString("companyName");
                        string Email = sqldatareader.GetString("email");
                        string BMSType = sqldatareader.GetString("bmsType");
                        string BMSVersion = sqldatareader.GetString("bmsVersion");
                        string SoftwareVersion = sqldatareader.GetString("softwareVersion");
                        string SoftwareType = sqldatareader.GetString("softwareType");
                        string LicenseDuration = sqldatareader.GetString("licenseDuration");
                        string Address = sqldatareader.GetString("address");
                        string Date = sqldatareader.GetString("date");





                        Order order = new(OrderNumber,CompanyName,Email,BMSType,BMSVersion,SoftwareVersion,SoftwareType,LicenseDuration,Address,Date);
                        OrderList.Add(order);
                    }
                }
            }
        }

        public Order Create(string OrderNumber, string CompanyName, string Email, string BMSType, string BMSVersion, string SoftwareVersion, string SoftwareType, string LicenseDuration, string Address, string Date)
        {
            Order order;

            using (SqlConnection connection = new(db.connectionString))
            {
                connection.Open();

                string table = "orders";
                string coloumns = "orderNumber, companyName, email, bmsType, bmsVersion, softwareVersion, softwareType, licenseDuration, address, date";
                string values = "@orderNumber, @companyName, @email, @bmsType, @bmsVersion, @softwareVersion, @softwareType, @licenseDuration, @address, @date";
                string query = $"INSERT INTO {table} ({coloumns}) VALUES ({values}); SELECT SCOPE_IDENTITY()";

                SqlCommand sqlCommand = new(query, connection);

                sqlCommand.Parameters.Add(new SqlParameter("orderNumber", OrderNumber));
                sqlCommand.Parameters.Add(new SqlParameter("companyName", CompanyName));
                sqlCommand.Parameters.Add(new SqlParameter("email", Email));
                sqlCommand.Parameters.Add(new SqlParameter("bmsType", BMSType));
                sqlCommand.Parameters.Add(new SqlParameter("bmsVersion", BMSVersion));
                sqlCommand.Parameters.Add(new SqlParameter("softwareVersion", SoftwareVersion));
                sqlCommand.Parameters.Add(new SqlParameter("softwareType", SoftwareType));
                sqlCommand.Parameters.Add(new SqlParameter("licenseDuration", LicenseDuration));
                sqlCommand.Parameters.Add(new SqlParameter("address", Address));
                sqlCommand.Parameters.Add(new SqlParameter("date", Date));

                order = new(OrderNumber, CompanyName, Email, BMSType, BMSType, SoftwareVersion, SoftwareType, LicenseDuration, Address, Date);
            }

            return order;
        }

        public List<Order> GetAll()
        {
            return OrderList;
        }

    }
}
