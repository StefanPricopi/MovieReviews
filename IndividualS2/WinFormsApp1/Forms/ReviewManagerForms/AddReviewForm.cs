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
                string title = tbTitle.Text;
                string description = rtbDescription.Text;

                if (decimal.TryParse(tbScore.Text, out decimal rating) && title != "" && description != "" && rating > 0 && rating < 11)
                {
                    ReviewDTO r = new ReviewDTO();
                    r.Title = title;
                    r.Description = description;
                    r.Score = rating;
                    reviewManager.AddReview(r);
                    MessageBox.Show("success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid input keep in mind rating is between 0 and 10. Please check your input.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input. Please check your input.");
            }


        }
    }
}
