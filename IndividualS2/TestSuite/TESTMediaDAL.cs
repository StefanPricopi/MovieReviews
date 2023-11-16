using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.DALs
{
    public class TESTMediaDAL : IMediaManagerDAL
    {
        public Dictionary<int, MediaDTO> media;
        public TESTMediaDAL(Dictionary<int, MediaDTO> mediaDictionary)
        {
            media = new Dictionary<int, MediaDTO>();
            
        }

        public List<MediaDTO> DatagridToList(DataTable dt)
        {
            throw new NotImplementedException();
        }

        public MediaDTO GetActualMediaByID(int id)
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public List<string> GetAllTitles()
        {
            if (media == null)
            {
                return new List<string>(); 
            }

            List<string> titles = new List<string>();
            foreach (var media in media.Values)
            {
                titles.Add(media.Title);
            }
            return titles;
        }
        [TestMethod]

        public int GetMediaByTitle(string title)
        {
            foreach (var media in media.Values)
            {
                if (media.Title == title)
                {
                    return media.Id;
                }
            }

            return -1;
        }
    }
}
