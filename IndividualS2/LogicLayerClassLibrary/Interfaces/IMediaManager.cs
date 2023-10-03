using LogicLayerClassLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    public interface IMediaManager
    {
        public bool AddMedia(Media m);
        public bool UpdateMedia(Media m);
        public List<Media> GetAllMedia();
        public Media GetMediaById(int id);
    }
}
