using Serilog;
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

    private string UniqueMutexName = ResourceAssembly.GetName().Name + ".exe";
    private Mutex _mutex;

    protected override void OnStartup(StartupEventArgs e)
    {
        bool createdNew;
        _mutex = new Mutex(true, UniqueMutexName, out createdNew);

        if (!createdNew)
        {
            // Check if application already running
            MessageBox.Show("Application already running.", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Current.Shutdown();
            return;
        }

        base.OnStartup(e);

        // Logging configuration
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File("Data/Log.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        // Create Logging for starting application
        Log.Information("Application started");
    }

    protected override void OnExit(ExitEventArgs e)
    {
        // Adding warning for close application
        string MsgExit = "Are you sure want to close?";
        MessageBoxButton button = MessageBoxButton.YesNo;

        if (MessageBox.Show(MsgExit, "Exit Application", button, MessageBoxImage.Warning) == MessageBoxResult.Yes)
        {
            Application.Current.Shutdown();
        }

        // Logging for close application
        Log.Information("Application exiting");
        Log.CloseAndFlush();

        base.OnExit(e);
    }
}
