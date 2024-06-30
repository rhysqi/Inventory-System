using Inventory_System.Views;
using Inventory_System.Views.Components;

namespace Inventory_System.Services.Internal;

internal class InternalViewServices
{
    public void ExecuteViewUser(object parameter)
    {
        LoggingServices.Logging("Viewing User");
        UserWindow window = new();
        window.Show();
    }

    public void ExecuteViewHistory(object parameter)
    {
        LoggingServices.Logging("Viewing History");
        HistoryWindow window = new();
        window.Show();
    }
}
