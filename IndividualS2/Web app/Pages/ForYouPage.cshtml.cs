using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;
using Service_Layer.Interfaces_PL_to_LL;

namespace Web_app.Pages
{
    public class ForYouPageModel : PageModel
    {
        private readonly IMediaManager mediaManager;

        public List<MediaDTO> Recomm { get; set; } // Ensure the property is properly named

        public string Message { get; set; }

        public ForYouPageModel(IMediaManager mediaManager)
        {
            this.mediaManager = mediaManager;
        }

        public void OnGet(string? message)
        {
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                Recomm = mediaManager.RecommendationsAlgo(userId);
            }

            if (message != null)
            {
                Message = message;
            }
        }
    }
}
