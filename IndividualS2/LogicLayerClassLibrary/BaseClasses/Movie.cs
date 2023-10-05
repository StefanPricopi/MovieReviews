using LogicLayerClassLibrary.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Classes
{
    public class Movie : Media
    {

        public decimal Duration {  get; set; } 
        public DateTime Date {  get; set; }

        public Movie(int id, string title, string director, string actor, string description, Genre genre,decimal duration,DateTime date) :base(id, title, director, actor, description,genre)
        {
            Duration = duration;
            Date = date;
        }
    }
}
