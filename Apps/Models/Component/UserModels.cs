using System.ComponentModel.DataAnnotations;

namespace Inventory_System.Models.Component;

internal class UserModels
{
    [Required, MaxLength(50)]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required, MaxLength(3)]
    public UInt16 AccessLevel { get; set; }
}
