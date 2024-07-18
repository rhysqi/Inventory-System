using Inventory_System.Views;
using System.Windows;

namespace Inventory_System.Services.Internal;

internal class InternalViewServices
{
    LoggingServices log = new();
    public void ExecuteViewUser(object parameter)
    {
        MessageBoxButton button = MessageBoxButton.OK;
        MessageBoxImage image = MessageBoxImage.Information;

        string content = "This features not available in demo application!";
        string caption = "Information";
        MessageBox.Show(content, caption, button, image);
        log.CreateLog("Viewing User");
    }

    private Mutex _mutex;
    public void ExecuteViewHistory(object parameter)
    {
        HistoryWindow Window = new();

        string UniqueMutexName = Window.Title;
        bool createNew;
        _mutex = new Mutex(true, UniqueMutexName, out createNew);

        if (!createNew)
        {
            MessageBox.Show("History Already Running.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            Window.Close();
            return;
        }

        Window.Show();
        log.CreateLog("Viewing History");
    }
}
