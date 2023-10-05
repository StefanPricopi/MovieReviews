using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public static class ReviewManager
    {
        public static List<Review> reviewList = new List<Review>()
            {
                new Review(0,"abc",10,"abccccccccccc"),
                new Review(1,"abcafraf",7,"abcccccwdadcccccc"),
                new Review(2,"abcadaw",9,"abccccccdwadawccccc"),
                new Review(3,"abcddd",5,"abcccccccadaaaacccc"),

            };
        public static int ReviewId = 4;

        public static void AddReview(string title, decimal score, string description)
        {
            Review r = new Review(ReviewId, title, score, description);
            ReviewId++;
            reviewList.Add(r);
        }

        public static List<Review> GetAllReview()
        {

            return reviewList;

        }

        public static Review GetReviewById(int id)
        {
            foreach (Review r in reviewList)
            {
                if (r.Id == id)
                    return r;
            }
            return null;

        }

        public static void UpdateReview(int id, string title, decimal score, string description)
        {

            foreach (Review r in reviewList)
            {
                if (r.Id == id)
                {
                    r.Title = title;
                    r.Score = score;
                    r.Description = description;
                }
            }
        }
    }
}
