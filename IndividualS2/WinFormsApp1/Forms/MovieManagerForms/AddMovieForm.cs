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
using Service_Layer.Interfaces_PL_to_LL;
using ModelLibrary.Exceptions;

namespace Desktop_App.Forms
{
    public partial class AddMovieForm : Form
    {
        private IMediaManager mediaManager;
        private IMovieManager movieManager;

        public AddMovieForm(IMovieManager movieManager,IMediaManager mediaManager)
        {
            InitializeComponent();
            mediaManager = new MediaManager(new MediaDAL());
            this.movieManager = (MovieManager)movieManager;
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            try
            {
                int duration;
                MediaDTO mediaDTO = new MediaDTO();
                MovieDTO movieDTO = new MovieDTO();
                mediaDTO.Title = tbTitle.Text;
                mediaDTO.Director = tbDirector.Text;
                mediaDTO.Actor = tbActors.Text;
                mediaDTO.Description = rtbDescription.Text;

                
                Genre genre;
                if (Enum.TryParse(cbGenre.Text, out genre) && Enum.IsDefined(typeof(Genre), genre))
                {
                    mediaDTO.Genre = genre;

                    DateTime date = dtpReleaseDate.Value;
                    if (int.TryParse(tbDuration.Text, out duration) && duration >= 0)
                    {
                        movieDTO.Duration = duration;
                        movieDTO.Date = date;

                        if (movieManager.AddMovie(mediaDTO, movieDTO))
                        {
                            MessageBox.Show("Successful");
                        }
                    }
                    else
                    {
                        throw new MediaException("Invalid duration");
                    }
                }
                else
                {
                    throw new MediaException("Invalid genre");
                }
            }
            catch (MediaException ex)
            {
                MessageBox.Show($"Invalid Media: {ex.Message}");
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input. Please add values");
            }



        }
    }
}
