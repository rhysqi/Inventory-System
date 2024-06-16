using System;
using Newtonsoft.Json;
using System.Data.Common;

using Inventory_System.Models;

namespace Inventory_System.Services;

public partial class LoggingServices
{
    public void Logging(string Activity)
    {
        TimeStamp();
    }
    
    private DateTime TimeStamp()
    {
        return DateTime.Now;
    }

}
