using DALClassLibrary.DALs;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;

namespace Web_app.Pages
{
    [Authorize(Roles = "Manager")]
    public class ManagerPanelModel : PageModel
    {
        public List<UserDTO> users;
        public string Message;
        public void OnGet(string? message)
        {
            UserManager userManager = new UserManager(new UserDAL());
            users = userManager.GetAllAccounts();

            if (message != null)
            {
                Message = message;
            }
        }
    }
}

