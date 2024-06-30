using Serilog;
using Serilog.Core;
using System.IO;

namespace Inventory_System.Services;

internal class LoggingServices
{
    private static readonly ILogger CreateLogger = CreateLog();

    public static void Logging(string Message)
    {
        CreateLog().Information(Message);
        Log.CloseAndFlush();
    }

    static ILogger CreateLog()
    {
        string LogFilePath = "./Data/Log.txt";
        return new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(LogFilePath,
                outputTemplate:
                "Log: {Timestamp:yyyy-MM-dd HH:mm:ss} {Message}{NewLine}{Exception}"
            )
        .CreateLogger();
    }
}
