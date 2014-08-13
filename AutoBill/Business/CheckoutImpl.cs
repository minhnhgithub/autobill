using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoBill.Model;
using System.Data.SqlClient;

namespace AutoBill.Business
{
    class CheckoutImpl : Checkoutable
    {

        private SqlConnection conn;
        private SqlCommand cmd;

        public CheckoutImpl() {
            conn = Utils.DBUtil.getSQLConnection();
        }

        public int start(Bill bill)
        {
            string query = "insert into bill(gametype, hands) OUTPUT inserted.id values(@gametype, @hands)";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@gametype", bill.getGameType().getGameType());
            cmd.Parameters.AddWithValue("@hands", bill.getHands());

            try
            {
                conn.Open();

                int id = (int) cmd.ExecuteScalar();
                
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                conn.Close();
            }
        }

        public void stop(Bill bill, int id)
        {
            string query = "update bill set totalprice=@totalprice where id=@id";
            cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@totalprice", bill.getTotalPrice());
            cmd.Parameters.AddWithValue("@id", id);

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
