using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.ManagerClasses
{
    internal class MediaManager : IMediaManager
    {

        private IMediaManager movieManager;
        private List<Media> MediaCollection = new List<Media>();
        public MediaManager()
        {
            movieManager = new MediaManager();
        }

        public bool AddMedia(Media m)
        {
            MediaCollection.Add(m);
            return true;

        }
        public bool UpdateMedia(Media m)
        {
            throw new NotImplementedException();
        }

        public List<Media> GetAllMedia()
        {
            throw new NotImplementedException();
        }

        public Media GetMediaById(int id)
        {
            throw new NotImplementedException();
        }


    }
}
