using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;

namespace Web_app.Pages
{
    [Authorize(Policy = "MustBeManager")]
    public class ManagerPanelModel : PageModel
    {
        private readonly UserManager userManager;

        public ManagerPanelModel(IUserManagerDAL userManagerDAL)
        {
            userManager = new UserManager(userManagerDAL);
        }

        public List<UserDTO> Users { get; private set; }

        public void OnGet(string? message)
        {
            Users = userManager.GetAllAccounts();
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
            }
        }
        public IActionResult OnPostSetAccountInactive(int userId)
        {
            userManager.UpdateUserStatus(userId);
            TempData["SuccessMessage"] = "Account has been suspended";

            return RedirectToPage("/ManagerPanel");
        }


    }
}

