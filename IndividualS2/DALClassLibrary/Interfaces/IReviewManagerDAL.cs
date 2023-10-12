using LogicLayerClassLibrary.Classes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    public interface IReviewManagerDAL 
    {
        
        public void AddReview(string title, decimal score, string description);
        public void UpdateReview(int id, string title, decimal score, string description);
        public List<Review> GetAllReview();
        public Review GetReviewById(int id);
    }
}
