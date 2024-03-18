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

namespace PRAKTIKA3
{
    public partial class Page2 : Page
    {
        private WatchStore111Entities context;

        public Page2()
        {
            InitializeComponent();
            context = new WatchStore111Entities();
            grid_orders.ItemsSource = context.Orders.ToList();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void Dob2(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CustomerID.Text, out int customerId) &&
                int.TryParse(ProductID.Text, out int productId) &&
                DateTime.TryParse(OrderDate.Text, out DateTime orderDate) &&
                int.TryParse(Quantity.Text, out int quantity))
            {
                Order c = new Order
                {
                    CustomerID = customerId,
                    ProductID = productId,
                    OrderDate = orderDate,
                    Quantity = quantity
                };

                context.Orders.Add(c);
                context.SaveChanges();
                grid_orders.ItemsSource = context.Orders.ToList();
            }
            else
            {
                MessageBox.Show("Некорректные данные. Проверьте введенные значения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Del2(object sender, RoutedEventArgs e)
        {
            var selectedOrder = grid_orders.SelectedItem as Order;
            if (grid_orders.SelectedItem != null)
            {
                using (var context = new WatchStore111Entities())
                {
                    var existingOrder = context.Orders.Find(selectedOrder.OrderID);
                    if (existingOrder != null)
                    {
                        context.Orders.Remove(existingOrder);
                        context.SaveChanges();
                        grid_orders.ItemsSource = context.Orders.ToList();
                    }
                }
            }
        }

        private void Izm2(object sender, RoutedEventArgs e)
        {
            if (grid_orders.SelectedItem != null)
            {
                var selectedOrder = grid_orders.SelectedItem as Order;
                using (var context = new WatchStore111Entities())
                {
                    var existingOrder = context.Orders.Find(selectedOrder.OrderID);
                    if (existingOrder != null)
                    {
                        existingOrder.CustomerID = int.Parse(CustomerIDIzm.Text);
                        existingOrder.ProductID = int.Parse(ProductIDIzm.Text);
                        existingOrder.OrderDate = DateTime.Parse(OrderDateIzm.Text);
                        existingOrder.Quantity = int.Parse(QuantityIzm.Text);
                        context.SaveChanges();
                        grid_orders.ItemsSource = context.Orders.ToList();
                    }
                }
            }
        }

        private void grid_orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid_orders.SelectedItem != null)
            {
                var selectedOrder = grid_orders.SelectedItem as Order;
                CustomerIDIzm.Text = selectedOrder.CustomerID.ToString();
                ProductIDIzm.Text = selectedOrder.ProductID.ToString();
                OrderDateIzm.Text = selectedOrder.OrderDate.ToString();
                QuantityIzm.Text = selectedOrder.Quantity.ToString();
                
            }
        }
    }
}
