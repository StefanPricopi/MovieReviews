using LogicLayerClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{

    public class MovieDTO : MediaDTO
    {
        public decimal Duration { get; set; }
        public DateTime Date { get; set; }

        public MovieDTO() 
        {
            
        }
    }

}
