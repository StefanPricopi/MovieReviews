using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.DTO;
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
        MediaManager mediaManager;
        public EditMovieForm()
        {
            InitializeComponent();
            mediaManager = new MediaManager(new MediaDAL());
            var mediaTable = mediaManager.GetAllMovies();

            dgvMovieCollection.DataSource = mediaTable;

        }

        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            if (tbDirector.Text == "" || tbTitle.Text == "" || tbActors.Text == "" || rtbDescription.Text == "")
            {
                throw new Exception();
            }
            MediaDTO mediaDTO = new MediaDTO();
            MovieDTO movieDTO = new MovieDTO();

            if (dgvMovieCollection.SelectedRows.Count > 0)
            {
                var ele = (Genre)Enum.Parse(typeof(Genre), cbGenre.Text);
                mediaDTO.Title = tbTitle.Text;
                mediaDTO.Director = tbDirector.Text;
                mediaDTO.Actor = tbActors.Text;
                mediaDTO.Description = rtbDescription.Text;
                mediaDTO.Genre = ele;
                movieDTO.Duration = Convert.ToDecimal(tbDuration.Text);
                movieDTO.Date = dtpReleaseDate.Value;
                int selectedID = Convert.ToInt32(dgvMovieCollection.SelectedRows[0].Cells[0].Value);
                mediaDTO.Id = selectedID;
            }
            if (mediaManager.UpdateMovie(mediaDTO, movieDTO))
            {
                MessageBox.Show("Success");
                this.Close();
            }
            else
            {
                MessageBox.Show("fail");
            }




        }

        private void dgvMovieCollection_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMovieCollection.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMovieCollection.SelectedRows[0];

                tbTitle.Text = selectedRow.Cells["Title"].Value.ToString();

                tbDirector.Text = selectedRow.Cells["Director"].Value.ToString();
                dtpReleaseDate.Text = selectedRow.Cells["ReleaseDate"].Value.ToString();
                tbActors.Text = selectedRow.Cells["Actor"].Value.ToString();
                tbDuration.Text = selectedRow.Cells["Duration"].Value.ToString();
                rtbDescription.Text = selectedRow.Cells["Description"].Value.ToString();
                cbGenre.Text = selectedRow.Cells["Genre"].Value.ToString();

            }
        }
    }
}
