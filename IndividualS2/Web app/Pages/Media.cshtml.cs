using DALClassLibrary.DALs;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using Service_Layer.Interfaces_PL_to_LL;
using System.Collections.Generic;

namespace Web_app.Pages
{

    [Authorize]
    public class MediaModel : PageModel
    {
        private readonly IMovieDisplay movieDisplay;
        private readonly IMediaManager mediaManager;
        private readonly ITvSeriesDisplay tvSeriesDisplay;

        public List<MediaDTO> Movies { get; set; }
        public List<MediaDTO> TvSeries { get; set; }
        
        public string Message { get; set; }

        public MediaModel(IMovieDisplay movieDisplay, IMediaManager mediaManager,ITvSeriesDisplay tvSeriesDisplay)
        {
            this.movieDisplay = movieDisplay;
            this.mediaManager = mediaManager;
            this.tvSeriesDisplay = tvSeriesDisplay;
        }

        public void OnGet(string? message)
        {
            
            Movies = mediaManager.DatagridToList(movieDisplay.GetAllMovies());
            TvSeries = mediaManager.DatagridToList(tvSeriesDisplay.GetAllTvSeries());
            Movies.AddRange(TvSeries);

            if (message != null)
            {
                Message = message;
            }
        }
    }
}
