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
    public static class MediaManager
    {


        public static List<Media> MediaCollection = new List<Media>()
        {     
        };
        
        public static int MediaId = 0;
        public static void AddMovie(string title,string director,string actor,string description,Genre genre,decimal duration,DateTime date)
        {
            Media m = new Movie(MediaId, title, director, actor, description, genre,duration,date);
            MediaId++;
            MediaCollection.Add(m);

        }
        public static void UpdateMovie(string oldtitle,string newtitle, string director, string actor, string description, Genre genre, decimal duration, DateTime date)
        {
            foreach (Media m in MediaCollection)
            {
                if (m.Title == oldtitle)
                {
                    Movie movie = m as Movie;
                    m.Title = newtitle;
                    m.Director = director;
                    m.Actor = actor;
                    m.Description = description;
                    m.Genre = genre;
                    movie.Date = date;
                    movie.Duration = duration;
                }
            }
        }

        public static List<Media> GetAllMedia()
        {
            return MediaCollection;
        }

        public static Media GetMediaByTitle(string title)
        {
            foreach (Media m in MediaCollection)
            {
                if (m.Title == title)
                    return m;
            }
            throw new Exception("please input values");
        }


    }
}
