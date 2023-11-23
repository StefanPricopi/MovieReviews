using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.BaseClasses
{
    public class Comment
    {

        public int CommentID { get; private set; }
        public int ReviewID { get;  set; }
        public int UserID { get; set; }
        public string CommentDescription { get; set; }
        public Comment() { }
        public Comment(int commentID, int reviewID,int userID, string commentDescription)
        {
            CommentID = commentID;
            ReviewID = reviewID;
            UserID = userID;
            CommentDescription = commentDescription;
        }
        public Comment(CommentDTO commentDTO)
        {
            CommentID = commentDTO.CommentID;
            ReviewID = commentDTO.ReviewID;
            CommentDescription = commentDTO.CommentDescription;
            UserID = commentDTO.UserID;
        }
    }
}
