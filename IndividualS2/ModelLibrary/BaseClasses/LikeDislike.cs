using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.BaseClasses
{
    public class LikeDislike
    {
            public int LikeDislikeID { get; set; }
            public int UserID { get; set; }
            public int MediaID { get; set; }
            public string LikeStatus { get; set; }

        public LikeDislike() { }
        public LikeDislike(int likeDislikeID, int userID, int mediaID, string likeStatus)
        {
            LikeDislikeID = likeDislikeID;
            UserID = userID;
            MediaID = mediaID;
            LikeStatus = likeStatus;
        }

        public LikeDislike(LikeDislikeDTO dto)
        {
            dto.UserID = UserID;
            dto.MediaID = MediaID;
            dto.LikeDislikeID = LikeDislikeID;
        }
    }
}
