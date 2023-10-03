using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    internal interface IReviewManager<r> 
    {
        
        public void AddReview(Review r);
        public void UpdateReview(Review r);
        public List<Review> GetAllReview();
        public Review GetReviewById(int id);
    }
}
