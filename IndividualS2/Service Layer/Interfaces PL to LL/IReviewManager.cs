using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces_PL_to_LL
{
    public interface IReviewManager
    {

        public bool AddReview(ReviewDTO reviewDTO);

        public bool UpdateReview(ReviewDTO reviewDTO);

        public DataTable GetAllReview();

        public int GetReviewByTitle(string title);

        public List<string> GetAllReviewTitles();

        public DataTable GetReviewByID(int id);

        public DataTable GetReviewByMedia(int id);

        public bool AddArchiveReview(ReviewDTO reviewDTO);
        public bool DeleteReview(int id);
        public ReviewDTO GetActualReviewByMedia(int id);
        public DataTable GetAllArchivedReview();
        public List<ReviewDTO> DatagridToList(DataTable dataTable);
        public ReviewDTO GetActualReviewByID(int id);
    }
}
