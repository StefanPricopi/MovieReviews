
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;

namespace Web_app.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager userManager;
        private IUserManagerDAL userService;

        public RegisterModel(IUserManagerDAL UserService, UserManager manager)
        {
            userService = UserService;
            userManager = manager;
        }

        [BindProperty]
        public UserDTO User { get; set; }


        public void OnPost()
        {
            if (User != null)
            {
                User.RoleID = 2;
                try
                {
                    if (userManager.AddCreateAccount(User))
                    {
                        TempData["SuccessMessage"] = "Account created successfully!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Username already exists";
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
            }
        }

    }
}
