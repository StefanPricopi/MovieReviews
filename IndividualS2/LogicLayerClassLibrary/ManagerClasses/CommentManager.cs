using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using Service_Layer.Interfaces_PL_to_LL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public class CommentManager : ICommentManager
    {
        private ICommentDAL commentManagerDAL;
        public CommentManager(ICommentDAL commentDAL)
        {
            commentManagerDAL = commentDAL;
        }
        public bool AddComment(CommentDTO commentDTO)
        {
            return commentManagerDAL.AddComment(commentDTO);
        }
        public List<CommentDTO> GetComments(int id)
        {
            return commentManagerDAL.GetAllComments(id);
        }
        public List<CommentDTO> GetAllCommentsByUser(int userID)
        {
            return commentManagerDAL.GetAllCommentsByUser(userID);
        }
        public bool DeleteComment(int commentId)
        {
            return commentManagerDAL.DeleteComment(commentId);
        }
    }
}
