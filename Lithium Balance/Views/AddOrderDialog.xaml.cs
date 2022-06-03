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
using Lithium_Balance.Views;
using Lithium_Balance.ViewModels;
using Lithium_Balance.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace Lithium_Balance.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddOrderDialog : Window
    {
        //private OrderViewModel orderViewModel;
        public ObservableCollection<OrderViewModel> OrderViewModel { get; set; }
        private OrderViewModel OVM;

        //private readonly MainWindowViewModel mvm = new();
        //public string SelectedValue { get; set; }




        public AddOrderDialog()
        {
            OVM = new OrderViewModel();
            InitializeComponent();
            DataContext = OVM; //Binding View til Viewmodel. Hvis vi benyttede DataContex = this; er det fra View til View Binding
            CompanyName.ItemsSource = OVM.OrdersCollection;
            BMSType.ItemsSource = OVM.OrdersCollection;
            BMSVersion.ItemsSource = OVM.OrdersCollection;
            SoftwareType.ItemsSource = OVM.OrdersCollection;
            SoftwareVersion.ItemsSource = OVM.OrdersCollection;



        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            //OrderViewModel.SaveOrder(OrderViewModel.CreateOrder(OrderNumber.Text, CompanyName.Text, Email.Text, BMSType.Text, BMSVersion.Text, SoftwareType.Text, SoftwareVersion.Text, LicenseDuration.Text, Address.Text, Date.ToString()));
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
