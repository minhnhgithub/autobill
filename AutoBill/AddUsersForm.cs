using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using AutoBill.Business;
using AutoBill.Model;

namespace AutoBill
{
    public partial class AddUsersForm : Form
    {
        private IUserManager userManager;

        public AddUsersForm()
        {
            InitializeComponent();

            userManager = new UserManagerImpl();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

            resetErrorMessage(); 

            try
            {
                validate();

                User user = new User(txtUsername.Text, txtPassword.Text);
                userManager.add(user);

                lblError.Text = "Add user " + txtUsername.Text + " success";
                lblError.ForeColor = Color.Blue;
            }
            catch (Exception ex) {
                lblError.ForeColor = Color.Red;
                lblError.Text = ex.Message;
            }
        }

        private void resetErrorMessage() {
            lblError.Text = "";
        }

        private void validate() {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string retypePassword = txtRetypePassword.Text;

            if (username.Length == 0) {
                throw new Exception("Username is empty");
            }

            if (password.Length == 0)
            {
                throw new Exception("Password is empty");
            }

            if (retypePassword.Length == 0)
            {
                throw new Exception("Retype Password is empty");
            }

            if (!password.Equals(retypePassword)) {
                throw new Exception("Retype Password is not match");
            }

            if (userManager.isExistUser(username))
            {
                throw new Exception("username is exist");
            }
        }
    }
}
