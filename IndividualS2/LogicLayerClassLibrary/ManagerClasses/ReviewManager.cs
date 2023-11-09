
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace LogicLayerClassLibrary.ManagerClasses
{
    public  class ReviewManager
    {
        private IReviewManagerDAL reviewManagerDAL;
        public static int ReviewId = 4;
        public ReviewManager(IReviewManagerDAL reviewManager)
        {
            reviewManagerDAL = reviewManager;
        }
        public bool AddReview(ReviewDTO reviewDTO)
        {
           return reviewManagerDAL.AddReview(reviewDTO);
        }
        public bool UpdateReview(ReviewDTO reviewDTO)
        {
           return  reviewManagerDAL.UpdateReview(reviewDTO);
        }
        public DataTable GetAllReview()
        {
            return reviewManagerDAL.GetAllReview();
        }
        public int GetReviewByTitle(string title)
        {
            return  reviewManagerDAL.GetReviewByTitle(title);
        }
        public List<string> GetAllReviewTitles()
        {
            return reviewManagerDAL.GetAllReviewTitles();
        }
        public DataTable GetReviewByID(int id)
        {
            return reviewManagerDAL.GetReviewById(id);
        }
        public DataTable GetReviewByMedia(int id)
        {
            return reviewManagerDAL.GetReviewByMedia(id);
        }
    }
}
