using System.Windows;

namespace Inventory_System.Views.Components
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            InterComponent();
        }

        private void InterComponent()
        {
            Title = "User";
        }
    }
}
