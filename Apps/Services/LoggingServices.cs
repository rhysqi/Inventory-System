using System.IO;
using System.Text;

namespace Inventory_System.Services;

internal class LoggingServices
{
    public void CreateLog(string Message)
    {
        LogTemplate(Message);
    }

    private static void LogTemplate(string LogMsg)
    {
        string FilePath = ".\\Data\\Log.txt";

        string CurrentPath = Directory.GetCurrentDirectory() + FilePath;

        // Create Directory if not exist
        if (!Directory.Exists("Data") || !File.Exists(FilePath))
        {
            Directory.CreateDirectory(".\\Data");
            File.WriteAllText(FilePath, null);
        }
        WriteLog(CurrentPath, LogMsg);
    }

    private static void WriteLog(string CurrentPath, string LogMsg)
    {
        // This text is always added, making the file longer over time
        // if it is not deleted.
        string appendText = DateLog() + LogMsg + Environment.NewLine;
        string PrevFile = File.ReadAllText(CurrentPath, Encoding.UTF8);

        File.WriteAllText(CurrentPath, appendText + PrevFile, Encoding.UTF8);
    }

    private static string DateLog()
    {
        DateTime Date = DateTime.Now;
        string DateData = "Log: " + Date.ToString("dd/MM/yyyy HH:mm:ss ");

        return DateData;
    }
}
