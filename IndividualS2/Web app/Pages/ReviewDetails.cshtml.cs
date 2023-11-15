using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;

namespace Web_app.Pages
{
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
                return Redirect($"/Employees?message={ex.Message}.");
            }
        }
    }
}
