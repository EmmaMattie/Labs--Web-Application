using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_1.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public string? Greeting { get; set; }

        public void OnGet()
        {
            string? savedUser = Request.Cookies["LoggedInUser"];
            if (!string.IsNullOrEmpty(savedUser))
            {
                Greeting = $"Welcome, {savedUser}!";
            }
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                CookieOptions options = new CookieOptions(); 
                Response.Cookies.Append("LoggedInUser", Username, options);
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
