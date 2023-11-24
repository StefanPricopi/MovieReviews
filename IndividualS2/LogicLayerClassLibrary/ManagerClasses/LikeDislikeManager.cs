using Microsoft.Data.SqlClient;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public class LikeDislikeManager
    {
        private ILikeDislike likeDislikeManager;
        public LikeDislikeManager(ILikeDislike likeDislike) 
        {
            this.likeDislikeManager = likeDislike;
        }
        public int AddLike(LikeDislikeDTO likeDTO, SqlTransaction transaction)
        {
            return likeDislikeManager.AddLike(likeDTO, transaction);
        }
        public int AddDislike(LikeDislikeDTO dislikeDTO, SqlTransaction transaction)
        {
            return likeDislikeManager.AddDislike(dislikeDTO, transaction);
        }
        public bool CheckUserLiked(LikeDislikeDTO c)
        {
            return likeDislikeManager.CheckUserLiked(c);
        }
        public void RemoveLike(LikeDislikeDTO c, SqlTransaction transaction)
        {
             likeDislikeManager.RemoveLike(c, transaction);
        }
        public void RemoveDislike(LikeDislikeDTO c, SqlTransaction transaction)
        {
             likeDislikeManager.RemoveDislike(c, transaction);
        }
        public void ToggleLikeDislike(LikeDislikeDTO c)
        {
             likeDislikeManager.ToggleLikeDislike(c);
        }
    }
}
