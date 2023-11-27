using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class LikeDislikeDTO
    {
        
        
            public int LikeDislikeID { get; set; }
            public int UserID { get; set; }
            public int MediaID { get; set; }
            public string LikeStatus { get; set; }
           
             public LikeDislikeDTO() { }
        

    }
}
