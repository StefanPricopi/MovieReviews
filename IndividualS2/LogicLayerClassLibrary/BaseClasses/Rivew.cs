using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Classes
{
    public class Review
    {
        public int Id {  get;private set; }
        public string Title { get; set; }
        public decimal Score {  get; set; }
        public string Description { get; set; }
        private static int lastId = 0;

        public Review( string title, decimal score,string description)
        {
            Id = ++lastId;
            Title= title;
            Score = score;
            Description = description;
                
        }

        
    }
}
