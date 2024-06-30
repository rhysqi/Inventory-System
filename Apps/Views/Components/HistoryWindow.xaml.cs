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
    }

    private void InterComponent()
    {
        Title = "History";
    }
}
