using LogicLayerClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.DTO
{
    internal class MediaDTO
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Description { get; set; }

        public Genre Genre { get; set; }

        public MediaDTO(int id, string title, string director, string actor, string description, Genre genre)
        {
            Id = id;
            Title = title;
            Director = director;
            Actor = actor;
            Description = description;
            Genre = genre;

        }
    }
}
