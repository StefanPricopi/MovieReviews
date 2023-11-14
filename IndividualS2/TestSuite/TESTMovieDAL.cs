using DALClassLibrary.DALs;
using DALClassLibrary.Interfaces;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuite
{
    public class TESTMovieDAL : IMovieManagerDAL
    {
        public Dictionary<int, MediaDTO> media;
        public Dictionary<int, MovieDTO> movies;
        public TESTMovieDAL(Dictionary<int, MediaDTO> media, Dictionary<int, MovieDTO> movies) 
        {
            this.media = media ?? new Dictionary<int, MediaDTO>();
            this.movies = movies ?? new Dictionary<int, MovieDTO>();
        }
        public bool AddMovie(MediaDTO mediaDTO, MovieDTO movieDTO)
        {
            if (mediaDTO != null && movieDTO != null && mediaDTO.Id > 0)
            {
                if (media.ContainsKey(mediaDTO.Id))
                {
                    return false;
                }
                else
                {
                    media.Add(mediaDTO.Id, mediaDTO);
                    movies.Add(mediaDTO.Id, movieDTO);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public DataTable GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public DataTable SearchMovies(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMovie(MediaDTO mediaDTO, MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }
    }
}
