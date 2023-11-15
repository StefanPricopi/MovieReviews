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
        
        public MediaManager(IMediaManagerDAL mediaManagerDAL)
        {
            this.mediaManagerDAL = mediaManagerDAL;

        }  
        public int GetMediaByTitle(string title)
        {
            return mediaManagerDAL.GetMediaByTitle(title);
        }
        public List<string> GetAllTitles()
        {
            return mediaManagerDAL.GetAllTitles();
        }
        public List<MediaDTO> DatagridToList(DataTable dataTable)
        {
            return mediaManagerDAL.DatagridToList(dataTable);
        }
        public MediaDTO GetActualMediaByID(int id)
        {
            return mediaManagerDAL.GetActualMediaByID(id);
        }

    }
}
