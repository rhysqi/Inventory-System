using Apps.Views;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Input;
using Apps.Services;
using Apps.Views.Pages;

namespace Apps.ViewModels;

class MainWindowViewModel : BaseViewModel
{
    public ICommand ItemsListPage {  get; }
    public ICommand DeletedItemsPage{  get; }

    private INavigationService _navigationService;

    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        ItemsListPage = new RelayCommand(goToItemslist);
        DeletedItemsPage= new RelayCommand(goToDeletedItems);
    }

    private void goToItemslist(object? parameter)
    {
        _navigationService.NavigateTo(new ItemsListPage());
    }

    private void goToDeletedItems(object? parameter)
    {
        _navigationService.NavigateTo(new DeletedItemsPage());
    }
}
