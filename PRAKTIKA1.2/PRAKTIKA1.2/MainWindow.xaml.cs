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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PRAKTIKA1._2.DataSet1TableAdapters;

namespace PRAKTIKA1._2
{
    public partial class MainWindow : Window
    {
        private CustomersTableAdapter customersTableAdapter;
        public MainWindow()
        {
            InitializeComponent();
            customersTableAdapter = new CustomersTableAdapter();
            grid_customer.ItemsSource = customersTableAdapter.GetData();
            

        }

        private void but1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(MainWindow));

        }
        private void but2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page1());
        }

        private void but3(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page2());
        }
    }
}
