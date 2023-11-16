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
    public class ReviewDetailsModel : PageModel
    {
        public ReviewDTO review;
        public IActionResult OnGet(int id)
        {
            try
            {
                ReviewManager reviewManager = new ReviewManager(new ReviewDAL());
                review = reviewManager.GetActualReviewByMedia(id);
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect($"/Review?message={ex.Message}.");
            }
        }
    }
}
