using System.Windows.Controls;

namespace Inventory_System.Views;

/// <summary>
/// Interaction logic for TablePage.xaml
/// </summary>
public partial class TablePage : Page
{
    public TablePage()
    {
        InitializeComponent();
        InterComponent();
    }

    private void InterComponent()
    {
        TableDataGrid.DataContext = this;
    }
}
