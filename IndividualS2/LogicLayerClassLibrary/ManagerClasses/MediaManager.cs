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
            new Media( 0,"Breaking bad","Vince Gilligan","Aaron paul","Teacher goes rouge",Enums.Genre.Drama),
            new Media( 0,"Better call saul","Vince Gilligan","Bob Odenkirk","Lawyer enters the crime world",Enums.Genre.Drama),
            
        };
        
        public static int MediaId = 2;
        public static void AddMovie(string title,string director,string actor,string description,Genre genre,decimal duration,DateFormat date)
        {
            Media m = new Movie(MediaId, title, director, actor, description, genre,duration,date);
            MediaId++;
            MediaCollection.Add(m);

        }
        public static void UpdateMovie(int id,string title, string director, string actor, string description, Genre genre, decimal duration, DateFormat date)
        {
            foreach (Media m in MediaCollection)
                if (m.GetType() == typeof (Movie) && m.Id == id)
            
                
                {
                    m.Title=title;
                    m.Director=director;
                    m.Actor=actor;
                    m.Description=description;
                    m.Genre=genre;
                    
                }
            
        }

        public static List<Media> GetAllMedia()
        {
            return MediaCollection;
        }

        public static Media GetMediaById(int id)
        {
            foreach (Media m in MediaCollection)
            {
                if (m.Id == id)
                    return m;
            }
            return null;
        }


    }
}
