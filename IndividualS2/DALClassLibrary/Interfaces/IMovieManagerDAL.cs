using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.Interfaces
{
    public interface IMovieManagerDAL
    {
        public bool AddMovie(MediaDTO mediaDTO, MovieDTO movieDTO);
        public bool UpdateMovie(MediaDTO mediaDTO, MovieDTO movieDTO);
        public DataTable SearchMovies(int id);
        public DataTable GetAllMovies();
    }
}
