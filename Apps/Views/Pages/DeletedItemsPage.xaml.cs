using System.Collections.ObjectModel;
using System.Windows.Controls;
using Apps.Models;

namespace Apps.Views.Pages;

/// <summary>
/// Interaction logic for DeletedItemsPage.xaml
/// </summary>
public partial class DeletedItemsPage : Page
{
    public DeletedItemsPage()
    {
        InitializeComponent();
        DataContext = new ViewModels.Pages.DeletedItemsViewModel();
    }
}
