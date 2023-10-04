using Desktop_App.Forms;
using Desktop_App.Forms.MovieManagerForms;
using Desktop_App.Forms.ReviewManagerForms;
using Desktop_App.Forms.TvSeriesManagerForms;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private List<Review> reviewToShow = new List<Review>();
        private ReviewManager reviewManager;
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(List<Review> Reviews)
        {
            InitializeComponent();
            this.reviewToShow = Reviews;


            Debug.WriteLine($"Number of reviews received: {reviewToShow.Count}");
        }

        private void InitializeDataGridView()
        {


            // Populate the DataGridView with reviews
            foreach (var review in reviewToShow)
            {
                dataGridViewReview.Rows.Add(review.Title, review.Score, review.Description);
            }
        }




        private void btnAddMovie_Click_1(object sender, EventArgs e)
        {
            using (AddMovieForm f3 = new AddMovieForm())
            {

                var result = f3.ShowDialog();

            }
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            using (EditMovieForm f3 = new EditMovieForm())
            {
                var result = f3.ShowDialog();
            }
        }

        private void btnAddTvSeries_Click(object sender, EventArgs e)
        {
            using (AddTvSeriesForm f3 = new AddTvSeriesForm())
            {
                var result = f3.ShowDialog();
            }
        }

        private void btnUpdateTvSeries_Click(object sender, EventArgs e)
        {
            using (EditTvSeriesForm f3 = new EditTvSeriesForm())
            {
                var result = f3.ShowDialog();
            }
        }

        private void btnAddReview_Click(object sender, EventArgs e)
        {
            using (AddReviewForm f3 = new AddReviewForm())
            {

                var result = f3.ShowDialog();

            }
        }

        private void btnUpdateReview_Click(object sender, EventArgs e)
        {
            using (EditReviewForm f3 = new EditReviewForm())
            {
                var result = f3.ShowDialog();
            }
        }

        private void btnViewAllReview_Click(object sender, EventArgs e)
        {
            InitializeDataGridView();
            reviewManager.GetAllReview();
        }
    }
}