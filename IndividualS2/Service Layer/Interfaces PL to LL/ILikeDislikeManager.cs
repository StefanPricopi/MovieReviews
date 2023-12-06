using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces_PL_to_LL
{
    public interface ILikeDislikeManager
    {
        public int AddLike(LikeDislikeDTO likeDTO);
        public int AddDislike(LikeDislikeDTO dislikeDTO);
        public bool CheckUserLiked(LikeDislikeDTO c);
        public void RemoveLike(LikeDislikeDTO c);
        public void RemoveDislike(LikeDislikeDTO c);
        public void ToggleLikeDislike(LikeDislikeDTO c);
        public LikeDislikeDTO GetLikeDislike(int id);
    }
}
