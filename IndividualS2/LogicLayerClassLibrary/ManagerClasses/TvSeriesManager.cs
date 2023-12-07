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
    public class TvSeriesManager : ITvSeriesManager
    {
        private ITvSeriesManagerDAL tvSeriesManagerDAL;
        private ITvSeriesDisplay tvSeriesDisplay;
        
        public TvSeriesManager(ITvSeriesManagerDAL tvSeriesManagerDAL,ITvSeriesDisplay tvSeriesDisplay)
        {
            this.tvSeriesManagerDAL = tvSeriesManagerDAL;
            this.tvSeriesDisplay = tvSeriesDisplay;

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
            return tvSeriesDisplay.GetAllTvSeries();
        }
        public DataTable SearchTvSeries(int id)
        {
            return tvSeriesDisplay.SearchTvSeries(id);
        }
    }
}
