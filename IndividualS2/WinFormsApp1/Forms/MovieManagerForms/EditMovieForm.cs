using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.ManagerClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_App.Forms.MovieManagerForms
{
    public partial class EditMovieForm : Form
    {
        private string title;
        MediaManager mediaManager;
        public EditMovieForm(Movie m)
        {
            InitializeComponent();
            title = m.Title;
            tbActors.Text = m.Actor;
            tbDirector.Text = m.Director;
            tbTitle.Text = m.Title;
            tbDuration.Text = m.Duration.ToString();
            cbGenre.SelectedIndex = cbGenre.FindString(m.Genre.ToString());
            rtbDescription.Text = m.Description;
            dtpReleaseDate.Value = m.Date;
            
        }

        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            try 
            {  if(tbDirector.Text == ""||tbTitle.Text==""||tbActors.Text==""||rtbDescription.Text=="")
                {
                    throw new Exception();
                }
                var ele = (Genre)Enum.Parse(typeof(Genre), cbGenre.Text);
                mediaManager.UpdateMovie(title, tbTitle.Text, tbDirector.Text, tbActors.Text, rtbDescription.Text, ele, Convert.ToDecimal(tbDuration.Text), dtpReleaseDate.Value);
                MessageBox.Show("edit was succesful");
                this.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("edit was unsuccesful, check your input");
            }
        }
    }
}
