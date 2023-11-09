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
using WinFormsApp1;

namespace Desktop_App.Forms.TvSeriesManagerForms
{
    public partial class EditTvSeriesForm : Form
    {
        private MediaManager mediaManager;
        public EditTvSeriesForm()
        {
            InitializeComponent();
            mediaManager = new MediaManager(new MediaDAL());
            var mediaTable = mediaManager.GetAllTvSeries();
            MainForm.TrimDataTableStrings(mediaTable);
            dgvTvSeriesCollection.DataSource = mediaTable;
        }

        private void btnEditTvSeries_Click(object sender, EventArgs e)
        {
            if (tbDirector.Text == "" || tbTitle.Text == "" || tbActors.Text == "" || rtbDescription.Text == "")
            {
                throw new Exception();
            }
            MediaDTO mediaDTO = new MediaDTO();
            TvSeriesDTO tvSeriesDTO = new TvSeriesDTO();

            if (dgvTvSeriesCollection.SelectedRows.Count > 0)
            {
                var ele = (Genre)Enum.Parse(typeof(Genre), cbGenre.Text);
                var stat = (Status)Enum.Parse(typeof(Status), cbStatus.Text);
                mediaDTO.Title = tbTitle.Text;
                mediaDTO.Director = tbDirector.Text;
                mediaDTO.Actor = tbActors.Text;
                mediaDTO.Description = rtbDescription.Text;
                mediaDTO.Genre = ele;
                tvSeriesDTO.NrOfSeasons = Convert.ToInt32(tbNumberOfSeasons.Text);
                tvSeriesDTO.PilotDate = dtpPilotDate.Value;
                tvSeriesDTO.LastEpisodeDate = dtpLastEpDate.Value;
                tvSeriesDTO.Status = stat;
                
                int selectedID = Convert.ToInt32(dgvTvSeriesCollection.SelectedRows[0].Cells[0].Value);
                mediaDTO.Id = selectedID;
            }
            if (mediaManager.UpdateTvSeries(mediaDTO, tvSeriesDTO))
            {
                MessageBox.Show("Success");
                this.Close();
            }
            else
            {
                MessageBox.Show("fail");
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
