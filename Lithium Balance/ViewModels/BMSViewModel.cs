using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithium_Balance.Models;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Lithium_Balance.ViewModels
{
    public class BMSViewModel : INotifyPropertyChanged
    {
        private readonly string connectionString = $"Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";
        public List<BMS> BMSList = new();

        public ObservableCollection<BMS> BMSCollection = new();


        public string BMSType { get; set; }
        public string BMSVersion { get; set; }

        public BMSViewModel()
        {
            BMSCollection = new ObservableCollection<BMS>(BMSList);
            GetBMSInfo();
            for (int i = 0; i < BMSList.Count; i++)
            {
                BMSCollection.Add(BMSList[i]);
            }
        }

        public List<BMS> GetBMSInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select bmsType, bmsVersion from orders join bms on bms.bmsID = orders.bmsID", connection);

                using (SqlDataReader dr = command.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        BMS bms = new BMS();
                        bms.BMSType = dr["bmsType"].ToString();
                        bms.BMSVersion = dr["bmsVersion"].ToString();
                        BMSList.Add(bms);
                    }
                }
                return BMSList;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}