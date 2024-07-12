using System.IO;
using System.Windows.Controls;

namespace Inventory_System.Services;

internal class HistoryWindowServicess
{
    public string RenderHistory()
    {
        string Path = ".\\Data\\Log.txt";

        return Getdata(Path);
    }

    private string Getdata(string FilePath)
    {
        string line = null;

        try
        {
            line = File.ReadAllText(FilePath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        return line;
    }
}
