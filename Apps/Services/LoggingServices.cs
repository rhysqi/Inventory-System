using Serilog;
using Serilog.Core;
using System.IO;

namespace Inventory_System.Services;

internal partial class LoggingServices
{
    private const string V = "";

    public static void Logging(string Message)
    {
        string DefaultLogFilePath = "./Data/Log.txt";

        try
        {
            CreateLog(Message, DefaultLogFilePath);
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFoundException("Error not found!");
        }
    }

    private static void CreateLog(string MsgData, string LogFilePath)
    {
        var Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(LogFilePath,
                outputTemplate: "Log {Timestamp:yyyy-MM-dd HH:mm:ss} {Message}{NewLine}{Exception}"
            )
        .CreateLogger();

        Logger.Information("{Timestamp}", MsgData);
    }
}
