using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using ModelLibrary.DTO;



namespace Web_app.Pages
{

    [Authorize]
    public class ReviewDetailsModel : PageModel
    {
        public ReviewDTO review;
        public List<CommentDTO> comments;
        [BindProperty]
        public CommentDTO comment { get; set; }
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
                comments = commentManager.GetComments(id);
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect($"/Review?message={ex.Message}.");
            }
        }



        public IActionResult OnPost()
        {
            try
            {
                var userIdClaim = User.FindFirst("UserId");
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    comment.UserID = userId;
                    if (Request.Query.TryGetValue("id", out var id))
                    {
                        if (int.TryParse(id, out int parsedId))
                        {
                            comment.ReviewID = parsedId;

                            if (comment != null && commentManager.AddComment(comment))
                            {
                                TempData["SuccessMessage"] = "Comment created successfully!";
                                return RedirectToPage("/ReviewDetails");
                            }
                        }
                        else
                        {
                            return Page();
                        }
                    }
                    else
                    {
                        return Page();
                    }
                }
                else
                {
                    return Page(); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 

                return Redirect($"/Review?message={ex.Message}.");
            }

            return Page(); 
        }
    }
}
