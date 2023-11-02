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
    public class TESTMediaDAL : IMediaManagerDAL
    {
        public static List<Media> MediaCollection = new List<Media>()
        {
            new Movie(1,"Snow white","Marc Webb","Rachel Zegler","The Grimm fairy tale gets a Technicolor treatment in Disney's first animated feature. Jealous of Snow White's beauty, the wicked queen orders the murder of her innocent stepdaughter, but later discovers that Snow White is still alive and hiding in a cottage with seven friendly little miners. Disguising herself as a hag, the queen brings a poisoned apple to Snow White, who falls into a death-like sleep that can be broken only by a kiss from the prince.\r\n",Genre.Drama,90,new DateTime(2024,10,10)),
            new Movie(2,"Godfather","Francis Ford Coppola","Al Pacino","The life of the gangsters in america",Genre.Drama,120,new DateTime(1972,02,15)),
            new TvSeries(3,"Breaking bad"," Vince Gilligan","Aaron Paul","Set in Albuquerque, New Mexico, between 2008 and 2010,[8] Breaking Bad follows Walter White, a struggling, frustrated high school chemistry teacher who transforms into a ruthless kingpin in the local methamphetamine drug trade, driven to provide for his family financially after being diagnosed with inoperable lung cancer. Initially making only small batches of meth with his former student Jesse Pinkman in a rolling meth lab, Walter and Jesse eventually expand to make larger batches of special blue meth that is incredibly pure and creates high demand. Walter takes on the name \"Heisenberg\" to mask his identity. Because of his drug-related activities, Walter eventually finds himself at odds with his family, the Drug Enforcement Administration (DEA) through his brother-in-law Hank Schrader, the local gangs, and the Mexican drug cartels (including their regional distributors), putting him and his family's lives at risk.",Genre.Drama,120,new DateTime(2008,02,15),new DateTime(2016,05,20),Status.Finished),
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
