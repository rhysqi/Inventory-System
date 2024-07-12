using Inventory_System.Services.Internal;
using System.Reflection.Emit;
using System.Windows.Controls;

namespace Inventory_System.ViewModels;

internal class HistoryWindowViewModels : BaseViewModels
{
    InternalSystemServices SystemServices = new();

    public HistoryWindowViewModels()
    {
        SystemServices.ReadFile("Data/Log.txt");
        TextBlock LogTextBlock = new();

        LogTextBlock.Text = "string.Empty";
    }
}
