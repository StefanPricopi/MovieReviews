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
        
        public List<string> GetAllTitles();
        public int GetMediaByTitle(string title);
        public List<MediaDTO> DatagridToList(DataTable dt);
        public MediaDTO GetActualMediaByID(int id);
    }
}
