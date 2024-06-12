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
using System.Windows.Shapes;

namespace Inventory_System
{
    /// <summary>
    /// Interaction logic for AppControll.xaml
    /// </summary>
    public partial class AppControll : Window
    {
        public AppControll()
        {
            InterComponent();
        }

        private void InterComponent()
        {
            Title = "Application";

        }
    }
    
}
