using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoBill.Model;
using System.Data.SqlClient;

namespace AutoBill.Business
{
    class UserManagerImpl : IUserManager
    {
        private SqlConnection conn;
        private SqlCommand cmd;

        public UserManagerImpl() {
            conn = Utils.DBUtil.getSQLConnection();
        }

        public void add(User user) {
            string query = "insert into users(username, password) values(@username, @password)";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@username", user.getUsername());
            cmd.Parameters.AddWithValue("@password", user.getPassword());

            try {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool isExistUser(String username)
        {
            string query = "select 1 from users where username=@username";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@username", username);

            SqlDataReader dr = null;
            try
            {
                conn.Open();

                dr = cmd.ExecuteReader();
                
                return dr.Read() && dr.HasRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        public bool authenticate(User user) {
            string username = user.getUsername();
            string password = user.getPassword();

            string query = "select 1 from users where username=@username and password=@password";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            SqlDataReader dr = null;
            try
            {
                conn.Open();

                dr = cmd.ExecuteReader();

                return dr.Read() && dr.HasRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        public void changePassword(User exist, string newPassword) {
            string username = exist.getUsername();

            string query = "update users set password=@password where username=@username";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", newPassword);

            try
            {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }   
    }
}
