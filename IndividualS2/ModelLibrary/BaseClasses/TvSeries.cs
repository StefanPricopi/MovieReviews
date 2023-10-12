using LogicLayerClassLibrary.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LogicLayerClassLibrary.Classes
{
    public class TvSeries:Media
    {
        public int NrOfSeasons {  get; set; }
        public DateTime PilotDate {  get; set; }
        public DateTime LastEpisodeDate { get; set;}
        public Status Status { get; set; }
        public TvSeries(int id, string title, string director, string actor, string description, Genre genre,int numberOfSeasons,DateTime pilotDate,DateTime lastEpisodeDate, Status status):base(id, title, director, actor, description, genre)
        { 
            NrOfSeasons= numberOfSeasons;
            PilotDate= pilotDate;
            LastEpisodeDate= lastEpisodeDate;
            Status = status;
        }
    }
}
