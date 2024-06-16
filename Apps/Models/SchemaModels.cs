using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models;

public class SchemaModels
{
    [Required, MaxLength(10)]
    protected int ItemID { get; set; }

    [Required, MaxLength(50)]
    protected string? ItemName { get; set; }

    [Required]
    protected int Amount { get; set; }

    [Required, MaxLength(500)]
    protected string? Description { get; set; }

    [Required]
    protected DateTime? TimeStamp { get; set; }
}
