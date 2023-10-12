using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALClassLibrary.DALs
{
    public class MediaDAL : IMediaManagerDAL
    {
        public static List<Media> MediaCollection = new List<Media>()
        {
            new Movie(1,"Snow white","Marc Webb","Rachel Zegler","Snow white and the 7 dwarfs",Genre.Drama,90,new DateTime(2024,10,10)),
            new Movie(2,"Godfather","Francis Ford Coppola","Al Pacino","The life of the gangsters in america",Genre.Drama,120,new DateTime(1972,02,15)),
            new TvSeries(3,"Breaking bad"," Vince Gilligan","Aaron Paul","The life of a teacher who decides to go rouge",Genre.Drama,120,new DateTime(2008,02,15),new DateTime(2016,05,20),Status.Finished),
            new TvSeries(4,"Better call Saul"," Vince Gilligan","Bob Odenkirk","The life of a lawyer who decides to go rouge",Genre.Drama,120,new DateTime(2017,02,15),new DateTime(2023,05,20),Status.Finished),
        };

        public static int MediaId = 0;
        public void AddMovie(string title, string director, string actor, string description, Genre genre, decimal duration, DateTime date)
        {
            Media m = new Movie(MediaId, title, director, actor, description, genre, duration, date);
            MediaId++;
            MediaCollection.Add(m);

        }
        public  void UpdateMovie(string oldtitle, string newtitle, string director, string actor, string description, Genre genre, decimal duration, DateTime date)
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

        public  List<Media> GetAllMedia()
        {
            return MediaCollection;
        }

        public Media GetMediaByTitle(string title)
        {
            foreach (Media m in MediaCollection)
            {
                if (m.Title == title)
                    return m;
            }
            throw new Exception("please input values");
        }
        
        public Media GetMediaById(int id)
        {
            foreach (Media m in MediaCollection)
            {
                if (m.Id == id)
                    return m;
            }
            throw new Exception("please input values");
        }
    }
}
