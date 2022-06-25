using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Core21.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
        }
    }
}
