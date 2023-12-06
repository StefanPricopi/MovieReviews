using DALClassLibrary.Interfaces;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces_PL_to_LL
{
    public interface ITvSeriesManager
    {
        public bool AddTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvSeriesDTO);

        public bool UpdateTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvseriesDTO);
        public DataTable GetAllTvSeries();
        public DataTable SearchTvSeries(int id);
    }
}
