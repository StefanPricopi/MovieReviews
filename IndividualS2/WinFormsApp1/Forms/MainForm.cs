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
using ModelLibrary.DTO;
using Service_Layer.Interfaces_PL_to_LL;
using LogicLayerClassLibrary.Interfaces;
using ModelLibrary.Interfaces;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private readonly IReviewManager reviewManager;
        private readonly IMediaManager mediaManager;
        private readonly ITvSeriesManager tvSeriesManager;
        private readonly IMovieManager movieManager;

        public MainForm(
            IReviewManager reviewManager,
            IMediaManager mediaManager,
            ITvSeriesManager tvSeriesManager,
            IMovieManager movieManager)
        {
            InitializeComponent();

            this.reviewManager = reviewManager;
            this.mediaManager = mediaManager;
            this.tvSeriesManager = tvSeriesManager;
            this.movieManager = movieManager;

            InitializeUI();
        }

        private void InitializeUI()
        {
            ViewAllReviews();
            ViewAllMovies();
            ViewAllTvSeries();
            dataGridViewReview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovieCollection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTvSeriesCollection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            cbMovieTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMovieTitle.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbMovieTitle.DataSource = mediaManager.GetAllTitles();
            cbMovieTitle.DisplayMember = "Title";
            cbTvSeriesTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTvSeriesTitle.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTvSeriesTitle.DataSource = tvSeriesManager.GetAllTvSeries();
            cbTvSeriesTitle.DisplayMember = "Title";
            cbTitleReview.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTitleReview.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbTitleReview.DataSource = reviewManager.GetAllReviewTitles();
            cbTitleReview.DisplayMember = "Title";
            cb_MediaTitleReviews.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb_MediaTitleReviews.AutoCompleteSource = AutoCompleteSource.ListItems;
            cb_MediaTitleReviews.DataSource = mediaManager.GetAllTitles();
            cb_MediaTitleReviews.DisplayMember = "Title";
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
           

            using (AddReviewForm f3 = new AddReviewForm(reviewManager, mediaManager))
            {
                var result = f3.ShowDialog();
            }
        }



        private void btnUpdateReview_Click(object sender, EventArgs e)
        {
            using (EditReviewForm f3 = new EditReviewForm(reviewManager))
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

            int id = reviewManager.GetReviewByTitle(cbTitleReview.Text);
            var reviewTable = reviewManager.GetReviewByID(id);
            TrimDataTableStrings(reviewTable);
            dataGridViewReview.DataSource = reviewTable;
            if (reviewTable.Rows.Count == 0)
            {
                MessageBox.Show("No reviews were found for the selected criteria.");
                ViewAllReviews();
            }
            else
            {
                dgvMovieCollection.DataSource = reviewTable;
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
            var movieTable = movieManager.GetAllMovies();
            TrimDataTableStrings(movieTable);
            dgvMovieCollection.DataSource = movieTable;
        }
        private void ViewAllTvSeries()
        {
            var mediaTable = tvSeriesManager.GetAllTvSeries();
            TrimDataTableStrings(mediaTable);
            dgvTvSeriesCollection.DataSource = mediaTable;
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

        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            int id = mediaManager.GetMediaByTitle(cbMovieTitle.Text);

            var movieTable = movieManager.SearchMovies(id);
            TrimDataTableStrings(movieTable);

            if (movieTable.Rows.Count == 0)
            {
                MessageBox.Show("No movies found for the selected criteria.");
                ViewAllMovies();
            }
            else
            {
                dgvMovieCollection.DataSource = movieTable;
            }
        }


        private void btnSearchTvSeries_Click(object sender, EventArgs e)
        {
            int id = mediaManager.GetMediaByTitle(cbTvSeriesTitle.Text);

            var movieTable = tvSeriesManager.SearchTvSeries(id);
            TrimDataTableStrings(movieTable);
            dgvTvSeriesCollection.DataSource = movieTable;
            if (movieTable.Rows.Count == 0)
            {
                MessageBox.Show("No tv-series found for the selected criteria.");
                ViewAllTvSeries();
            }
            else
            {
                dgvMovieCollection.DataSource = movieTable;
            }
        }

        private void btn_SearchReviewForAMedia_Click(object sender, EventArgs e)
        {
            int id = mediaManager.GetMediaByTitle(cb_MediaTitleReviews.Text);
            var reviewTable = reviewManager.GetReviewByMedia(id);
            TrimDataTableStrings(reviewTable);
            dataGridViewReview.DataSource = reviewTable;
            if (reviewTable.Rows.Count == 0)
            {
                MessageBox.Show("No reviews found for the selected criteria.");
                ViewAllReviews();
            }
            else
            {
                dgvMovieCollection.DataSource = reviewTable;
            }
        }

        private void btnArchiveReview_Click(object sender, EventArgs e)
        {
            if (dataGridViewReview.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewReview.Rows[dataGridViewReview.SelectedCells[0].RowIndex].Cells[0].Value);
                if(reviewManager.GetActualReviewByMedia(id) != null)
                {
                    if (reviewManager.AddArchiveReview(reviewManager.GetActualReviewByMedia(id)))
                    {
                        reviewManager.DeleteReview(id);
                        MessageBox.Show("Archive was succesfull");
                    }
                }
                

            }
            else MessageBox.Show("wrong input");
        }

        private void BtnViewArchivedReview_Click(object sender, EventArgs e)
        {
            var mediaTable = reviewManager.GetAllArchivedReview();
            TrimDataTableStrings(mediaTable);
            dataGridViewReview.DataSource = mediaTable;
        }
    }
}