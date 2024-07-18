using Inventory_System.Services;
using System.Windows;

namespace Inventory_System;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    private Mutex _mutex;
    private string UniqueMutexName = ResourceAssembly.GetName().Name + ".exe";

    LoggingServices log = new();

    protected override void OnStartup(StartupEventArgs e)
    {
        bool createdNew;
        _mutex = new Mutex(true, UniqueMutexName, out createdNew);

        ///<summary>
        /// Check if application already running
        ///<summary>
        if (!createdNew)
        {
            MessageBox.Show("Application already running.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Current.Shutdown();
            return;
        }
        log.CreateLog("Application Started");

        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        log.CreateLog("Application Closed");
        base.OnExit(e);
    }
}
