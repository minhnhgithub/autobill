using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using AutoBill.Utils;
using AutoBill.Business;
using AutoBill.Model;

namespace AutoBill
{
    public partial class LoginForm : Form
    {

        private IUserManager userManager;

        public LoginForm()
        {
            InitializeComponent();

            userManager = new UserManagerImpl();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try {
                validate();

                User user = new User(txtUsername.Text, txtPassword.Text);

                if (userManager.authenticate(user)) {
                    Program.isLoginSuccess = true;
                    this.Close();
                }
                else
                {
                    lblErrorMessage.Text = "Invalid username/password";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        private void validate() {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username.Length == 0) {
                throw new Exception("Empty username");
            }

            if (password.Length == 0) {
                throw new Exception("Empty password");
            }
        }
    }
}
