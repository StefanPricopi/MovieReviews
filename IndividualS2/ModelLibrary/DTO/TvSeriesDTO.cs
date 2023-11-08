using LogicLayerClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    public class TvSeriesDTO
    {
        public int NrOfSeasons { get; set; }
        public DateTime PilotDate { get; set; }
        public DateTime LastEpisodeDate { get; set; }
        public Status Status { get; set; }
        public TvSeriesDTO()
        {
            
        }
    }
}
