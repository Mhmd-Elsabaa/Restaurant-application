using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace RestaurantApp.DAL
{
    class data_access_layer
    {
        SqlConnection sql_connection;

        public data_access_layer()
        {
            if(Properties.Settings.Default.mode != "sql")
            {
                sql_connection = new SqlConnection(@"Server =" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.database
                                                + "; Integrated Security = true");
            }
            else
            {
                sql_connection = new SqlConnection(@"Server =" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.database
                                                + "; Integrated Security = false; User ID="+ Properties.Settings.Default.id
                                                + "; Password="+ Properties.Settings.Default.pass+"");
            }
            
        }

        public void open()
        {
            if(sql_connection.State != ConnectionState.Open)
            {
                sql_connection.Open();
            }
        }

        public void close()
        {
            if (sql_connection.State == ConnectionState.Open)
            {
                sql_connection.Close();
            }
        }

        public DataTable select_data(String stored_prosedure, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand(stored_prosedure,sql_connection);
            cmd.CommandType = CommandType.StoredProcedure;

            if(param != null)
            {
                for(int i=0;i<param.Length;i++)
                {
                    cmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void execute_command(String stored_prosedure, SqlParameter[] param)
        {
            open();
            SqlCommand cmd = new SqlCommand(stored_prosedure,sql_connection);
            cmd.CommandType = CommandType.StoredProcedure;

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            cmd.ExecuteNonQuery();
            close();
        }







    }
}