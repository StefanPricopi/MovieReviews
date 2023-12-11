using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces_PL_to_LL
{
    public interface IMediaManager
    {
        public int GetMediaByTitle(string title);

        public List<string> GetAllTitles();
        public List<MediaDTO> DatagridToList(DataTable dataTable);
        public MediaDTO GetActualMediaByID(int id);
        public List<MediaDTO> RecommendationsAlgo(int id);
    }
}
