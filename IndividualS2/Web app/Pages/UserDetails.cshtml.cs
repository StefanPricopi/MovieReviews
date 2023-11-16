using DALClassLibrary.DALs;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;

namespace Web_app.Pages
{
    public class UserDetailsModel : PageModel
    {      
        public UserProfileDTO userProfile;
        public IActionResult OnGet(int id)
        {
            try
            {
                UserProfileManager userProfileManager = new UserProfileManager(new UserProfileDAL());
                userProfile = userProfileManager.GetActualProfileByID(id);
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect($"/ManagerPanel?message={ex.Message}.");
            }
        }
    }
    
}
