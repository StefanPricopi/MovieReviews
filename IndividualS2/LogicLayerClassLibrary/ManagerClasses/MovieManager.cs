using DALClassLibrary.Interfaces;
using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using Service_Layer.Interfaces_PL_to_LL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public class MovieManager : IMovieManager
    {
        private IMovieManagerDAL movieManagerDAL;
        private IMovieDisplay movieDisplay;
        public MovieManager(IMovieManagerDAL movieManagerDAL,IMovieDisplay movieDisplay)
        {
            this.movieManagerDAL = movieManagerDAL;
            this.movieDisplay = movieDisplay;

        }
        public bool AddMovie(MediaDTO mediaDTO, MovieDTO movieDTO)
        {
            return movieManagerDAL.AddMovie(mediaDTO, movieDTO);
        }
        public bool UpdateMovie(MediaDTO mediaDTO, MovieDTO movieDTO)
        {
            return movieManagerDAL.UpdateMovie(mediaDTO, movieDTO);
        }
        public DataTable SearchMovies(int id)
        {
            return movieManagerDAL.SearchMovies(id);
        }
        public DataTable GetAllMovies()
        {
            return movieDisplay.GetAllMovies();
        }

    }
}
