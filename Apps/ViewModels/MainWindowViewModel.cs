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
    public ICommand License { get; }

    private INavigationService _navigationService;

    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;

        ItemsListPage = new RelayCommand(goToItemslist);
        DeletedItemsPage = new RelayCommand(goToDeletedItems);
        License = new RelayCommand(LicenseCommand);
    }

    private void goToItemslist(object? parameter)
    {
        _navigationService.NavigateTo(new ItemsListPage());
    }

    private void goToDeletedItems(object? parameter)
    {
        _navigationService.NavigateTo(new DeletedItemsPage());
    }

    private void LicenseCommand(object? parameter)
    {
        string DataText = "Inventory System (Demo)\r\n\r\n" +
            "Copyright © 2024 by Risky Akbar\r\n\r\n" +
            "Licensed under the Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International License:\r\n\r\n" +
            "https://creativecommons.org/licenses/by-nc-nd/4.0/\r\n\r\n" +
            "You are free to:\r\n\r\n" +
            "* Share: Copy and redistribute the material in any medium or format\r\n" +
            "* Adapt: Remix, transform, and build upon the material\r\n\r\n" +
            "Under the following terms:\r\n\r\n" +
            "* Attribution: You must give appropriate credit, provide a link to the license, and indicate if changes were made. You may do so in any reasonable manner, but not in any way that suggests the licensor endorses you or your use.\r\n" +
            "* NonCommercial: You may not use the material for commercial purposes.\r\n" +
            "* NoDerivatives: If you remix, transform, or build upon the material, you may not distribute the modified material.\r\n\r\n" +
            "Notices:\r\n\r\n" +
            "* You do not have to comply with the license for elements of the material in the public domain or where your use is permitted by an applicable exception or limitation.\r\n" +
            "* No warranties are given. The license may not give you all of the permissions necessary for your intended use. For example, other rights such as publicity, privacy, or moral rights may limit how you use the material.\r\n\r\n" +
            "Questions?\r\n\r\n" +
            "If you have any questions about this license, please contact Risky Akbar at <rhysqi.akbar@gmail.com>.";

        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxImage image = MessageBoxImage.Information;
        
        MessageBox.Show(DataText, "License", button, image);
    }
}
