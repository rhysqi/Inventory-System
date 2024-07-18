﻿using System.Windows.Input;

namespace Inventory_System.Models;

public class MainWindowModels
{
    public ICommand? FileNewSchema { get; set; }
    public ICommand? FileSave { get; set; }
    public ICommand? FileSaveAs { get; set; }
    public ICommand? FileOpen { get; set; }
    public ICommand? FileClose { get; set; }
    public ICommand? FileExit { get; set; }

    public ICommand? ViewUser { get; set; }
    public ICommand? ViewHistory { get; set; }

    public ICommand? AboutInfo { get; set; }
    public ICommand? AboutLicense { get; set; }
}