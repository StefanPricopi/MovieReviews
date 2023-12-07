using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using Service_Layer.Interfaces_PL_to_LL;
using WinFormsApp1;

namespace Desktop_App.Forms.ReviewManagerForms
{
    public partial class AddReviewForm : Form
    {
        private ReviewManager reviewManager;
        private MediaManager mediaManager;

        public AddReviewForm(IReviewManager reviewManager, IMediaManager mediaManager)
        {
            InitializeComponent();
            this.reviewManager = (ReviewManager)reviewManager;
            this.mediaManager = (MediaManager)mediaManager;

            cbMediaTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMediaTitle.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbMediaTitle.DataSource = this.mediaManager.GetAllTitles();
            cbMediaTitle.DisplayMember = "Title";
        }



        private void btnAddReview_Click(object sender, EventArgs e)
        {
            try
            {
                ReviewDTO reviewDTO = new ReviewDTO();
                reviewDTO.Title = tbTitle.Text;
                reviewDTO.Description = rtbDescription.Text;

               
                decimal score;
                if (decimal.TryParse(tbScore.Text, out score) && (score >= 0 && score <= 5))
                {
                    reviewDTO.Score = score;

            
                    if (cbMediaTitle.Items.Contains(cbMediaTitle.Text))
                    {
                        int id = mediaManager.GetMediaByTitle(cbMediaTitle.Text);
                        reviewDTO.MediaID = id;

                        if (reviewManager.AddReview(reviewDTO))
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
                        MessageBox.Show("Please select a valid media title from the list");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a score between 0 and 5");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed: " + ex.Message);
            }



        }


    }
}
