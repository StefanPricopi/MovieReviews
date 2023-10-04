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

namespace Desktop_App.Forms.ReviewManagerForms
{
    public partial class EditReviewForm : Form
    {
        public EditReviewForm()
        {
            InitializeComponent();
        }
        public EditReviewForm(Review review)
        {
            InitializeComponent();
            tbTitle.Text = review.Title;
            tbScore.Text = review.Score.ToString();
            rtbDescription.Text = review.Description;
        }
    }
}
