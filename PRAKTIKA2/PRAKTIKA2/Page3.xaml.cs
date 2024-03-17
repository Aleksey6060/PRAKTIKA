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
    
    public partial class Page3 : Page
    {
        ProductsTableAdapter products = new ProductsTableAdapter();
        public Page3()
        {
            InitializeComponent();
            grid_products.ItemsSource = products.GetData();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Dob3(object sender, RoutedEventArgs e)
        {
            decimal price;
            if (decimal.TryParse(Price.Text, out price))
            {
                products.InsertQuery(ProductName.Text, ProductDescription.Text, price);
                grid_products.ItemsSource = products.GetData();
            }
            else
            {
                MessageBox.Show("Неверный формат цены. Введите число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Del3(object sender, RoutedEventArgs e)
        {
            if (grid_products.SelectedItem != null)
            {
                object ProductID = (grid_products.SelectedItem as DataRowView).Row[0];
                products.DeleteQuery(Convert.ToInt32(ProductID));
                grid_products.ItemsSource = products.GetData();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Izm3(object sender, RoutedEventArgs e)
        {
            if (grid_products.SelectedItem != null)
            {
                DataRowView row = grid_products.SelectedItem as DataRowView;
                if (row != null)
                {
                    int productId = Convert.ToInt32(row.Row["ProductID"]); // Предполагается, что ProductID является первичным ключом таблицы Products
                    if (decimal.TryParse(Price.Text, out decimal price))
                    {
                        products.UpdateQuery(ProductNameIzm.Text, ProductDescriptionIzm.Text, price, productId);
                        grid_products.ItemsSource = products.GetData();
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат цены. Введите число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбрана строка для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
