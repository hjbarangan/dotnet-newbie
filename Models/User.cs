using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_newbie.Models;

public class User
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    // Foreign key property
    public int RoleId { get; set; }

    // Navigation property
    [ForeignKey("RoleId")]
    public required Role Role { get; set; }

    public DateTime CreatedAt { get; set; }
}