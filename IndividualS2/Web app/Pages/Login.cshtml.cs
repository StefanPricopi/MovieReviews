using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;
using System.Security.Claims;

namespace Web_app.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserManager userManager;
        private readonly IUserManagerDAL iLoginService;

        public LoginModel(IUserManagerDAL loginService)
        {
            iLoginService = loginService;
            userManager = new UserManager(loginService);
        }

        [BindProperty]
        public UserDTO User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            UserDTO userModel = new UserDTO();

            bool ValidateLoginEmployeeCase()
            {
                return userManager.IsLoginValid(User.Username, User.PasswordHash);
            }

            bool ValidateLoginVisitorCase()
            {
                return userManager.IsLoginValidVisitorCase(User.Username, User.PasswordHash);
            }

            if (User == null)
            {
                return Page();
            }
            else
            {
                if (ValidateLoginEmployeeCase())
                {
                    Console.WriteLine("Login successful.");
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "user"),
                        new Claim("Employee", "Manager")
                    };
                    var identity = new ClaimsIdentity(claims, "LoginCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("LoginCookieAuth", claimsPrincipal);

                    return RedirectToPage("/Review");
                }
                else if (ValidateLoginVisitorCase())
                {
                    Console.WriteLine("Login successful.");
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "user"),
                        
                    };
                    var identity = new ClaimsIdentity(claims, "LoginCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("LoginCookieAuth", claimsPrincipal);

                    return RedirectToPage("/Review");
                }
            }

            return Page();
        }
    }
}
