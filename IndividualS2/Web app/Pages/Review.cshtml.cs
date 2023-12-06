using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;
using System.Collections.Generic;

namespace Web_app.Pages
{
    [Authorize]
    public class ReviewModel : PageModel
    {
        private readonly MediaManager mediaManager;
        private readonly ReviewManager reviewManager;

        public List<ReviewDTO> reviews;
        public string Message;

        public ReviewModel(MediaManager mediaManager, ReviewManager reviewManager)
        {
            this.mediaManager = mediaManager;
            this.reviewManager = reviewManager;
        }

        public void OnGet(string? message)
        {
            reviews = reviewManager.DatagridToList(reviewManager.GetAllReview());

            if (message != null)
            {
                Message = message;
            }
        }
    }
}
