using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.Interfaces
{
    public interface ITvSeriesManagerDAL
    {
        public DataTable GetAllTvSeries();

        public DataTable SearchTvSeries(int id);
        public bool AddTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvseriesDTO);
        public bool UpdateTvSeries(MediaDTO mediaDTO, TvSeriesDTO tvSeriesDTO);
    }
}
