using Desktop_App.Forms;
using Desktop_App.Forms.MovieManagerForms;
using Desktop_App.Forms.ReviewManagerForms;
using Desktop_App.Forms.TvSeriesManagerForms;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ViewAllReviews();
            ViewAllMovies();
            dataGridViewReview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovieCollection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                Review r = ReviewManager.GetReviewById(i);

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

            dataGridViewReview.Rows.Clear();
            AddRowDataGrid(ReviewManager.GetReviewById(Convert.ToInt32(tbSearchReviewTitle.Text)));
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
            try
            {
                if (dgvMovieCollection.SelectedRows.Count > 0)
                {
                 string i = dgvMovieCollection.SelectedRows[0].Cells[0].Value.ToString();
                 Movie r = (Movie)MediaManager.GetMediaByTitle(i);
                 using (EditMovieForm f3 = new EditMovieForm(r))
                     {
                            var result = f3.ShowDialog();
                     }
                }
            }
            catch(Exception )
            {
                MessageBox.Show("Invalid input. Please check your selected rows ");
            }

        }
        private void btnViewAllMovies_Click(object sender, EventArgs e)
        {
            ViewAllMovies();
        }
        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            dgvMovieCollection.Rows.Clear();
            AddRowMovieGrid((Movie)MediaManager.GetMediaByTitle(tbSearchMovieTitle.Text));
        }
        private void ViewAllReviews()
        {
            dataGridViewReview.Rows.Clear();
            foreach (Review r in ReviewManager.reviewList)
            {
                AddRowDataGrid(r);
            }
        }
        private void ViewAllMovies()
        {

            dgvMovieCollection.Rows.Clear();
            foreach (Media m in MediaManager.MediaCollection)
            {
                if (m.GetType() == typeof(Movie))
                {
                    AddRowMovieGrid((Movie)m);
                }
            }
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