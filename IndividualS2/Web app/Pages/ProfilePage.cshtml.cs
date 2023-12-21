using DALClassLibrary.DALs;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.BaseClasses;
using ModelLibrary.DTO;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using ModelLibrary.Interfaces;
using ModelLibrary.NewsletterStrategy;

namespace Web_app.Pages
{
    public class ProfilePageModel : PageModel
    {
        private readonly UserProfileManager userProfileManager;
        private readonly CommentManager commentManager;
        private readonly NewsletterManager newsletterManager;
        private readonly INewsletterStrategy _newsletterStrategy;

        public UserProfileDTO userProfile;
        public List<CommentDTO> comments = new List<CommentDTO>();

        public ProfilePageModel( UserProfileManager userProfileManager, NewsletterManager newsletterManager, CommentManager commentManager)
        {
            this.newsletterManager = newsletterManager;
            this.userProfileManager = userProfileManager;
            this.commentManager = commentManager;
        }

        public IActionResult OnGet()
        {
            try
            {
                var userIdClaim = User.FindFirst("UserId");
                if (userIdClaim != null)
                {
                    var userIdValue = userIdClaim.Value;
                    if (int.TryParse(userIdValue, out int userId))
                    {
                        userProfile = userProfileManager.GetActualProfileByID(userId);


                        if (userProfile != null)
                        {
                            return Page();
                        }
                    }
                }
                return Redirect("Index");
            }
            catch (Exception ex)
            {
                return Redirect($"/Index?message={ex.Message}");
            }
        }
        
    }
}
