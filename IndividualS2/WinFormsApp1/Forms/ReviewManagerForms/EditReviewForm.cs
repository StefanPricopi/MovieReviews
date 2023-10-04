using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayerClassLibrary;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;

namespace Desktop_App.Forms.ReviewManagerForms
{
    public partial class EditReviewForm : Form
    {
        private int id;

        public EditReviewForm(Review review)
        {
            InitializeComponent();
            id = review.Id;
            tbTitle.Text = review.Title;
            tbScore.Text = review.Score.ToString();
            rtbDescription.Text = review.Description;
        }

        private void btnEditReview_Click(object sender, EventArgs e)
        {

            ReviewManager.UpdateReview(id, tbTitle.Text, Convert.ToDecimal(tbScore.Text), rtbDescription.Text);
            MessageBox.Show("edit was succesful");
            this.Close();
        }
    }
}
