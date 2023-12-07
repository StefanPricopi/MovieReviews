using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using System.Collections.Generic;

namespace Web_app.Pages
{

    [Authorize]
    public class ReviewModel : PageModel
    {
        private readonly IReviewDisplay reviewDisplay;
        private readonly IReviewUtility reviewUtility;

        public List<ReviewDTO> reviews;
        public string Message;

        public ReviewModel(IReviewDisplay reviewDisplay, IReviewUtility reviewUtility)
        {
            this.reviewDisplay = reviewDisplay;
            this.reviewUtility = reviewUtility;
        }

        public void OnGet(string? message)
        {
            reviews = reviewUtility.DatagridToList(reviewDisplay.GetAllReview());

            if (message != null)
            {
                Message = message;
            }
        }
    }
}
