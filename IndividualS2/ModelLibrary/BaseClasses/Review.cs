﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerClassLibrary.Classes
{
    public class Review
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public decimal Score { get; set; }
        public string Description { get; set; }
        

        public Review(int id, string title, decimal score, string description)
        {
            Id = id;
            Title = title;
            Score = score;
            Description = description;

        }


    }
}
