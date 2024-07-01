using System.IO;
using Microsoft.Data.Sqlite;

namespace Inventory_System.Services;

internal partial class DatabaseServices
{
    public static async Task DbConnector(string DataName, bool Action)
    {
        ///<summary>
        /// Services for connecting to SQlite3
        ///<summary>
        if (Action == true)
        {
            await SqliteConnect(DataName);
        }
        else
        {
            await SqliteDisconnect(DataName);
        }
    }

    private static async Task SqliteConnect(string DataName)
    {
        CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        try
        {
            SqliteConnection sqlite = new(DataName);
            await sqlite.OpenAsync();
        }
        catch (OperationCanceledException)
        {
            throw new OperationCanceledException("It was cancelled!");
        }
    }

    private static async Task SqliteDisconnect(string DataName)
    {
        SqliteConnection sqlite = new(DataName);
        await sqlite.CloseAsync();
    }
}