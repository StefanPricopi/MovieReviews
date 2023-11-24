using Microsoft.Data.SqlClient;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interfaces
{
    public interface ILikeDislike
    {
        public int AddLike(LikeDislikeDTO likeDTO, SqlTransaction transaction);
        public int AddDislike(LikeDislikeDTO dislikeDTO, SqlTransaction transaction);
        public bool CheckUserLiked(LikeDislikeDTO c);
        public void RemoveLike(LikeDislikeDTO c, SqlTransaction transaction);
        public void RemoveDislike(LikeDislikeDTO c, SqlTransaction transaction);
        public void ToggleLikeDislike(LikeDislikeDTO c);


    }
}
