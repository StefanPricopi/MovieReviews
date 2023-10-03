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
    internal class Movie : Media
    {

        private decimal Duration {  get; set; } 
        private DateFormat Date {  get; set; }

        Movie(int id, string title, string director, string actor, string description, Genre genre,decimal duration,DateFormat date) :base(id, title, director, actor, description,genre)
        {
            Duration = duration;
            Date = date;
        }
    }
}
