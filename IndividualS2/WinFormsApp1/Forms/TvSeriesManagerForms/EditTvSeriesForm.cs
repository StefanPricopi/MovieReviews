using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Enums;
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

namespace Desktop_App.Forms.TvSeriesManagerForms
{
    public partial class EditTvSeriesForm : Form
    {
        private readonly ITvSeriesManager tvSeriesManager;
        private readonly IMediaManager mediaManager;

        public EditTvSeriesForm(ITvSeriesManager tvSeriesManager, IMediaManager mediaManager)
        {
            InitializeComponent();
            this.tvSeriesManager = tvSeriesManager;
            this.mediaManager = mediaManager;

            var mediaTable = tvSeriesManager.GetAllTvSeries();
            MainForm.TrimDataTableStrings(mediaTable);
            dgvTvSeriesCollection.DataSource = mediaTable;
        }

        private void btnEditTvSeries_Click(object sender, EventArgs e)
        {
            try
            {
                MediaDTO mediaDTO = new MediaDTO();
                TvSeriesDTO tvSeriesDTO = new TvSeriesDTO();

                if (dgvTvSeriesCollection.SelectedRows.Count > 0)
                {
                    var ele = cbGenre.Text;
                    var stat = cbStatus.Text;

                    if (Enum.TryParse(typeof(Genre), ele, out object genre) && Enum.IsDefined(typeof(Genre), genre))
                    {
                        mediaDTO.Genre = (Genre)genre;

                        if (Enum.TryParse(typeof(Status), stat, out object status) && Enum.IsDefined(typeof(Status), status))
                        {
                            mediaDTO.Title = tbTitle.Text;
                            mediaDTO.Director = tbDirector.Text;
                            mediaDTO.Actor = tbActors.Text;
                            mediaDTO.Description = rtbDescription.Text;
                            tvSeriesDTO.Status = (Status)status;

                            
                            int numberOfSeasons;
                            if (int.TryParse(tbNumberOfSeasons.Text, out numberOfSeasons) && numberOfSeasons > 0)
                            {
                                tvSeriesDTO.NrOfSeasons = numberOfSeasons;

                                
                                DateTime pilotDate = dtpPilotDate.Value;
                                DateTime endDate = dtpLastEpDate.Value;

                                if (endDate >= pilotDate)
                                {
                                    tvSeriesDTO.PilotDate = pilotDate;
                                    tvSeriesDTO.LastEpisodeDate = endDate;

                                    int selectedID = Convert.ToInt32(dgvTvSeriesCollection.SelectedRows[0].Cells[0].Value);
                                    mediaDTO.Id = selectedID;

                                    if (tvSeriesManager.UpdateTvSeries(mediaDTO, tvSeriesDTO))
                                    {
                                        MessageBox.Show("Success");
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("End date cannot be before the start date");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Number of seasons must be a positive integer");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid status");
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
                MessageBox.Show("Failed: " + ex.Message);
            }


        }

        private void dgvTvSeriesCollection_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTvSeriesCollection.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTvSeriesCollection.SelectedRows[0];

                tbTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                tbNumberOfSeasons.Text = selectedRow.Cells["NrOfSeasons"].Value.ToString();
                tbDirector.Text = selectedRow.Cells["Director"].Value.ToString();
                dtpPilotDate.Text = selectedRow.Cells["PilotDate"].Value.ToString();
                dtpLastEpDate.Text = selectedRow.Cells["EndDate"].Value.ToString();
                tbActors.Text = selectedRow.Cells["Actor"].Value.ToString();
                cbStatus.Text = selectedRow.Cells["Status"].Value.ToString();
                rtbDescription.Text = selectedRow.Cells["Description"].Value.ToString();
                cbGenre.Text = selectedRow.Cells["Genre"].Value.ToString();

            }
        }
    }
}
