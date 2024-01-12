using LogicLayerClassLibrary.Classes;
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
            User s = new User();

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
                    s = userManager.GetCurrentUserByUsername(User.Username);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, s.Username),
                        new Claim(ClaimTypes.Role, "Manager"),
                        new Claim("UserId", s.UserID.ToString()),

                    };

                    var identity = new ClaimsIdentity(claims, "LoginCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("LoginCookieAuth", claimsPrincipal);


                    return RedirectToPage("/Review");
                }
                else if (ValidateLoginVisitorCase())
                {
                    Console.WriteLine("Login successful.");
                    s = userManager.GetCurrentUserByUsername(User.Username);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, s.Username),
                        new Claim(ClaimTypes.Role, "Visitor"),
                        new Claim("UserId", s.UserID.ToString()),


                    };
                    var identity = new ClaimsIdentity(claims, "LoginCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("LoginCookieAuth", claimsPrincipal);

                    return RedirectToPage("/Review");
                }
            }
            TempData["ErrorMessage"] = "invalid credentials or the account has been suspended";
            return Page();
            
        }
    }
}
