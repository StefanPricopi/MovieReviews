using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using Microsoft.VisualBasic;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public  class MediaManager
    {
        private IMediaManagerDAL mediaManagerDAL;
        public static int MediaId = 4;
        public MediaManager(IMediaManagerDAL mediaManagerDAL)
        {
            this.mediaManagerDAL = mediaManagerDAL;

        }

        public bool AddMovie(MediaDTO mediaDTO, MovieDTO movieDTO)
        {
           return mediaManagerDAL.AddMovie(mediaDTO,movieDTO);
        }
        public bool UpdateMovie(MediaDTO mediaDTO, MovieDTO movieDTO)
        {
           return mediaManagerDAL.UpdateMovie(mediaDTO,movieDTO);
        }
        public bool AddTvSeries(MediaDTO mediaDTO,TvSeriesDTO tvSeriesDTO)
        {
            return mediaManagerDAL.AddTvSeries(mediaDTO,tvSeriesDTO);
        }
        public bool UpdateTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvseriesDTO)
        {
            return mediaManagerDAL.UpdateTvSeries(mediaDTO, tvseriesDTO);
        }
        public DataTable GetAllMovies()
        {
            return mediaManagerDAL.GetAllMovies();
        }
        public DataTable GetAllTvSeries()
        {
            return mediaManagerDAL.GetAllTvSeries();
        }
        public int GetMediaByTitle(string title)
        {
            return mediaManagerDAL.GetMediaByTitle(title);
        }
        public List<string> GetAllTitles()
        {
            return mediaManagerDAL.GetAllTitles();
        }

    }
}
