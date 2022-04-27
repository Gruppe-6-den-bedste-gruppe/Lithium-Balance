﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lithium_Balance.Models;
using Lithium_Balance.Views;
using System.IO;

namespace Lithium_Balance.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {       
            InitializeComponent();
        }

       
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerDialog dialog = new();

            dialog.ShowDialog();
        }

        private void AddBMS_Click(object sender, RoutedEventArgs e)
        {
            AddBMSDialog dialog = new();

            dialog.ShowDialog();
        }

        private void AddSoftware_Click(object sender, RoutedEventArgs e)
        {
            AddSoftwareDialog dialog = new();

            dialog.ShowDialog();
        }


        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderDialog dialog = new();

            dialog.ShowDialog();


        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrderDialog dialog = new();

            dialog.ShowDialog();
             
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHandler databaseHandler = new();
            databaseHandler.GetOrderInfo();
        }



        //private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        //{
        //    DeleteOrderDialog dialog = new();

        //    dialog.ShowDialog();
        //}
    }
}
