using Apps.Services;
using Apps.ViewModels;
using Apps.Views.Pages;
using System.Windows;

namespace Apps.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var navigationService = new NavigationService(MainPage);

        DataContext = new MainWindowViewModel(navigationService);

        navigationService.NavigateTo(new ItemsListPage());
    }
}