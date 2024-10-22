﻿using System;
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
using Service_Layer.Interfaces_PL_to_LL;
using WinFormsApp1;

namespace Desktop_App.Forms.ReviewManagerForms
{
    public partial class EditReviewForm : Form
    {
        private int id;
        ReviewManager reviewManager;
        MediaManager mediaManager;
        public EditReviewForm(IReviewManager reviewManager)
        {
            InitializeComponent();
            var reviewTable = reviewManager.GetAllReview();
            MainForm.TrimDataTableStrings(reviewTable);
            dgvReview.DataSource = reviewTable;
        }


        private void btnEditReview_Click(object sender, EventArgs e)
        {
            try
            {
                ReviewDTO reviewDTO = new ReviewDTO();

                if (dgvReview.SelectedRows.Count > 0)
                {
                    reviewDTO.Title = tbTitle.Text;

                    
                    decimal score;
                    if (decimal.TryParse(tbScore.Text, out score) && (score >= 0 && score <= 5 || score == 3.5m))
                    {
                        reviewDTO.Score = score;
                        reviewDTO.Description = rtbDescription.Text;

                       
                        int mediaID;
                        if (int.TryParse(tbMediaID.Text, out mediaID))
                        {
                            reviewDTO.MediaID = mediaID;

                            int selectedID = Convert.ToInt32(dgvReview.SelectedRows[0].Cells[0].Value);
                            reviewDTO.Id = selectedID;

                            if (reviewManager.UpdateReview(reviewDTO))
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
                            MessageBox.Show("Invalid Media ID");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a score between 0 and 5 ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
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
