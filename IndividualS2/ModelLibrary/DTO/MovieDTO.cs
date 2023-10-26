using LogicLayerClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    internal class MovieDTO : MediaDTO
    {
        public decimal Duration { get; set; }
        public DateTime Date { get; set; }

        public MovieDTO(int id, string title, string director, string actor, string description, Genre genre, decimal duration, DateTime date) : base(id, title, director, actor, description, genre)
        {
            Duration = duration;
            Date = date;
        }
    }
}
