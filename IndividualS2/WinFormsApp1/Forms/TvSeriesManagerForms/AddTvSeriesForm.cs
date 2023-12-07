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

namespace Desktop_App.Forms.TvSeriesManagerForms
{
    public partial class AddTvSeriesForm : Form
    {
        private readonly ITvSeriesManager tvSeriesManager;

        public AddTvSeriesForm(ITvSeriesManager tvSeriesManager)
        {
            InitializeComponent();
            this.tvSeriesManager = tvSeriesManager;
        }
        private void btnAddTvSeries_Click(object sender, EventArgs e)
        {
            try
            {
                MediaDTO mediaDTO = new MediaDTO();
                TvSeriesDTO tvseriesDTO = new TvSeriesDTO();
                mediaDTO.Title = tbTitle.Text;
                mediaDTO.Director = tbDirector.Text;
                mediaDTO.Actor = tbActors.Text;
                mediaDTO.Description = rtbDescription.Text;

                
                if (Enum.TryParse(typeof(Genre), cbGenre.Text, out object genre) && Enum.IsDefined(typeof(Genre), genre))
                {
                    mediaDTO.Genre = (Genre)genre;

                    DateTime pilotDate = dtpPilotDate.Value;
                    DateTime endDate = dtpLastEpDate.Value;

                    if (endDate >= pilotDate) 
                    {
                        tvseriesDTO.PilotDate = pilotDate;
                        tvseriesDTO.LastEpisodeDate = endDate;

                       
                        if (Enum.TryParse(typeof(Status), cbStatus.Text, out object status) && Enum.IsDefined(typeof(Status), status))
                        {
                            tvseriesDTO.Status = (Status)status;

                            
                            int numberOfSeasons;
                            if (int.TryParse(tbNumberOfSeasons.Text, out numberOfSeasons) && numberOfSeasons > 0)
                            {
                                tvseriesDTO.NrOfSeasons = numberOfSeasons;

                                if (tvSeriesManager.AddTvSeries(mediaDTO, tvseriesDTO))
                                {
                                    MessageBox.Show("Successful");
                                }
                                else
                                {
                                    MessageBox.Show("Failed");
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
                        MessageBox.Show("End date cannot be before the start date");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid genre");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input. Please add values");
            }


        }
    }
}
