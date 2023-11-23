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
        public IActionResult OnPostAddComment([FromBody] CommentDTO commentModel)
        {
            try
            {
                CommentDTO commentDTO = new CommentDTO
                {
                    ReviewID = commentModel.ReviewID,
                    CommentDescription = commentModel.CommentDescription,
                };

                bool commentAdded = commentManager.AddComment(commentDTO);

                if (commentAdded)
                {
                    return RedirectToPage("/ReviewDetails", new { id = review.Id });
                }
                else
                {
                    return RedirectToPage("/ReviewDetails", new { id = review.Id, message = "Failed to add comment." });
                }
            }
            catch (Exception ex)
            {
                return RedirectToPage("/ReviewDetails", new { id = review.Id, message = ex.Message });
            }
        }
    }
}
