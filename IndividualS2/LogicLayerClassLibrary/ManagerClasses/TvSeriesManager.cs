using DALClassLibrary.Interfaces;
using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public class TvSeriesManager
    {
        private ITvSeriesManagerDAL tvSeriesManagerDAL;
        
        public TvSeriesManager(ITvSeriesManagerDAL tvSeriesManagerDAL)
        {
            this.tvSeriesManagerDAL = tvSeriesManagerDAL;

        }
        public bool AddTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvSeriesDTO)
        {
            return tvSeriesManagerDAL.AddTvSeries(mediaDTO, tvSeriesDTO);
        }
        public bool UpdateTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvseriesDTO)
        {
            return tvSeriesManagerDAL.UpdateTvSeries(mediaDTO, tvseriesDTO);
        }
        public DataTable GetAllTvSeries()
        {
            return tvSeriesManagerDAL.GetAllTvSeries();
        }
        public DataTable SearchTvSeries(int id)
        {
            return tvSeriesManagerDAL.SearchTvSeries(id);
        }
    }
}
