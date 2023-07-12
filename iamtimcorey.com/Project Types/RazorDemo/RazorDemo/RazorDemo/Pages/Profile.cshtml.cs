using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDemo.Pages
{
    public class ProfileModel : PageModel
    {
        [BindProperty]
        public string Id { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public void OnGet()
        {
        }

        public IActionResult onPost()
        {
            return RedirectToPage("./Index");
        }
    }
}
