using LogicLayerClassLibrary.Enums;
namespace LogicLayerClassLibrary.Classes

{
    public abstract class Media
    {

        public int Id { get; private set; }
        public string Title { get; set; }
        public string Director{ get; set; }
        public string Actor { get; set; }
        public string Description {  get; set; }
        
        public Genre Genre {  get; set; }

        public Media(int id,string title,string director,string actor,string description,Genre genre)
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