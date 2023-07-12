using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDemo.Pages
{
    public class AddressModel : PageModel
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; } 
        public string? Country { get; set; }

        public void OnGet()
        {
        }

        public IActionResult onPost()
        {
            return RedirectToPage("./Index");
        }
    }
}
