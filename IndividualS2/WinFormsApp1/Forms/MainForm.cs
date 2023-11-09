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
using System.Data;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private ReviewManager reviewManager;
        private MediaManager mediaManager;
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
            using (EditReviewForm f3 = new EditReviewForm())
            {
                var result = f3.ShowDialog();
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
        private void ViewAllReviews()
        {
            var reviewTable = reviewManager.GetAllReview();
            TrimDataTableStrings(reviewTable);
            dataGridViewReview.DataSource = reviewTable;
        }
        private void ViewAllMovies()
        {
            var movieTable = mediaManager.GetAllMovies();
            TrimDataTableStrings(movieTable);
            dgvMovieCollection.DataSource = movieTable;
        }
        private void ViewAllTvSeries()
        {
            var mediaTable = mediaManager.GetAllTvSeries();
            TrimDataTableStrings(mediaTable);
            dgvTvSeriesCollection.DataSource = mediaTable;
        }
        private void AddRowDataGrid(Review r)
        {
            dataGridViewReview.Rows.Add(r.Title, r.Score, r.Description);
        }

        private void btnViewAllTvSeries_Click(object sender, EventArgs e)
        {
            ViewAllTvSeries();
        }
        public static void TrimDataTableStrings(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (row[column] is string stringValue)
                    {
                        row[column] = stringValue.Trim();
                    }
                }
            }
        }
    }
}