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
    public class ReviewModel : PageModel
    {
        public List<ReviewDTO> reviews;
        public string Message;
        public void OnGet(string? message)
        {
            MediaManager mediaManager = new MediaManager(new MediaDAL());
            ReviewManager reviewManager = new ReviewManager(new ReviewDAL());
            reviews=reviewManager.DatagridToList(reviewManager.GetAllReview());
            
            if (message != null)
            {
                Message = message;
            }
        }
    }
}
