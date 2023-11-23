using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class CommentDTO
    {
        public int CommentID { get; private set; }
        public int ReviewID { get;  set; }
        public string CommentDescription { get; set; }
        public CommentDTO() { }
    }
}
