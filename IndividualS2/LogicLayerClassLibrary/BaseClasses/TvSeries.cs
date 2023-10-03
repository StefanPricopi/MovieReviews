using LogicLayerClassLibrary.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LogicLayerClassLibrary.Classes
{
    internal class TvSeries:Media
    {
        private int NrOfSeasons {  get; set; }
        private DateFormat PilotDate {  get; set; }
        private DateFormat LastEpisodeDate { get; set;}
        private Status Status { get; set; }
        TvSeries(int id, string title, string director, string actor, string description, Genre genre,int numberOfSeasons,DateFormat pilotDate,DateFormat lastEpisodeDate, Status status):base(id, title, director, actor, description, genre)
        { 
            NrOfSeasons= numberOfSeasons;
            PilotDate= pilotDate;
            LastEpisodeDate= lastEpisodeDate;
            Status = status;
        }
    }
}
