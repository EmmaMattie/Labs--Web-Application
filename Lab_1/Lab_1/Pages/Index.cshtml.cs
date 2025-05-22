using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_1.Pages
{
    public class IndexModel : PageModel
    {
        // This holds the number of cookies eaten
        public int CookieCount { get; set; }

        // When the page is first loaded (GET request)
        public void OnGet()
        {
            // Try to read the cookie value (may be null)
            string? value = Request.Cookies["CookieCount"];

            // If cookie doesn't exist, set to 0. Otherwise, convert value to int
            CookieCount = string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
        }

        // When the button is clicked (POST request)
        public IActionResult OnPost()
        {
            // Read the cookie value again
            string? value = Request.Cookies["CookieCount"];

            // If it's the first cookie, set to 1. Otherwise, increase the count
            CookieCount = string.IsNullOrEmpty(value) ? 1 : int.Parse(value) + 1;

            // Create cookie options with 30-day expiration
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            // Save the updated cookie value
            Response.Cookies.Append("CookieCount", CookieCount.ToString(), options);

            // Reload the page to show the new count
            return RedirectToPage();
        }
    }
}
