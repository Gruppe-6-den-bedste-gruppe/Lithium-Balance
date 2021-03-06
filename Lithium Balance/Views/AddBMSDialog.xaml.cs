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

namespace Lithium_Balance.Views
{
    /// <summary>
    /// Interaction logic for AddBMSDialog.xaml
    /// </summary>
    public partial class AddBMSDialog : Window
    {
        private readonly BMSViewModel bMSViewModel = new();
        public AddBMSDialog()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bMSViewModel.SaveBMS(bMSViewModel.CreateBMS(ABBMSType.Text, ABBMSVersion.Text));
            DialogResult = true;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        
    }
}
