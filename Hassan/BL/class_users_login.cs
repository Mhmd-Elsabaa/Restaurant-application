using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantApp.BL
{
    class class_users_login
    {
        public DataTable login(String name,String password)
        {

            try
            {
                DAL.data_access_layer dal = new DAL.data_access_layer(); 
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
                param[1] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);

                param[0].Value = name;
                param[1].Value = password;

                dal.open();
                DataTable dt = dal.select_data("users_login", param);
                return dt;
            }
            catch (Exception ex)
            {
                PL.connection_vars fcon = new PL.connection_vars();
                fcon.ShowDialog();
                DataTable dd = login(name, password);
                return dd;
            }
            

            
        }












    }
}
