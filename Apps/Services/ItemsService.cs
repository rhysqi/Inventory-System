using Apps.Data;
using Apps.Models;
using System;

namespace Apps.Services;

internal class ItemsService
{
    public IEnumerable<ItemsModel> GetAllItems()
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated(); // Membuat database jika belum ada
            return context.Items.ToList();
        }
    }

    public void AddItems(ItemsModel model)
    {

    }

}
