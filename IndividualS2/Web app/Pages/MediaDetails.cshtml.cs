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
    public class MediaDetailsModel : PageModel
    {
        public MediaDTO mediaDTO;
        MediaManager mediaManager = new MediaManager(new MediaDAL());
        MovieManager movieManager = new MovieManager(new MovieDAL());
        public LikeDislikeManager likeDislikeManager = new LikeDislikeManager(new LikeDislikeDAL());
        public IActionResult OnGet(int id)
        {
            try
            {
                mediaDTO = mediaManager.GetActualMediaByID(id);
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect($"/Media?message={ex.Message}.");
            }
        }
        public IActionResult OnPost()
        {
            if (int.TryParse(Request.Query["id"], out int mediaID))
            {
               
                
                    var userIdClaim = User.FindFirst("UserId");
                    if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                    {
                        LikeDislikeDTO likeDislikeDTO = new LikeDislikeDTO
                        {
                            UserID = userId, 
                            MediaID = mediaID
                        };

                        try
                        {
                            likeDislikeManager.ToggleLikeDislike(likeDislikeDTO);
                            return RedirectToPage("/Media"); 
                        }
                        catch (Exception ex)
                        {
                            return Page();
                        }
                    }
                
            }

            return NotFound();
        }
    }
}
    
