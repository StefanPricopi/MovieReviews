using DALClassLibrary.Interfaces;
using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
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
        public MovieManager(IMovieManagerDAL movieManagerDAL)
        {
            this.movieManagerDAL = movieManagerDAL;

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
            return movieManagerDAL.GetAllMovies();
        }

    }
}
