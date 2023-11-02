using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_app.Pages
{
    public class MediaDetailsModel : PageModel
    {
        public Media media;
        public IActionResult OnGet(int id)
        {
            try
            {
                MediaManager mediaManager = new MediaManager(new TESTMediaDAL());
                media = mediaManager.GetMediaById(id);
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect($"/Media?message={ex.Message}.");
            }
        }
    }
}
