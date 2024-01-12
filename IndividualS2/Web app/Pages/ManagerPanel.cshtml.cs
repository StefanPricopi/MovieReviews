using LogicLayerClassLibrary.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.DTO;
using LogicLayerClassLibrary.ManagerClasses;

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
        }

        public string GetUserStatusColor(string status)
        {
            // Logging status for debugging
            Console.WriteLine($"User Status: {status}");

            // Null check added here
            return status?.ToLower() == "active" ? "btn-danger" : "btn-success";
        }

        public string GetButtonLabel(string status)
        {
            // Logging status for debugging
            Console.WriteLine($"User Status: {status}");

            // Null check added here
            return status?.ToLower() == "active" ? "Set Inactive" : "Set Active";
        }

        public IActionResult OnPostToggleAccountStatus(int userId, string currentStatus)
        {
            string newStatus = currentStatus.ToLower() == "active" ? "inactive" : "active";

            // Toggle the account status
            userManager.UpdateUserStatus(userId, newStatus);

            // Redirect back to the ManagerPanel page or any other page
            return RedirectToPage("/ManagerPanel");
        }
    }

}

