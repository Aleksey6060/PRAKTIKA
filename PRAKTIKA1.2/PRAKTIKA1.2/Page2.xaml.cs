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

    public partial class Page2 : Page
    {
        private ProductsTableAdapter productsTableAdapter;

        public Page2()
        {
            InitializeComponent();
            productsTableAdapter = new ProductsTableAdapter();
            grid_products.ItemsSource = productsTableAdapter.GetData();
        }


    }
}
