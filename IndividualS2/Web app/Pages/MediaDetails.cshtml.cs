using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;

namespace Web_app.Pages
{
    [Authorize]
    public class MediaDetailsModel : PageModel
    {
       public MediaDTO mediaDTO;
        
        public IActionResult OnGet(int id)
        {
            try
            {
                MediaManager mediaManager = new MediaManager(new MediaDAL());
                MovieManager movieManager = new MovieManager(new MovieDAL());
                mediaDTO=mediaManager.GetActualMediaByID(id);
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect($"/Media?message={ex.Message}.");
            }
        }
    }
}
