using System.Windows;
using System.Windows.Input;

using Inventory_System.Models;
using Inventory_System.Services;
using Inventory_System.Views;

namespace Inventory_System.ViewModels;

public class MainWindowViewModels : MainWindowModels
{
    private static void ExecuteFileExit(object parameter)
    {
        Application.Current.Shutdown();
    }

    private static void ExecuteViewHistory(object parameter)
    {
        HistoryWindow window = new();
        window.ShowDialog();
    }

    public MainWindowViewModels()
    {
        FileExit = new RelayCommand(ExecuteFileExit);
    }
}