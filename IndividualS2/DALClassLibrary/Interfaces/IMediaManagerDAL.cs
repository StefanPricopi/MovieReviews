using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    public  interface IMediaManagerDAL
    {
        public bool AddMovie(MediaDTO mediaDTO, MovieDTO movieDTO);
        public bool UpdateMovie(MediaDTO mediaDTO,MovieDTO movieDTO);
        public bool AddTvSeries(MediaDTO mediaDTO,TvSeriesDTO tvseriesDTO);
        public bool UpdateTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvSeriesDTO);
        public List<string> GetAllTitles();
        public DataTable GetAllMovies();
        public DataTable GetAllTvSeries();
        public DataTable SearchMovies(int id);
        public DataTable SearchTvSeries(int id);

        public int GetMediaByTitle(string title);
    }
}
