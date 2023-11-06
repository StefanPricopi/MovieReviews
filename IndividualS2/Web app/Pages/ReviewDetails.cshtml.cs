using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_app.Pages
{
    public class ReviewDetailsModel : PageModel
    {
        public Review review;
        public IActionResult OnGet(int id)
        {
            try
            {
                ReviewManager reviewManager = new ReviewManager(new TESTReviewDAL());
                review = reviewManager.GetReviewById(id);
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect($"/Employees?message={ex.Message}.");
            }
        }
    }
}
