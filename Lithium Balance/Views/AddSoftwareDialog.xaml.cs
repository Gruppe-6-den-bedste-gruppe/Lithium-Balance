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
    /// Interaction logic for AddSoftwareDialog.xaml
    /// </summary>
    public partial class AddSoftwareDialog : Window
    {
        private readonly SoftwareViewModel softwareViewModel = new();
        public AddSoftwareDialog()
        {
            InitializeComponent();
            DataContext = softwareViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            softwareViewModel.SaveSoftware(softwareViewModel.CreateSoftware(ASSoftwareType.Text, ASSoftwareVersion.Text));
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
