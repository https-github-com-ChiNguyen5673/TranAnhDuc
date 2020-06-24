using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace QLKho.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }
        private DataProvider() { }
        private string strconnection = @"Data Source=DESKTOP-66KS2NF\SQLEXPRESS;Initial Catalog=S4_N18_QLNhaHang_NguyenLieu;user id=sa;password=sa123;";
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(strconnection))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                if (parameter != null)
                {
                    string[] ListPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                sqlConnection.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strconnection))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                if (parameter != null)
                {
                    string[] ListPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                command.CommandType = CommandType.Text;
                data = command.ExecuteNonQuery();
                sqlConnection.Close();
            }
            return data;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strconnection))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                if (parameter != null)
                {
                    string[] ListPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                command.CommandType = CommandType.Text;
                data = command.ExecuteScalar();
                sqlConnection.Close();
            }
            return data;
        }
    }

}
