using System;
using System.Linq;
using System.Windows.Input;

namespace Inventory_System.Models;

public  class BehaviourModels
{
    public ICommand? INewFile { get; set; }
    public ICommand? INewSchema { get; set; }

    public ICommand? IFileSave { get; set; }
    public ICommand? IFileSaveAs { get; set; }
    public ICommand? IFileOpen { get; set; }
}
