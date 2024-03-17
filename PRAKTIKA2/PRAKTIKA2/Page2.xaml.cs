using PRAKTIKA2.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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

namespace PRAKTIKA2
{
    
    public partial class Page2 : Page
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public Page2()
        {
            InitializeComponent();
            grid_orders.ItemsSource = orders.GetData();
            
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1()); ;
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void Dob2(object sender, RoutedEventArgs e)
        {
            int customerId = int.Parse(CustomerID.Text);
            int productId = int.Parse(ProductID.Text);
            DateTime orderDate = DateTime.Parse(OrderDate.Text);
            int quantity = int.Parse(Quantity.Text);

            string orderDateString = orderDate.ToString("yyyy-MM-dd HH:mm:ss");

            orders.InsertQuery(customerId, productId, orderDateString, quantity);
            grid_orders.ItemsSource = orders.GetData();
        }

        private void Del2(object sender, RoutedEventArgs e)
        {
            if (grid_orders.SelectedItem != null)
            {
                object CustomerID = (grid_orders.SelectedItem as DataRowView).Row[0];
                orders.DeleteQuery(Convert.ToInt32(CustomerID));
                grid_orders.ItemsSource = orders.GetData();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Izm2(object sender, RoutedEventArgs e)
        {
            
        }

     
    }
}
