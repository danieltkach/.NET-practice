using System.ComponentModel.DataAnnotations;

namespace BlazorServerMiniProject.Models;

public class AddressModel
{
    [Required]
    public string? StreetAddress { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public string? State { get; set; }

    [Required]
    [StringLength(10, MinimumLength = 4)]
    public string? ZipCode { get; set; }
}
