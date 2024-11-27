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
}
