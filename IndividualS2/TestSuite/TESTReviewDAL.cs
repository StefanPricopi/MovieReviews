using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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
        public  Dictionary<int, ReviewDTO> reviews;
        public  Dictionary<int, ReviewDTO> archiveReviews;
        public TESTReviewDAL(Dictionary<int, ReviewDTO> reviewDictionary)
        {
            reviews = new Dictionary<int, ReviewDTO>();
            archiveReviews = new Dictionary<int, ReviewDTO>();
        }
        public bool AddArchiveReview(ReviewDTO reviewDTO)
        {
            if (reviewDTO != null && reviewDTO.Id > 0)
            {
                if (!archiveReviews.ContainsKey(reviewDTO.Id))
                {
                    archiveReviews.Add(reviewDTO.Id, reviewDTO);
                    return true;
                }
            }
            return false;
        }

        public bool AddReview(ReviewDTO reviewDTO)
        {
            if (reviewDTO != null && reviewDTO.Id > 0)
            {
                if (!reviews.ContainsKey(reviewDTO.Id))
                {
                    reviews.Add(reviewDTO.Id, reviewDTO);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteReview(int id)
        {
            if (reviews != null && reviews.ContainsKey(id))
            {
                return reviews.Remove(id);
            }
            return false;
        }

        public ReviewDTO GetActualReviewByMedia(int id)
        {
            if (reviews.TryGetValue(id, out ReviewDTO review))
            {
                return review;
            }

            return null;
        }

        public DataTable GetAllArchivedReview()
        {
            return ConvertToDataTable(archiveReviews);
        }

        public DataTable GetAllReview()
        {
           return ConvertToDataTable(reviews);
        }

        public List<string> GetAllReviewTitles()
        {
            if (reviews == null)
            {
                return new List<string>(); // Return an empty list if reviews is null
            }

            List<string> titles = new List<string>();
            foreach (var review in reviews.Values)
            {
                titles.Add(review.Title);
            }
            return titles;
        }

        public DataTable GetReviewById(int id)
        {
            if (reviews.TryGetValue(id, out ReviewDTO review))
            {
                Dictionary<int, ReviewDTO> singleReviewDictionary = new Dictionary<int, ReviewDTO>
            {
                { review.Id, review }
            };
                return ConvertToDataTable(singleReviewDictionary);
            }
           
            return new DataTable();
        }

        public DataTable GetReviewByMedia(int id)
        {
            var reviewsByMedia = reviews.Values.Where(review => review.MediaID == id).ToList();

            if (reviewsByMedia.Any())
            {
                return ConvertToDataTable(reviewsByMedia.ToDictionary(review => review.Id));
            }
            
            return new DataTable();
        }

        public int GetReviewByTitle(string title)
        {
            foreach (var review in reviews.Values)
            {
                if (review.Title == title)
                {
                    return review.Id;
                }
            }
            
            return -1;
        }

        public bool UpdateReview(ReviewDTO reviewDTO)
        {
            if (reviews.ContainsKey(reviewDTO.Id))
            {
                reviews[reviewDTO.Id] = reviewDTO;
                return true; 
            }
            return false;
        }
        public DataTable ConvertToDataTable(Dictionary<int, ReviewDTO> dict)
        {
            if (dict == null)
            {
                return new DataTable();
            }
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("Score", typeof(int));
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("MediaID", typeof(int));

            foreach (var item in dict)
            {
                DataRow dr = dataTable.NewRow();
                dr["Id"] = item.Key;
                dr["Title"] = item.Value.Title;
                dr["Description"] = item.Value.Description;
                dr["Score"] = item.Value.Score;
                dr["UserID"] = item.Value.UserID;
                dr["MediaID"] = item.Value.MediaID;
                dataTable.Rows.Add(dr);
            }

            return dataTable;
        }
        
    }
}
