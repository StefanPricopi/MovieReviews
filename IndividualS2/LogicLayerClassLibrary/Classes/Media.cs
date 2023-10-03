using LogicLayerClassLibrary.Enums;
namespace LogicLayerClassLibrary.Classes

{
    public class Media
    {
        
        private int Id { get; }
        private string Title { get; set; }
        private string Director{ get; set; }
        private string Actor { get; set; }
        private string Description {  get; set; }
        
        private Genre Genre {  get; set; }

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