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
        public string CommentDescription { get; set; }
        public Comment() { }
        public Comment(int commentID, int reviewID, string commentDescription)
        {
            CommentID = commentID;
            ReviewID = reviewID;
            CommentDescription = commentDescription;
        }
        public Comment(CommentDTO commentDTO)
        {
            CommentID = commentDTO.CommentID;
            ReviewID = commentDTO.ReviewID;
            CommentDescription = commentDTO.CommentDescription;
        }
    }
}
