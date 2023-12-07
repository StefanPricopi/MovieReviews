using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Interfaces
{
    public interface ITvSeriesDisplay
    {
        public DataTable GetAllTvSeries();

        public DataTable SearchTvSeries(int id);
    }
}
