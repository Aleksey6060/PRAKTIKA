using System;
using System.Collections.Generic;
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

namespace PRAKTIKA3
{
    
    public partial class Page3 : Page
    {
        private WatchStore111Entities context = new WatchStore111Entities();
        public Page3()
        {
            InitializeComponent();
            grid_products.ItemsSource = context.Products.ToList();
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
            using (var context = new WatchStore111Entities())
            {
                var newProduct = new Product
                {
                    ProductName = ProductName.Text,
                    ProductDescription = ProductDescription.Text,
                    Price = decimal.Parse(Price.Text),
                    
                };

                context.Products.Add(newProduct);
                context.SaveChanges();
                grid_products.ItemsSource = context.Products.ToList();
            }
        }

        private void Del3(object sender, RoutedEventArgs e)
        {
            var selectedProduct = grid_products.SelectedItem as Product;
            if (selectedProduct != null)
            {
                using (var context = new WatchStore111Entities())
                {
                    var existingProduct = context.Products.Find(selectedProduct.ProductID);
                    if (existingProduct != null)
                    {
                        context.Products.Remove(existingProduct);
                        context.SaveChanges();
                        grid_products.ItemsSource = context.Products.ToList();
                    }
                }
            }
        }

        private void Izm3(object sender, RoutedEventArgs e)
        {
            if (grid_products.SelectedItem != null)
            {
                var selectedProduct = grid_products.SelectedItem as Product;
                using (var context = new WatchStore111Entities())
                {
                    var existingProduct = context.Products.Find(selectedProduct.ProductID);
                    if (existingProduct != null)
                    {
                        existingProduct.ProductName = ProductNameIzm.Text;
                        existingProduct.ProductDescription = ProductDescriptionIzm.Text;
                        existingProduct.Price = Decimal.Parse(PriceIzm.Text);
                        
                        context.SaveChanges();
                        grid_products.ItemsSource = context.Products.ToList();
                    }
                }
            }
        }

        private void grid_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid_products.SelectedItem != null)
            {
                var selectedOrder = grid_products.SelectedItem as Product;
                ProductNameIzm.Text = selectedOrder.ProductName.ToString();
                ProductDescriptionIzm.Text = selectedOrder.ProductDescription.ToString();
                PriceIzm.Text = selectedOrder.Price.ToString();
                

            }
        }
    }
}
