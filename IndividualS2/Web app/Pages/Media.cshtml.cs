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
<<<<<<< HEAD
           //media = mediaManager.GetAllMedia();
=======
            //media = mediaManager.GetAllMedia();
>>>>>>> 55c50650bb4d2d97f34eaa7cb2c50cfd784e8c76
            if (message != null)
            {
                Message = message;
            }
        }
    }
}
