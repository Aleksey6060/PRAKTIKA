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

namespace PRAKTIKA1._3
{
   
    public partial class Page3 : Page
    {
        private WatchStore111Entities context = new WatchStore111Entities();
        public Page3()
        {
            InitializeComponent();
            Products.ItemsSource = context.Products.ToList();
        }
    }
}
