using Desktop_App.Forms;
using Desktop_App.Forms.MovieManagerForms;
using Desktop_App.Forms.ReviewManagerForms;
using Desktop_App.Forms.TvSeriesManagerForms;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using DALClassLibrary.DALs;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private ReviewManager reviewManager;
        private TESTReviewDAL reviewDAL;
        private MediaManager mediaManager;
        private TESTMediaDAL mediaDAL = new TESTMediaDAL();
        public MainForm()
        {
            InitializeComponent();
            reviewManager = new ReviewManager(new ReviewDAL());
            mediaManager = new MediaManager(new MediaDAL());
            ViewAllReviews();
            ViewAllMovies();
            ViewAllTvSeries();
            dataGridViewReview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovieCollection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTvSeriesCollection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            if (dataGridViewReview.SelectedRows.Count > 0)
            {
                int i = dataGridViewReview.SelectedRows[0].Index;
                Review r = reviewManager.GetReviewById(i);

                using (EditReviewForm f3 = new EditReviewForm(r))
                {
                    var result = f3.ShowDialog();
                }
            }

        }

        private void btnViewAllReview_Click(object sender, EventArgs e)
        {
            ViewAllReviews();
        }

        private void btnSearchReview_Click(object sender, EventArgs e)
        {


            AddRowDataGrid(reviewManager.GetReviewById(Convert.ToInt32(tbSearchReviewTitle.Text)));
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
        private void btnViewAllMovies_Click(object sender, EventArgs e)
        {
            ViewAllMovies();
        }
        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            dgvMovieCollection.Rows.Clear();
            AddRowMovieGrid((Movie)mediaDAL.GetMediaByTitle(tbSearchMovieTitle.Text));
        }
        private void ViewAllReviews()
        {
            var reviewTable = reviewManager.GetAllReview();

            dataGridViewReview.DataSource = reviewTable;


        }
        private void ViewAllMovies()
        {

            var mediaTable = mediaManager.GetAllMovies();

            dgvMovieCollection.DataSource = mediaTable;

        }
        private void ViewAllTvSeries()
        {

            var mediaTable = mediaManager.GetAllTvSeries();

            dgvTvSeriesCollection.DataSource = mediaTable;

        }
        private void AddRowDataGrid(Review r)
        {
            dataGridViewReview.Rows.Add(r.Title, r.Score, r.Description);
        }
        private void AddRowMovieGrid(Movie m)
        {
            dgvMovieCollection.Rows.Add(m.Title, m.Director, m.Actor, m.Description, m.Duration, m.Date, m.Genre);
        }
    }
}