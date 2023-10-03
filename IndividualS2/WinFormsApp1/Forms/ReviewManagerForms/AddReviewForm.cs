using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.ManagerClasses;
using WinFormsApp1;

namespace Desktop_App.Forms.ReviewManagerForms
{
    public partial class AddReviewForm : Form
    {

        public AddReviewForm()
        {
            InitializeComponent();
        }

        private void btnAddReview_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text;


            if (decimal.TryParse(tbScore.Text, out decimal rating))
            {

                string description = rtbDescription.Text;


                Review newReview = new Review(title, rating, description);

                List<Review> reviews = new List<Review>();
                reviews.Add(newReview);

                
                

                // Create an instance of  and pass the list of reviews
                MainForm reviewListForm = new MainForm(reviews);
                MessageBox.Show("review was added succesful");
                reviewListForm.Show();
                this.Close();



            }
            else
            {

                MessageBox.Show("Invalid rating input. Please enter a valid decimal value.");
            }

        }


    }
}
