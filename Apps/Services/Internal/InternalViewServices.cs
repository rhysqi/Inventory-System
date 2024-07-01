using Serilog;
using System.Windows;

namespace Inventory_System.Services.Internal;

internal class InternalViewServices
{
    public void ExecuteViewUser(object parameter)
    {
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxImage image = MessageBoxImage.Information;

        string content = "This features not available in demo application!";
        string caption = "Information";
        MessageBox.Show(content, caption, button, image);
        Log.Information("Viewing User");
    }

    public void ExecuteViewHistory(object parameter)
    {
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxImage image = MessageBoxImage.Information;

        string content = "This features not available in demo application!";
        string caption = "Information";
        MessageBox.Show(content, caption, button, image);

        Log.Information("Viewing History");
    }
}
