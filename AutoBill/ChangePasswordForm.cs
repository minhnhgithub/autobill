using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoBill.Model;
using AutoBill.Business;

namespace AutoBill
{
    public partial class ChangePasswordForm : Form
    {

        private IUserManager userManager;

        public ChangePasswordForm()
        {
            InitializeComponent();

            userManager = new UserManagerImpl();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                validate();

                User exist = new User(txtUsername.Text, txtOldPassword.Text);
                userManager.changePassword(exist, txtNewPassword.Text);

                lblError.Text = "Change password success";
                lblError.ForeColor = Color.Blue;
            }
            catch (Exception ex) {
                lblError.Text = ex.Message;
            }
        }

        private void resetErrorMessage() {
            lblError.ForeColor = Color.Red;
            lblError.Text = "";
        }

        private void validate() {
            string username = txtUsername.Text;
            string oldPass = txtOldPassword.Text;
            string newPass = txtNewPassword.Text;

            if (username.Length == 0)
            {
                throw new Exception("Username is empty");
            }

            if (oldPass.Length == 0)
            {
                throw new Exception("Old Password is empty");
            }

            if (newPass.Length == 0)
            {
                throw new Exception("New Password is empty");
            }

            User user = new User(username, oldPass);
            if (!userManager.authenticate(user)) {
                throw new Exception("Old password is not authorized");
            }
        }
    }
}
