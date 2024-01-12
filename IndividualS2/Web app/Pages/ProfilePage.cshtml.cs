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
        [BindProperty]
        public UserProfileDTO userProfile { get; set; }
        public List<CommentDTO> comments = new List<CommentDTO>();

        public ProfilePageModel( UserProfileManager userProfileManager,  CommentManager commentManager)
        {
            ;
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
        public IActionResult OnPostUpdatePreferences()
        {
            try
            {
                userProfile.MinuteNewsletterPreference = Request.Form["MinuteNewsletterPreference"] == "1";
                userProfile.DailyNewsletterPreference = Request.Form["DailyNewsletterPreference"] == "1";
                userProfile.WeeklyNewsletterPreference = Request.Form["WeeklyNewsletterPreference"] == "1";

              
                userProfileManager.UpdateUserNewsletterPreferences(userProfile.userID,
                    userProfile.MinuteNewsletterPreference,
                    userProfile.DailyNewsletterPreference,
                    userProfile.WeeklyNewsletterPreference);

                TempData["SuccessMessage"] = "Preferences updated successfully.";

                return RedirectToPage("/ProfilePage");
            }
            catch (Exception ex)
            {
                return Redirect($"/Index?message={ex.Message}");
            }
        }

    }
}
