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

namespace Desktop_App.Forms
{
    public partial class AddMovieForm : Form
    {
        private MediaManager mediaManager;
        
        public AddMovieForm()
        {
            InitializeComponent();
            mediaManager = new MediaManager(new MediaDAL());
            
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            try
            {
                string title = tbTitle.Text;
                string director = tbDirector.Text;
                string actor = tbActors.Text;
                string description = rtbDescription.Text;
                Genre genre = (Genre)Enum.Parse(typeof(Genre), cbGenre.Text);

                DateTime date = dtpReleaseDate.Value;

                if (decimal.TryParse(tbDuration.Text, out decimal duration))
                {
                    mediaManager.AddMovie(title, director, actor, description, genre, duration, date);

                    MessageBox.Show("success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid rating input. Please enter a valid decimal value.");
                }
            }
            
            catch (Exception ) 
            {
                MessageBox.Show("Invalid input. Please add values ");
            }
            
        }
    }
}
