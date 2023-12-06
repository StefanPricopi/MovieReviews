using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces_PL_to_LL
{
    public interface ICommentManager
    {
        public bool AddComment(CommentDTO commentDTO);
        public List<CommentDTO> GetComments(int id);
        public List<CommentDTO> GetAllCommentsByUser(int userID);
    }
}
