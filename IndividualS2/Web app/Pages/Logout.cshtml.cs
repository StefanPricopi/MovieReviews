using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_app.Pages
{
       
        public class LogoutModel : PageModel
        {
            public async Task<IActionResult> OnPostAsync()
            {
                await HttpContext.SignOutAsync("LoginCookieAuth");
                return RedirectToPage("/index");
            }
        }    
}
