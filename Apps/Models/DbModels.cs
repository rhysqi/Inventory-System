using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Inventory_System.Models;

internal class DbModels : DbContext
{
    
}

public class Item
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public int Amount { get; set; }
}