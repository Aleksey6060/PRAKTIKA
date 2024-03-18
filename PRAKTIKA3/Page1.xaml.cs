using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (var context = new WatchStore111Entities())
            {
                try
                {
                    grid_customers.ItemsSource = context.Customers.ToList();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void Dob(object sender, RoutedEventArgs e)
        {
            using (var context = new WatchStore111Entities())
            {
                var newCustomer = new Customer
                {
                    FirstName = FirstName.Text, 
                    LastName = LastName.Text,
                    Email = Email.Text,
                    PhoneNumber = Phone.Text 
                };

                context.Customers.Add(newCustomer);
                context.SaveChanges();
                grid_customers.ItemsSource = context.Customers.ToList();
            }
        }

        private void Izm(object sender, RoutedEventArgs e)
        {
            if (grid_customers.SelectedItem != null)
            {
                var selectedCustomer = grid_customers.SelectedItem as Customer;
                using (var context = new WatchStore111Entities())
                {
                    var existingCustomer = context.Customers.Find(selectedCustomer.CustomerID);
                    if (existingCustomer != null)
                    {
                        existingCustomer.FirstName = FirstNameIzm.Text;
                        existingCustomer.LastName = LastNameIzm.Text;
                        existingCustomer.Email = EmailIzm.Text;
                        existingCustomer.PhoneNumber = PhoneIzm.Text;
                        context.SaveChanges();
                        grid_customers.ItemsSource = context.Customers.ToList();
                    }
                }
            }
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            var selectedCustomer = grid_customers.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                using (var context = new WatchStore111Entities())
                {
                    var existingCustomer = context.Customers.Find(selectedCustomer.CustomerID);
                    if (existingCustomer != null)
                    {
                        context.Customers.Remove(existingCustomer);
                        context.SaveChanges();
                        grid_customers.ItemsSource = context.Customers.ToList();
                    }
                }
            }
        }

        private void grid_customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grid_customers.SelectedItem != null)
            {
                var selectedCustomer = grid_customers.SelectedItem as Customer;
                FirstNameIzm.Text = selectedCustomer.FirstName;
                LastNameIzm.Text = selectedCustomer.LastName;
                EmailIzm.Text = selectedCustomer.Email;
                PhoneIzm.Text = selectedCustomer.PhoneNumber;
            }
        }
    }

}
