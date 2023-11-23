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
        private readonly CommentManager commentManager;
        public ReviewDetailsModel(CommentManager commentManager)
        {
            this.commentManager = commentManager;
        }
        
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



        [HttpPost]
        [Route("/ReviewDetails/AddComment")]
        public IActionResult OnPostAddComment([FromBody] CommentDTO commentModel)
        {
            try
            {
                CommentDTO commentDTO = new CommentDTO
                {
                    ReviewID = review.Id,
                    CommentDescription = commentModel.CommentDescription,
                };



                if (commentManager.AddComment(commentDTO));
                {
                    return RedirectToPage("/ReviewDetails", new { id = review.Id });
                }
               
            }
            catch (Exception ex)
            {
                return RedirectToPage("/ReviewDetails", new { id = review.Id, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("/ReviewDetails/RefreshComments")]
        public IActionResult OnGetRefreshComments(int reviewID)
        {

            List<CommentDTO> comments = commentManager.GetComments(review.Id);
            return new JsonResult(comments);
        }

    }
}
