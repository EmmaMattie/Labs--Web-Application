using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab_1.Pages
{
    public class IndexModel : PageModel
    {
        public int CookieCount { get; set; }

        public void OnGet()
        {
            string? user = Request.Cookies["LoggedInUser"];
            if (string.IsNullOrEmpty(user))
            {
                Response.Redirect("/Login");
                return;
            }

            string? value = Request.Cookies["CookieCount"];
            CookieCount = string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
        }

        public IActionResult OnPost()
        {
            string? value = Request.Cookies["CookieCount"];
            CookieCount = string.IsNullOrEmpty(value) ? 1 : int.Parse(value) + 1;

            CookieOptions options = new CookieOptions(); // session cookie only
            Response.Cookies.Append("CookieCount", CookieCount.ToString(), options);
            return RedirectToPage();
        }
    }
}
