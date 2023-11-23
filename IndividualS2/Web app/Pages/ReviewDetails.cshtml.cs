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
        public IActionResult AddComment([FromBody] CommentDTO commentDTO)
        {
            try
            {
                var userIdClaim = User.FindFirst("UserId");
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {

                    commentDTO.UserID = userId;


                    bool addedToDB = commentManager.AddComment(commentDTO);

                    if (addedToDB)
                    {

                        return new JsonResult(new { success = true, message = "Comment added successfully" });
                    }
                    else
                    {

                        return new JsonResult(new { success = false, message = "Failed to add comment to the database" });
                    }
                }
                else
                {

                    return new JsonResult(new { success = false, message = "UserID not found in claims" });
                }
            }
            catch (Exception ex)
            {

                return new JsonResult(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult RefreshComments(int reviewId)
        {
            {
                try
                {
                 
                    List<CommentDTO> comments = commentManager.GetComments(reviewId);
                    return new JsonResult(comments);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

    }
}
