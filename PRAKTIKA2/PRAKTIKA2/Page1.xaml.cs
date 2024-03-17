using PRAKTIKA2.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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



namespace PRAKTIKA2
{
   
    public partial class Page1 : Page
    {
        CustomersTableAdapter customers = new CustomersTableAdapter();
        
        public Page1()
        {
            InitializeComponent();
            grid_customers.ItemsSource = customers.GetData();
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
            
            customers.InsertQuery(FirstName.Text, LastName.Text, Email.Text, Phone.Text);
            grid_customers.ItemsSource = customers.GetData();
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            
            if (grid_customers.SelectedItem != null)
            {
                object CustomerID = (grid_customers.SelectedItem as DataRowView).Row[0];
                customers.DeleteQuery(Convert.ToInt32(CustomerID));
                grid_customers.ItemsSource = customers.GetData();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Izm(object sender, RoutedEventArgs e)
        {
            if (grid_customers.SelectedItem != null)
            {
                object CustomerID = (grid_customers.SelectedItem as DataRowView).Row[0];
                customers.UpdateQuery(FirstNameIzm.Text, LastNameIzm.Text, EmailIzm.Text, PhoneIzm.Text, Convert.ToInt32(CustomerID));
                grid_customers.ItemsSource = customers.GetData();
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
