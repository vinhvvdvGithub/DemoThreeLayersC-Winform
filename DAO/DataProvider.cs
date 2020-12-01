using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DAO
{
    class DataProvider
    {

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;

            }
        }

        private DataProvider() { }
        //   SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// Ham connection
        /// </summary>
        //connect Lop
        //string connectionString = @"Data Source=.\;Initial Catalog=QLSV1;Integrated Security=True";
        //Connect Home
          string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=infoUser;Integrated Security=True";
        /// <summary>
        /// ham tra ve mot data table
        /// sqlcommand -> insert, update, delete (return first row in database)
        //SqlDataAdapter -> select (return table database)
        //dataset -> show tables like one database
        //datatable -> show one table in database
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// 
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] temp = new string[] { };
                    temp = query.Split(' ');
                    List<string> listpara = new List<string>();
                    foreach (string item in temp)
                    {
                        if (item[0] == '@')
                            listpara.Add(item);
                    }
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.AddWithValue(listpara[i], parameter[i]);
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {

            int data = 0;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] temp = new string[] { };
                    temp = query.Split(' ');
                    List<string> listpara = new List<string>();
                    foreach (string item in temp)
                    {
                        if (item.Contains("@"))
                            listpara.Add(item);
                    }
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.AddWithValue(listpara[i], parameter[i]);
                    }
                }
                data = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] temp = new string[100];
                    temp = query.Split(' ');
                    List<string> listpara = new List<string>();
                    foreach (string item in temp)
                    {
                        if (item.Contains("@"))
                            listpara.Add(item);
                    }
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.AddWithValue(listpara[i], parameter[i]);
                    }
                }
                data = command.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return data;
        }
        
    }
}
