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
        private OrderViewModel orderViewModel = new();
        //private readonly MainWindowViewModel mvm = new();
        //public string SelectedValue { get; set; }

        public ObservableCollection<BMS> GetBMS { get; set; }
        public ObservableCollection<Customer> GetCustomer { get; set; }
        public ObservableCollection<Software> GetSoftware { get; set; }


        public BMS SelectedBMS { get; set; }
        public Customer SelectedCustomer { get; set; }
        public Software SelectedSoftware { get; set; }
        
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

            GetBMS = new ObservableCollection<BMS>();
            GetCustomer = new ObservableCollection<Customer>();
            GetSoftware = new ObservableCollection<Software>();
            InitializeComponent();
            DataContext = this;


        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            orderViewModel.SaveOrder(orderViewModel.CreateOrder(OrderNumber.Text, CompanyName.Text, Email.Text, BMSType.Text, BMSVersion.Text, SoftwareType.Text, SoftwareVersion.Text, LicenseDuration.Text, Address.Text, Date.ToString()));
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
