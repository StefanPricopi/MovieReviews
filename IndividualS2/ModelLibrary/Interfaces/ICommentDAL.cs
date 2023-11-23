using ModelLibrary.BaseClasses;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interfaces
{
    public interface ICommentDAL
    {
        public bool AddComment(CommentDTO commentDTO);
        public List<CommentDTO> GetAllComments();
    }
}
