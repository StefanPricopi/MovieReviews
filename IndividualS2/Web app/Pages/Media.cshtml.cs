using DALClassLibrary.DALs;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;
using System.Collections.Generic;

namespace Web_app.Pages
{
    [Authorize]
    public class MediaModel : PageModel
    {
        private readonly MediaManager mediaManager;
        private readonly MovieManager movieManager;

        public List<MediaDTO> media;
        public string Message;

        // Constructor with dependency injection
        public MediaModel(MediaManager mediaManager, MovieManager movieManager)
        {
            this.mediaManager = mediaManager;
            this.movieManager = movieManager;
        }

        public void OnGet(string? message)
        {
            media = mediaManager.DatagridToList(movieManager.GetAllMovies());

            if (message != null)
            {
                Message = message;
            }
        }
    }
}
