using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoBill
{
    public partial class UsersForm : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private SqlDataAdapter da;
        private DataSet ds;

        public UsersForm()
        {
            InitializeComponent();

            conn = Utils.DBUtil.getSQLConnection();
            cmd = new SqlCommand();
            da = new SqlDataAdapter();
            ds = new DataSet();

            loadUsers();
        }

        private void loadUsers() {
            try
            {
                conn.Open();
                ds.Clear();
                cmd = conn.CreateCommand();
                cmd.CommandText = "select id, username from users";
                da.SelectCommand = cmd;
                da.Fill(ds, "users");

                dataGridUsers.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                conn.Close();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUsersForm addUser = new AddUsersForm();
            addUser.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadUsers();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePassword = new ChangePasswordForm();
            changePassword.ShowDialog();
        }
    }
}
