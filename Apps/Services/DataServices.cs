using System.IO;
using Microsoft.Data.Sqlite;

namespace Inventory_System.Services;

public partial class DataServices
{
    public async Task SqliteConnect(string DataName)
    {
        SqliteConnection sqlite = new SqliteConnection(DataName);
        await sqlite.OpenAsync();
    }

    private async Task SqliteDisconnect(string DataName)
    {
        SqliteConnection sqlite = new();
        await sqlite.CloseAsync();
    }
}