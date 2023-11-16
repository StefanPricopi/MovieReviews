using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using ModelLibrary.DTO;
using WinFormsApp1;

namespace Desktop_App.Forms.ReviewManagerForms
{
    public partial class AddReviewForm : Form
    {
        private IReviewManagerDAL rev;
        private ReviewManager reviewManager;
        private MediaManager mediaManager;
        public AddReviewForm()
        {
            InitializeComponent();
            reviewManager = new ReviewManager(new ReviewDAL());
            mediaManager = new MediaManager( new MediaDAL());
            cbMediaTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMediaTitle.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbMediaTitle.DataSource = mediaManager.GetAllTitles();
            cbMediaTitle.DisplayMember = "Title";
        }
        private void btnAddReview_Click(object sender, EventArgs e)
        {
            try
            {
                ReviewDTO reviewDTO = new ReviewDTO();
                reviewDTO.Title = tbTitle.Text;
                reviewDTO.Description = rtbDescription.Text;
                reviewDTO.Score = Convert.ToInt32(tbScore.Text);
                int id = mediaManager.GetMediaByTitle(cbMediaTitle.Text);
                reviewDTO.MediaID = id;
                if (reviewManager.AddReview(reviewDTO))
                {
                    MessageBox.Show("successful");
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed");
            }
           
        }
    }
}
