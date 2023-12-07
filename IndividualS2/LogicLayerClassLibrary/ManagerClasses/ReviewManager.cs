
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using Service_Layer.Interfaces_PL_to_LL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace LogicLayerClassLibrary.ManagerClasses
{
    public  class ReviewManager : IReviewManager
    {
        private IReviewManagerDALcrud reviewManagerDAL;
        private IReviewDisplay reviewDisplay;
        private IReviewUtility reviewUtility;
      

        public ReviewManager(
            IReviewManagerDALcrud reviewManager,
            IReviewDisplay display,
            IReviewUtility utility)
        {
            reviewManagerDAL = reviewManager;
            reviewDisplay = display;
            reviewUtility = utility;
        }
        public ReviewManager(IReviewManagerDALcrud reviewManager)
        {

        }

       

        public bool AddReview(ReviewDTO reviewDTO)
        {
           return reviewManagerDAL.AddReview(reviewDTO);
        }
        public bool UpdateReview(ReviewDTO reviewDTO)
        {
           return  reviewManagerDAL.UpdateReview(reviewDTO);
        }
        public DataTable GetAllReview()
        {
            return reviewDisplay.GetAllReview();
        }
        public int GetReviewByTitle(string title)
        {
            return  reviewDisplay.GetReviewByTitle(title);
        }
        public List<string> GetAllReviewTitles()
        {
            return reviewUtility.GetAllReviewTitles();
        }
        public DataTable GetReviewByID(int id)
        {
            return reviewDisplay.GetReviewById(id);
        }
        public DataTable GetReviewByMedia(int id)
        {
            return reviewDisplay.GetReviewByMedia(id);
        }
        public bool AddArchiveReview(ReviewDTO reviewDTO)
        {
            return reviewManagerDAL.AddArchiveReview(reviewDTO);
        }
        public bool DeleteReview(int id)
        {
            return reviewManagerDAL.DeleteReview(id);
        }
        public ReviewDTO GetActualReviewByMedia(int id)
        {
            return reviewDisplay.GetActualReviewByMedia(id);
        }
        public DataTable GetAllArchivedReview()
        {
            return reviewManagerDAL.GetAllArchivedReview();
        }
        public List<ReviewDTO> DatagridToList(DataTable dataTable)
        {
            return reviewUtility.DatagridToList(dataTable);
        }
      
    }
}
