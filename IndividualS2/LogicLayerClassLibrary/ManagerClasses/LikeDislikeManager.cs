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
        public int AddLike(LikeDislikeDTO likeDTO)
        {
            return likeDislikeManager.AddLike(likeDTO);
        }
        public int AddDislike(LikeDislikeDTO dislikeDTO)
        {
            return likeDislikeManager.AddDislike(dislikeDTO);
        }
        public bool CheckUserLiked(LikeDislikeDTO c)
        {
            return likeDislikeManager.CheckUserLiked(c);
        }
        public void RemoveLike(LikeDislikeDTO c)
        {
             likeDislikeManager.RemoveLike(c);
        }
        public void RemoveDislike(LikeDislikeDTO c)
        {
             likeDislikeManager.RemoveDislike(c);
        }
        public void ToggleLikeDislike(LikeDislikeDTO c)
        {
             likeDislikeManager.ToggleLikeDislike(c);
        }
    }
}
