using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Interfaces
{
    public  interface IMediaManagerDAL
    {
        public void AddMovie(string title, string director, string actor, string description, Genre genre, decimal duration, DateTime date);
        public void UpdateMovie(string oldtitle, string newtitle, string director, string actor, string description, Genre genre, decimal duration, DateTime date);
        public List<Media> GetAllMedia();
        public Media GetMediaById(int id);
    }
}
