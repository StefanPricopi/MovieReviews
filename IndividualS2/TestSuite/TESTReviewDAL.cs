using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.DALs
{
    public class TESTReviewDAL : IReviewManagerDAL
    {
        private Dictionary<int, ReviewDTO> reviews;
        private Dictionary<int, ReviewDTO> archiveReviews;
        public TESTReviewDAL()
        {
            reviews = new Dictionary<int, ReviewDTO>();
            archiveReviews = new Dictionary<int, ReviewDTO>();
        }
        public bool AddArchiveReview(ReviewDTO reviewDTO)
        {
            archiveReviews.Add(reviewDTO.Id, reviewDTO);
            return true;
        }

        public bool AddReview(ReviewDTO reviewDTO)
        {
            reviews.Add(reviewDTO.Id, reviewDTO);
            return true;
        }

        public bool DeleteReview(int id)
        {
            return reviews.Remove(id);
        }

        public ReviewDTO GetActualReviewByMedia(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllArchivedReview()
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllReview()
        {
           return ConvertToDataTable(reviews);
        }

        public List<string> GetAllReviewTitles()
        {
            throw new NotImplementedException();
        }

        public DataTable GetReviewById(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetReviewByMedia(int id)
        {
            throw new NotImplementedException();
        }

        public int GetReviewByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReview(ReviewDTO reviewDTO)
        {
            throw new NotImplementedException();
        }
        static DataTable ConvertToDataTable(Dictionary<int, ReviewDTO> dict)
        {   
            DataTable dataTable = new DataTable();
            DataRow dr ;
            foreach (var item in dict)
            {
               dr = dataTable.NewRow();
               dr["Id"] = item.Key;
               dr["Title"] = item.Value;
               dr["Description"] = item.Value;
               dr["Score"] = item.Value;
               dr["UserID"] = item.Value;
               dr["MediaID"] = item.Value;
            }
            return dataTable;
        }
    }
}
