﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Lithium_Balance.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;





namespace Lithium_Balance.ViewModels
{
    public class MainWindowViewModel
    {
        public List<Order> OrdersList = new();
        public ObservableCollection<Order> OrdersCollection = new();


        public MainWindowViewModel()
        {
            OrdersCollection = new ObservableCollection<Order>(OrdersList);
            GetOrderInfo();
            for (int i = 0; i < OrdersList.Count; i++)
            {
                OrdersCollection.Add(OrdersList[i]);
            }
        }


        private readonly string connectionString = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06";

        


        public bool IsDbConnected()
        {
            string connectionStringLowTimeout = "Server=10.56.8.36;Database=PEDB06;User Id=PE-06;Password=OPENDB_06;Connect Timeout=1";
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


        public List<Order> GetOrderInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT orderNumber, date, licenseDuration, companyName, email, address,  bmsType, bmsVersion, softwareVersion, softwareType FROM orders, Customer, BMS,   Software", connection);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Order order = new();
                        order.OrderNumber = dr["orderNumber"].ToString();
                        order.Date = dr["date"].ToString();
                        order.LicenseDuration = dr["licenseDuration"].ToString();
                        order.CompanyName = dr["companyName"].ToString();
                        order.Email = dr["email"].ToString();
                        order.Address = dr["address"].ToString();
                        order.BMSType = dr["bmsType"].ToString();
                        order.BMSVersion = dr["bmsVersion"].ToString();
                        order.SoftwareType = dr["softwareType"].ToString();
                        order.SoftwareVersion = dr["softwareVersion"].ToString();

                        OrdersList.Add(order);
                    }
                }
                connection.Close();
            }
            return OrdersList;
        }
    }
}