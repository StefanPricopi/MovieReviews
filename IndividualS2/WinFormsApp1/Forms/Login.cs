using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Service_Layer.Interfaces_PL_to_LL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace Desktop_App.Forms
{
    public partial class Login : Form
    {
        private readonly UserManager userManager;
        private readonly IReviewManager reviewManager;
        private readonly IMediaManager mediaManager;
        private readonly ITvSeriesManager tvSeriesManager;
        private readonly IMovieManager movieManager;

        public Login(IReviewManager reviewManager,
            IMediaManager mediaManager,
            ITvSeriesManager tvSeriesManager,
            IMovieManager movieManager)
        {          
            InitializeComponent(); 

            this.reviewManager = reviewManager;
            this.mediaManager = mediaManager;
            this.tvSeriesManager = tvSeriesManager;
            this.movieManager = movieManager;
            userManager = new UserManager(new UserDAL());
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IUserManagerDAL userRepository = new UserDAL();
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }

                User currentUser = userManager.Login(username, password);

                if (currentUser != null)
                {
                    if (currentUser.RoleID == 1)
                    {
                        var mainForm = new MainForm(reviewManager, mediaManager, tvSeriesManager, movieManager);
                        mainForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
