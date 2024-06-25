using Inventory_System.Models;
using Inventory_System.Services.Internal;
using Inventory_System.Views;

namespace Inventory_System.ViewModels;

using RelayCommand = BaseViewModels.RelayCommand;

public class MainWindowViewModels : MainWindowModels
{
    InternalFileServices InternalFile = new();
    InternalViewServices InternalView = new();
    InternalAboutServices InternalAbout = new();

    private static void ExecuteViewHistory(object parameter)
    {
        HistoryWindow window = new();
        window.ShowDialog();
    }

    public MainWindowViewModels()
    {
        FileNew = new RelayCommand(InternalFile.ExecuteFileNewSchema);
        FileSave = new RelayCommand(InternalFile.ExecuteFileSave);
        FileSaveAs = new RelayCommand(InternalFile.ExecuteFileSaveAs);
        FileOpen = new RelayCommand(InternalFile.ExecuteFileOpen);
        FileClose = new RelayCommand(InternalFile.ExecuteFileClose);
        FileExit = new RelayCommand(InternalFile.ExecuteFileExit);
        
        ViewUser = new RelayCommand(InternalView.ExecuteViewUser);
        ViewHistory = new RelayCommand(InternalView.ExecuteViewHistory);

        AboutInfo = new RelayCommand(InternalAbout.ExecuteAboutInfo);
        AboutLicense = new RelayCommand(InternalAbout.ExecuteAboutLicense);
    }
}