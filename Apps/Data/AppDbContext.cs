using Apps.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Apps.Data;

internal class AppDbContext : DbContext
{
    internal DbSet<ItemsModel> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");

        // Pastikan folder 'Data' ada
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Tentukan path lengkap untuk file database
        var dbPath = Path.Combine(folderPath, "Data.db");

        // Gunakan path lengkap untuk database
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
