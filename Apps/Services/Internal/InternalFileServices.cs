using System.IO;
using System.Windows;
using Microsoft.Win32;
using Serilog;

namespace Inventory_System.Services.Internal;

/// <summary>
/// Method for internal application services
/// </summary>
internal class InternalFileServices
{
    public void ExecuteFileNewSchema(object parameter)
    {
        SaveFileDialog dialog = new();

        dialog.Title = "New Schema";
        dialog.Filter = "Sqlite files(*.db)|*.db";

        dialog.AddExtension = true;
        dialog.CheckFileExists = false;
        dialog.FileName = "Schema";

        if (dialog.ShowDialog() == true)
        {
            File.WriteAllTextAsync(dialog.FileName, null);

            _ = DatabaseServices.DbConnector(dialog.FileName, true);
            Log.Information("Creating Schema"  + dialog.FileName);
        }
    }

    public void ExecuteFileSave(object parameter)
    {
        SaveFileDialog dialog = new();

        dialog.Title = "Save Schema";
        dialog.Filter = "Sqlite files(*.db)|*.db";

        dialog.AddExtension = true;
        dialog.CheckFileExists = false;
        dialog.FileName = "Schema";

        if (dialog.ShowDialog() == true)
        {
            Log.Information("Save Schema " + dialog.FileName);
        }
    }

    public void ExecuteFileSaveAs(object parameter)
    {
        SaveFileDialog dialog = new();

        dialog.Title = "Save Schema";
        dialog.Filter = "Sqlite files(*.db)|*.db";

        dialog.AddExtension = true;
        dialog.CheckFileExists = false;
        dialog.FileName = "Schema";

        if(dialog.ShowDialog() == true)
        {
            Log.Information("Save As Schema " + dialog.FileName);
        }
    }

    public void ExecuteFileOpenAsync(object parameter)
    {
        OpenFileDialog dialog = new();
        dialog.Filter = "Sqlite files(*.db)|*.db";
        dialog.CheckFileExists = true;
        dialog.AddExtension = true;

        if (dialog.ShowDialog() != null)
        {
            _ = DatabaseServices.DbConnector(dialog.FileName, true);
            Log.Information("Opening Schema " + dialog.FileName);
        }
    }

    public void ExecuteFileClose(object parameter)
    {
        Log.Information("Closing Schema");
    }

    public void ExecuteFileExit(object parameter)
    {
        string MsgExit = "Are you sure want to close?";
        MessageBoxButton button = MessageBoxButton.YesNo;
        
        if (MessageBox.Show(MsgExit, "Exit Application", button, MessageBoxImage.Warning) == MessageBoxResult.Yes)
        {
            Application.Current.Shutdown();
        }
    }

}
