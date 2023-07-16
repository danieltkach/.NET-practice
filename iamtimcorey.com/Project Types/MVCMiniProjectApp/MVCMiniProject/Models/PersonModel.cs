using System.ComponentModel.DataAnnotations;

namespace MVCMiniProject.Models
{
    public class PersonModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
