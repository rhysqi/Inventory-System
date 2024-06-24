using Inventory_System.ViewModels;
using System.Windows;

namespace Inventory_System.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string DefaultTitle = "Inventory System";

        public MainWindow()
        {
            InitializeComponent();
            InternalComponent();
            DataContext = new MainWindowViewModels();
        }

        internal void InternalComponent()
        {
            Title = DefaultTitle;
            WindowState = WindowState.Maximized;
        }
    }
}
