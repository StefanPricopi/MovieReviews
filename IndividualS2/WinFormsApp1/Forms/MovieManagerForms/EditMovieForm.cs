﻿using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.DTO;
using Service_Layer.Interfaces_PL_to_LL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace Desktop_App.Forms.MovieManagerForms
{
    public partial class EditMovieForm : Form
    {
        private readonly  IMovieManager _movieManager;

        public EditMovieForm(IMovieManager movieManager)
        {
            InitializeComponent();
            this._movieManager = movieManager;

            var mediaTable = movieManager.GetAllMovies();
            MainForm.TrimDataTableStrings(mediaTable);

            dgvMovieCollection.DataSource = mediaTable;
        }

        private void btnEditMovie_Click(object sender, EventArgs e)
        {
            try
            {
                MediaDTO mediaDTO = new MediaDTO();
                MovieDTO movieDTO = new MovieDTO();

                if (dgvMovieCollection.SelectedRows.Count > 0)
                {
                    int duration;
                    Genre genre;
                    if (Enum.TryParse(cbGenre.Text, out genre) && Enum.IsDefined(typeof(Genre), genre))
                    {
                        mediaDTO.Title = tbTitle.Text;
                        mediaDTO.Director = tbDirector.Text;
                        mediaDTO.Actor = tbActors.Text;
                        mediaDTO.Description = rtbDescription.Text;
                        mediaDTO.Genre = genre;

                        if (int.TryParse(tbDuration.Text, out duration) && duration >= 0)
                        {
                            movieDTO.Duration = duration;
                            movieDTO.Date = dtpReleaseDate.Value;
                            int selectedID = Convert.ToInt32(dgvMovieCollection.SelectedRows[0].Cells[0].Value);
                            mediaDTO.Id = selectedID;

                            if (_movieManager.UpdateMovie(mediaDTO, movieDTO))
                            {
                                MessageBox.Show("Success");
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid duration");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid genre");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input values in the right format");
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
