using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interfaces
{
    public interface IReviewDisplay
    {
        public DataTable GetAllReview();
        public int GetReviewByTitle(string title);
        public DataTable GetReviewByMedia(int id);
        public DataTable GetReviewById(int id);
        public ReviewDTO GetActualReviewByMedia(int id);
        
    }
}
