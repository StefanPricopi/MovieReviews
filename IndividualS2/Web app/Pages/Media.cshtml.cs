using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;

namespace Web_app.Pages
{
    public class MediaModel : PageModel
    {
        public List<MediaDTO> media;
        public string Message;
        public void OnGet(string? message)
        {
            MediaManager mediaManager = new MediaManager(new MediaDAL());
            MovieManager movieManager = new MovieManager(new MovieDAL());
            media=mediaManager.DatagridToList(movieManager.GetAllMovies());
            
            if (message != null)
            {
                Message = message;
            }
        }
    }
}
