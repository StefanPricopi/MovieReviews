using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
        public static class ReviewManager 
    {
        public static List<Review> reviewList = new List<Review>();
        

        public static void AddReview(Review r)
        {
          
          reviewList.Add(r);
        }

        public static List<Review> GetAllReview()
        {
                            
           return reviewList;

        }

        public static Review GetReviewById(int id)
        {
            foreach(Review r in reviewList) 
            {  
                if(r.Id == id) 
                  return r;
            }
           return null;
            
        }

        public static void UpdateReview(Review r)
        {
            throw new NotImplementedException();
        }
    }
}
