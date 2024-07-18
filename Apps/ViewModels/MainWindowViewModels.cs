using Inventory_System.Models;
using Inventory_System.Services.Internal;
using System.ComponentModel;
using System.Windows.Controls;

namespace Inventory_System.ViewModels;

using RelayCommand = BaseViewModels.RelayCommand;

public class MainWindowViewModels : MainWindowModels
{
    InternalFileServices InternalFile = new();
    InternalViewServices InternalView = new();
    InternalAboutServices InternalAbout = new();

    public MainWindowViewModels()
    {
        FileNewSchema = new RelayCommand(InternalFile.ExecuteFileNewSchema);
        FileSave = new RelayCommand(InternalFile.ExecuteFileSave);
        FileSaveAs = new RelayCommand(InternalFile.ExecuteFileSaveAs);
        FileOpen = new RelayCommand(InternalFile.ExecuteFileOpenAsync);
        FileClose = new RelayCommand(InternalFile.ExecuteFileClose);
        FileExit = new RelayCommand(InternalFile.ExecuteFileExit);
        
        ViewUser = new RelayCommand(InternalView.ExecuteViewUser);
        ViewHistory = new RelayCommand(InternalView.ExecuteViewHistory);
        
        AboutInfo = new RelayCommand(InternalAbout.ExecuteAboutInfo);
        AboutLicense = new RelayCommand(InternalAbout.ExecuteAboutLicense);


    }

    private DataGrid datagrid;
    public DataGrid DataGrid
    {
        get { return datagrid; }
        set { datagrid = value; }
    }

    // Property changed method
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}