using Inventory_System.Views;
using System.IO;

namespace Inventory_System.Services.Internal;

internal class InternalSystemServices
{
    public void ReadFile(string FilePath)
    {
        File.ReadAllLinesAsync(FilePath);
    }
}
