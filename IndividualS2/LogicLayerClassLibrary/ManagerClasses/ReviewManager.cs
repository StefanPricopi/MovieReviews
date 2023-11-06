
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
        public void UpdateReview(ReviewDTO reviewDTO)
        {
             reviewManagerDAL.UpdateReview(reviewDTO);
        }
        public DataTable GetAllReview()
        {
            return reviewManagerDAL.GetAllReview();
        }
        public Review GetReviewById(int id)
        {
            return reviewManagerDAL.GetReviewById(id);
        }
    }
}
