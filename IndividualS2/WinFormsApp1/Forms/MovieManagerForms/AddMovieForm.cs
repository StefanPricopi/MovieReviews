using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using DALClassLibrary.DALs;
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
using ModelLibrary.DTO;

namespace Desktop_App.Forms
{
    public partial class AddMovieForm : Form
    {
        private MediaManager mediaManager;
        private MovieManager movieManager;

        public AddMovieForm()
        {
            InitializeComponent();
            mediaManager = new MediaManager(new MediaDAL());
            movieManager = new MovieManager(new MovieDAL());

        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            try
            {
                MediaDTO mediaDTO = new MediaDTO();
                MovieDTO movieDTO = new MovieDTO();
                mediaDTO.Title = tbTitle.Text;
                mediaDTO.Director = tbDirector.Text;
                mediaDTO.Actor = tbActors.Text;
                mediaDTO.Description = rtbDescription.Text;
                Genre genre = (Genre)Enum.Parse(typeof(Genre), cbGenre.Text);
                mediaDTO.Genre = genre;

                DateTime date = dtpReleaseDate.Value;
                movieDTO.Date = date;

                if (decimal.TryParse(tbDuration.Text, out decimal duration))
                {
                    movieDTO.Duration = duration;
                    
                }
                else
                {
                    MessageBox.Show("Invalid rating input. Please enter a valid decimal value.");
                }
                if (movieManager.AddMovie(mediaDTO, movieDTO))
                {
                    MessageBox.Show("successful");
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
            
            catch (Exception ) 
            {
                MessageBox.Show("Invalid input. Please add values ");
            }
            
        }
    }
}
