﻿using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Desktop_App.Forms
{
    public partial class AddMovieForm : Form
    {
        public AddMovieForm()
        {
            InitializeComponent();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;
            string director = tbDirector.Text;
            string actor = tbActors.Text;
            string description = rtbDescription.Text;
            Genre genre =(Genre)cbGenre.SelectedItem;
            DateFormat date = (DateFormat)dtpReleaseDate.Format;

            if (decimal.TryParse(tbDuration.Text, out decimal duration))
            {
                MediaManager.AddMovie(title, director,actor,description,genre,duration,date);
                
                MessageBox.Show("success");
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid rating input. Please enter a valid decimal value.");
            }
        }
    }
}
