using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
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
        public Login()
        {
            InitializeComponent();
            userManager = new UserManager(new UserDAL());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IUserManagerDAL userRepository = new UserDAL();
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            User currentUser = userRepository.Login(username, password);


            if (currentUser != null)
            {
                

                if (currentUser.RoleID == 1)
                {
                    Form openfrom = new MainForm();
                    openfrom.ShowDialog();
                }
            }
        }
    }
}
