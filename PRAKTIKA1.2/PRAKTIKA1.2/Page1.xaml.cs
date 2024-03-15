using PRAKTIKA1._2.DataSet1TableAdapters;
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


namespace PRAKTIKA1._2
{
   
    public partial class Page1 : Page
    {
        private OrdersTableAdapter ordersTableAdapter;

        public Page1()
        {
            InitializeComponent();
            ordersTableAdapter = new OrdersTableAdapter();
            grid_orders.ItemsSource = ordersTableAdapter.GetData();
        }

      
    }
}
