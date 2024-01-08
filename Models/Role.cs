using System.ComponentModel.DataAnnotations;


namespace dotnet_newbie.Models;

public class Role
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Role is required.")]
    [Display(Name = "Role Name")]
    public string? Name { get; set; }

    [Display(Name = "Date Created")]
    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }


}