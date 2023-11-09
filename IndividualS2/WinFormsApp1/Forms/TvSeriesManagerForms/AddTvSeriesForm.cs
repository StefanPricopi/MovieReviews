using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Enums;
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

namespace Desktop_App.Forms.TvSeriesManagerForms
{
    public partial class AddTvSeriesForm : Form
    {
        private TvSeriesManager tvSeriesManager;
        public AddTvSeriesForm()
        {
            InitializeComponent();
            tvSeriesManager = new TvSeriesManager(new TvSeriesDAL());
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
                Genre genre = (Genre)Enum.Parse(typeof(Genre), cbGenre.Text);
                mediaDTO.Genre = genre;

                DateTime Pilotdate = dtpPilotDate.Value;
                DateTime Enddate = dtpLastEpDate.Value;
                tvseriesDTO.PilotDate = Pilotdate;
                tvseriesDTO.LastEpisodeDate = Enddate;
                Status status = (Status)Enum.Parse(typeof(Status), cbStatus.Text);
                tvseriesDTO.Status = (Status)status;
                tvseriesDTO.NrOfSeasons = Convert.ToInt32(tbNumberOfSeasons.Text);
                if (tvSeriesManager.AddTvSeries(mediaDTO, tvseriesDTO))
                {
                    MessageBox.Show("successful");
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Invalid input. Please add values ");
            }
        }
    }
}
