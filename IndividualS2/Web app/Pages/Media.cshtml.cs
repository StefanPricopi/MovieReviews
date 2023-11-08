using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_app.Pages
{
    public class MediaModel : PageModel
    {
        public List<Media> media;
        public string Message;
        public void OnGet(string? message)
        {
            MediaManager mediaManager = new MediaManager(new MediaDAL());

            if (message != null)
            {
                Message = message;
            }
        }
    }
}
