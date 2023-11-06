using LogicLayerClassLibrary.Classes;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    public interface IReviewManagerDAL 
    {
        
        public bool AddReview(ReviewDTO reviewDTO);
        public bool UpdateReview(ReviewDTO reviewDTO);
        public DataTable GetAllReview();
        public Review GetReviewById(int id);
    }
}
