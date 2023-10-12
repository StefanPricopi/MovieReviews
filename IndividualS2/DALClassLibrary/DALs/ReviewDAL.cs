using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.DALs
{
    public class ReviewDAL:IReviewManagerDAL
    {
        public static List<Review> reviewList = new List<Review>()
            {
                new Review(0,"Peaky blinder",10,"Birmingham, England, 1919. In the aftermath of WW1, the Shelby family are making a name for themselves as bookmakers, racketeers and gangsters. Nominally the head of the family is the oldest brother, Arthur, but the real brains, ambition and drive in the organisation lies with Tommy, the second oldest. He will carve out an empire for himself that will stretch beyond Birmingham. This with the aid of his family and his gang, the Peaky Blinders."),
                new Review(1,"SpiderMan 3 ",3,"After a call from disappointed fans and Tom Holland, who says he wants to play Spider-Man for decades to come and apparently personally begged the top brass of the film studios to reopen talks, a deal was finally struck. This eternal tug-of-war has resulted in something very special, because this third Marvel Spider-Man film is drizzled with the thick sauce of all previous Sony Spider-Man versions.\r\n\r\nSpider-Man: No Way Homestarts where the previous part ended. The New York hurler's identity is out in the open and his reputation is being vilified by mood-making videos from The Daily Bugle. "),
                new Review(2,"Bojack the horseman",10,"Depresion, horses, tagam tagam tagam tagam tagam tagam tagam tagam tagam tagam tagam tagam tagam tagam tagam tagam"),
                new Review(3,"Parasite",8,"I learnt how to live in someone's basement and feed my family and provide rent free accomodation"),

            };
        public static int ReviewId = 4;

        public void AddReview(string title, decimal score, string description)
        {
            Review r = new Review(ReviewId, title, score, description);
            ReviewId++;
            reviewList.Add(r);
        }

        public  List<Review> GetAllReview()
        {

            return reviewList;

        }

        public  Review GetReviewById(int id)
        {
            foreach (Review r in reviewList)
            {
                if (r.Id == id)
                    return r;
            }
            return null;

        }

        public void UpdateReview(int id, string title, decimal score, string description)
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
