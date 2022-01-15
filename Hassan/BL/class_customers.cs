using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantApp.BL
{
    class class_customers
    {
        public DataTable get_all_customers()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_customers", null);
            dal.close();
            return dt;
        }
        public DataTable get_all_users()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_users", null);
            dal.close();
            return dt;
        }
        public DataTable get_all_user()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_user", null);
            dal.close();
            return dt;
        }
        public DataTable get_all_admins()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_admins", null);
            dal.close();
            return dt;
        }
        public void add_customer(string name, string phone, string address)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@customer_name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@customer_phone", SqlDbType.NVarChar, 11);
            param[1].Value = phone;

            param[2] = new SqlParameter("@customer_address", SqlDbType.NVarChar, 150);
            param[2].Value = address;

            dal.execute_command("add_customer", param);
            dal.close();
        }

        public void add_user(string name, string pass, string auth,string act)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);
            param[1].Value = pass;

            param[2] = new SqlParameter("@auth", SqlDbType.VarChar, 5);
            param[2].Value = auth;

            param[3] = new SqlParameter("@state", SqlDbType.NVarChar, 3);
            param[3].Value = act;

            dal.execute_command("add_user", param);
            dal.close();
        }

        public void update_customer(string name, string phone, string address)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@phone", SqlDbType.NVarChar, 11);
            param[0].Value = phone;

            param[1] = new SqlParameter("@adress", SqlDbType.NVarChar, 150);
            param[1].Value = address;

            param[2] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[2].Value = name;

            dal.execute_command("update_customer", param);
            dal.close();
        }

        public void update_user_password(string name, string pass)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);
            param[1].Value = pass;



            dal.execute_command("update_user_password", param);
            dal.close();
        }

        public void delete_customer(int id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;


            dal.execute_command("delete_customer", param);
            dal.close();
        }

        public void delete_user(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;


            dal.execute_command("delete_user", param);
            dal.close();
        }

        public DataTable customers_search(string word)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@word", SqlDbType.NVarChar, 11);
            param[0].Value = word;
            DataTable dt = dal.select_data("customers_search", param);
            dal.close();
            return dt;
        }
        public DataTable get_customer_id(string phone)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@phone", SqlDbType.NVarChar, 11);
            param[0].Value = phone;
            DataTable dt = dal.select_data("get_customer_id", param);
            dal.close();
            return dt;
        }

        public DataTable verify_user_name(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            DataTable dt = dal.select_data("verify_user_name", param);
            dal.close();
            return dt;
        }
    }
}