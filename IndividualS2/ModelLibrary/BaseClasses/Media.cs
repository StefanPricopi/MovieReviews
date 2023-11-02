using LogicLayerClassLibrary.Enums;
using ModelLibrary.DTO;

namespace LogicLayerClassLibrary.Classes


{
    public abstract class Media
    {

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string Description { get; set; }

        public Genre Genre { get; set; }

        public Media(int id, string title, string director, string actor, string description, Genre genre)
        {
            Id = id;
            Title = title;
            Director = director;
            Actor = actor;
            Description = description;
            Genre = genre;

        }
        public MediaDTO MediaToMediaDTO()
        {
            return new MediaDTO()
            {

                Title = this.Title,
                Director = this.Director,
                Actor = this.Actor,
                Description = this.Description,
                Genre = this.Genre,
            };
        }
    }
}
     



        
 
