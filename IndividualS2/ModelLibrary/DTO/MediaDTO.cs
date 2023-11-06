using LogicLayerClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class MediaDTO
    {
        public int Id { get;  set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Description { get; set; }

        public Genre Genre { get; set; }

        public MediaDTO( )
        {
            
        }

        
    }
}
