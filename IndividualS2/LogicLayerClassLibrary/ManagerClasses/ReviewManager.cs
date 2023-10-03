using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
        public class ReviewManager : IReviewManager<Review>
    {
        private List<Review> reviewList = new List<Review>();
        
        
        

        public void AddReview(Review r)
        {
          
          reviewList.Add(r);
        }

        public List<Review> GetAllReview()
        {
            throw new NotImplementedException();
        }

        public Review GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateReview(Review r)
        {
            throw new NotImplementedException();
        }
    }
}
