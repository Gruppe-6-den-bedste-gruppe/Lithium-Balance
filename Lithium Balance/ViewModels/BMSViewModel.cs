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


        //public ObservableCollection<BMS> BMSList { get; set; }


        //private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";
        //public BMS CreateBMS(string bmsID,string BMSType, string BMSVersion)
        //{
        //    BMS bms = new BMS(bmsID,BMSType, BMSVersion);

        //    return bms;
        //}

        //public void SaveBMS(BMS bms)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {

        //        SqlCommand command = new SqlCommand("INSERT INTO BMS (bmsType, bmsVersion)" + "VALUES(@BMSType, @BMSVersion)", connection);
        //        command.Parameters.AddWithValue("@BMSType", bms.BMSType);
        //        command.Parameters.AddWithValue("@BMSVersion", bms.BMSVersion);

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //        connection.Close();

        //    }
        //}


        public BMSViewModel()
        {
            return;
        }

        public BMSViewModel(BMS bms)
        {
            bmsID = bms.bmsID;
            BMSType = bms.BMSType;
            BMSVersion = bms.BMSVersion;

        }

        private string bmsID { get; set; }
        public string BMSType { get; set; }
        public string BMSVersion { get; set; }

        public string ToSql()
        {
            return $"{bmsID},'{BMSType}','{BMSVersion}";
        }
        public BMS ToBMS()
        {
            return new BMS(bmsID,BMSType,BMSVersion);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}