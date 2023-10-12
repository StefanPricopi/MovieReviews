
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        public void AddReview(string title, decimal score, string description)
        {
            reviewManagerDAL.AddReview(title, score, description);
        }
        public void UpdateReview(int id, string title, decimal score, string description)
        {
             reviewManagerDAL.UpdateReview(id, title, score, description);
        }
        public List<Review> GetAllReview()
        {
            return reviewManagerDAL.GetAllReview();
        }
        public Review GetReviewById(int id)
        {
            return reviewManagerDAL.GetReviewById(id);
        }
    }
}
