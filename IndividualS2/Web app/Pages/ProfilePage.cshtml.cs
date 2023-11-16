using DALClassLibrary.DALs;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;
using System.Security.Claims;

namespace Web_app.Pages
{
    public class ProfilePageModel : PageModel
    {
        public UserProfileDTO userProfile;

        public IActionResult OnGet()
        {
            try
            {
                var userIdClaim = User.FindFirst("UserId");
                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    if (int.TryParse(userIdValue, out int userId))
                    {
                        UserProfileManager userProfileManager = new UserProfileManager(new UserProfileDAL());
                        userProfile = userProfileManager.GetActualProfileByID(userId);
                        if (userProfile != null)
                        {
                            return Page();
                        }
                    }
                }
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                
                return Redirect($"/Index?message={ex.Message}");
            }
        }

    }
}

