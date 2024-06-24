using System.Windows.Input;
using Inventory_System.ViewModels;
using static Inventory_System.ViewModels.MainViewModels;

namespace Inventory_System.Models;

public class MainWindowModels : MainViewModels
{
    public ICommand FileExit { get; set; }
}
