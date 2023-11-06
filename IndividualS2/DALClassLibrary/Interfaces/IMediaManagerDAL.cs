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
        public DataTable GetAllMedia();
        public Media GetMediaById(int id);
    }
}
