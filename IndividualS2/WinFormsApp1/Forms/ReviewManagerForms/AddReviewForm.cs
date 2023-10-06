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
            try
            {
                string title = tbTitle.Text;
                string description = rtbDescription.Text;

                if (decimal.TryParse(tbScore.Text, out decimal rating)&&title!=""&&description!=""&& rating > 0 && rating < 11)
                {
                    ReviewManager.AddReview(title, rating, description);
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
