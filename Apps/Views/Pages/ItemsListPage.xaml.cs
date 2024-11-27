using Apps.Models;
using Apps.ViewModels.Pages;
using System.Windows.Controls;

namespace Apps.Views.Pages;

/// <summary>
/// Interaction logic for ItemsListPage.xaml
/// </summary>
public partial class ItemsListPage : Page
{
    public ItemsListPage()
    {
        InitializeComponent();
        DataContext = new ItemsListViewModel();
    }

    private bool _isHandlingRowEdit = false;
    private void DataGrid_RowEditing(object sender, DataGridRowEditEndingEventArgs e)
    {
        var dataGrid = sender as DataGrid;

        if (e.EditAction == DataGridEditAction.Commit)
        {
            var item = e.Row.Item as ItemsModel;
            if (item != null)
            {
                var viewModel = DataContext as ItemsListViewModel;

                // Send data to ViewModel
                viewModel?.HandleRowEdit(item, dataGrid);
            }
        }
    }

}
