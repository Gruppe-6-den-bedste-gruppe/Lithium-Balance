using System;
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
using Lithium_Balance.ViewModels;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace Lithium_Balance.Views
{
    public partial class AddOrderDialog : Window
    {
        

        public string SelectedCompanyName { get; set; }           // Solution --> SelectedCompanyName.. etc, som har en getter metode til den fx. "GetCompanyName"
        public string SelectedCompanyEmail { get; set; }            //... Fra Customer tabellen.
        public string SelectedBMSType { get; set; }
        public string SelectedBMSVersion { get; set; }
        public string SelectedSoftwareType { get; set; }
        public string SelectedSoftwareVersion { get; set; }
        

        private OrderViewModel orderViewModel = new();
        
        public OrderViewModel OrderViewModel
        {
            get
            {
                return orderViewModel;
            }
            set
            {
                orderViewModel = value;
            }
        }
        public AddOrderDialog()
        {
            InitializeComponent();
            DataContext = OrderViewModel;    // View --> ViewModel
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCompanyName = CompanyName.Text;
            SelectedCompanyEmail = Email.Text;
            SelectedBMSType = BMSType.Text;
            SelectedBMSVersion = BMSVersion.Text;
            SelectedSoftwareType = SoftwareType.Text;
            SelectedSoftwareVersion = SoftwareVersion.Text;

        }
       
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        /*
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            orderViewModel.SaveOrder(orderViewModel.CreateOrder(OrderNumber.Text, CompanyName.Text, Email.Text, BMSType.Text, BMSVersion.Text, SoftwareType.Text, SoftwareVersion.Text, LicenseDuration.Text, Address.Text, Date.ToString()));
            DialogResult = true;
        }
        */
    }
    
}
