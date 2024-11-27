using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Apps.Models;

public class ItemsModel
{
    [Key, MaxLength(15)]
    public required string ID { get; set; }
    public required string Name { get; set; }

    [AllowNull]
    public string? Description { get; set; }

    public int Amount { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
}
