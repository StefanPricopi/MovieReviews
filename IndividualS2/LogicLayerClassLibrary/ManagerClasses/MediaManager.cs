using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace LogicLayerClassLibrary.ManagerClasses
{
    public  class MediaManager
    {
        private IMediaManagerDAL mediaManagerDAL;
        public static int MediaId = 4;
        public MediaManager(IMediaManagerDAL mediaManagerDAL)
        {
            this.mediaManagerDAL = mediaManagerDAL;
        }

        public void AddMovie(string title, string director, string actor, string description, Genre genre, decimal duration, DateTime date)
        {
            mediaManagerDAL.AddMovie(title, director, actor, description, genre,duration,date);
        }
        public void UpdateMovie(string oldtitle, string newtitle, string director, string actor, string description, Genre genre, decimal duration, DateTime date)
        {
            mediaManagerDAL.UpdateMovie(oldtitle, newtitle, director, actor, description,genre,duration,date);
        }
        public List<Media> GetAllMedia()
        {
            return mediaManagerDAL.GetAllMedia();
        }
        public Media GetMediaById(int id)
        {
            return mediaManagerDAL.GetMediaById(id);
        }

    }
}
