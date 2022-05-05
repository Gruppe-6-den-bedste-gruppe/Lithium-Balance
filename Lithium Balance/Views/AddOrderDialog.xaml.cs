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

namespace Lithium_Balance.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        private readonly DatabaseHandler databaseHandler;
        private readonly OrderViewModel orderViewModel;
        
        
        public AddOrder()
        {
            DataContext = orderViewModel;
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order = orderViewModel.CreateOrder(AOOrderNumber.Text, AOCompanyName.Text, AOReceiver.Text, AOEmail.Text, AOBMSType.Text, AOSoftwareVersion.Text,AOSoftwareType.Text, AOLicenseDuration.Text);
            databaseHandler.SaveOrder(order);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
