using Inventory_System.ViewModels;
using Inventory_System.Services;

using System.Windows;

namespace Inventory_System.Views;

/// <summary>
/// Interaction logic for HistoryWindow.xaml
/// </summary>
public partial class HistoryWindow : Window
{
    public HistoryWindow()
    {
        InitializeComponent();
        InterComponent();
        DataContext = new HistoryWindowViewModels();
    }

    private void InterComponent()
    {
        Title = "History";
        HistoryWindowServicess history = new();

        HistoryContent.Text = history.RenderHistory();
    }
}
