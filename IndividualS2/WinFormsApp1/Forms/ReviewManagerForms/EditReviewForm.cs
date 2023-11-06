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
using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.DTO;

namespace Desktop_App.Forms.ReviewManagerForms
{
    public partial class EditReviewForm : Form
    {
        private int id;
        ReviewManager reviewManager;
        public EditReviewForm(Review review)
        {
            InitializeComponent();
            id = review.Id;
            tbTitle.Text = review.Title;
            tbScore.Text = review.Score.ToString();
            rtbDescription.Text = review.Description;
            reviewManager = new ReviewManager(new ReviewDAL());
        }

        private void btnEditReview_Click(object sender, EventArgs e)
        {
            try
            {
                if(decimal.TryParse(tbScore.Text, out decimal rating) && tbTitle.Text != "" && rtbDescription.Text != "" && rating > 0 && rating < 11) 
                {
                    ReviewDTO r = new ReviewDTO();
                    r.Title = tbTitle.Text;
                    r.Description=rtbDescription.Text;
                    r.Score = rating;
                    reviewManager.UpdateReview(r);
                    MessageBox.Show("edit was succesful");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("edit was unsuccesful keep in mind score should be beetwin 1 and 10 , please check your input");
                }

            }
            catch (Exception)
            {
                
            }

        }
    }
}
