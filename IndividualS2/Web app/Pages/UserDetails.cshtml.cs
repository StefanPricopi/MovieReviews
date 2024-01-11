using DALClassLibrary.DALs;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;

namespace Web_app.Pages
{
    public class UserDetailsModel : PageModel
    {
        private readonly UserProfileManager userProfileManager;
        private readonly CommentManager commentManager;

        public UserProfileDTO userProfile;
        public List<CommentDTO> comments;

        public UserDetailsModel(UserProfileManager userProfileManager, CommentManager commentManager)
        {
            this.userProfileManager = userProfileManager;
            this.commentManager = commentManager;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                userProfile = userProfileManager.GetActualProfileByID(id);
                comments = commentManager.GetAllCommentsByUser(id);
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect($"/ManagerPanel?message={ex.Message}.");
            }
        }
        public IActionResult OnPostDeleteComment(int commentId)
        {   
            try
            {
                commentManager.DeleteComment(commentId);
                return RedirectToPage("/UserDetails");
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error"); 
            }
        }
    }
}
