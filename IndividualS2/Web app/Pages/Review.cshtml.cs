using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_app.Pages
{
    public class ReviewModel : PageModel
    {
        public List<Review> reviews;
        public string Message;
        public void OnGet(string? message)
        {
            ReviewManager reviewManager = new ReviewManager(new ReviewDAL());
            //reviews = reviewManager.GetAllReview();
            if (message != null)
            {
                Message = message;
            }
        }
    }
}
