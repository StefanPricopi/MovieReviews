using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DALClassLibrary.DALs;
using LogicLayerClassLibrary;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Enums;
using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.DTO;

namespace Desktop_App.Forms.ReviewManagerForms
{
    public partial class EditReviewForm : Form
    {
        private int id;
        ReviewManager reviewManager;
        public EditReviewForm()
        {
            InitializeComponent();
            reviewManager = new ReviewManager(new ReviewDAL());
            var reviewTable = reviewManager.GetAllReview();
            dgvReview.DataSource = reviewTable;
        }

        private void btnEditReview_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text == "" || tbScore.Text == "" || rtbDescription.Text == "")
            {
                throw new Exception();
            }
            ReviewDTO reviewDTO = new ReviewDTO();

            if (dgvReview.SelectedRows.Count > 0)
            {
                reviewDTO.Title = tbTitle.Text;
                reviewDTO.Score = Convert.ToDecimal(tbScore.Text);
                reviewDTO.Description = rtbDescription.Text;
                reviewDTO.MediaID = Convert.ToInt32(tbMediaID.Text);
                int selectedID = Convert.ToInt32(dgvReview.SelectedRows[0].Cells[0].Value);
                reviewDTO.Id = selectedID;

            }
            if (reviewManager.UpdateReview(reviewDTO))
            {
                MessageBox.Show("Success");
                this.Close();
            }
            else
            {
                MessageBox.Show("fail");
            }
        }

        private void dgvReview_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReview.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvReview.SelectedRows[0];
                tbTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                tbScore.Text = selectedRow.Cells["Score"].Value.ToString();
                tbMediaID.Text = selectedRow.Cells["MediaID"].Value.ToString();
                rtbDescription.Text = selectedRow.Cells["Description"].Value.ToString();
            }
        }
    }
}
