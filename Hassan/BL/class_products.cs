using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantApp.BL
{
    class class_products
    {
        public DataTable get_all_cat()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            
            DataTable dt = dal.select_data("get_all_cat", null);
            dal.close();
            return dt;
        }
        public DataTable get_products(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            DataTable dt = dal.select_data("get_products", param);
            dal.close();
            return dt;
        }
        public DataTable get_all_categories()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_categories", null);
            dal.close();
            return dt;
        }
        public DataTable get_product_id(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            DataTable dt = dal.select_data("get_product_id", param);
            dal.close();
            return dt;
        }
        public DataTable get_category_id(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            DataTable dt = dal.select_data("get_category_id", param);
            dal.close();
            return dt;
        }
        public DataTable get_all_products()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_products", null);
            dal.close();
            return dt;
        }

        public void add_product(string name,double price,string id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@product_name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@product_price", SqlDbType.Float);
            param[1].Value = price;

            param[2] = new SqlParameter("@category_name", SqlDbType.NVarChar,50);
            param[2].Value = id;

            dal.execute_command("add_product", param);
            dal.close();
        }

        public void add_category(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            

            dal.execute_command("add_category", param);
            dal.close();
        }

        public void update_product(string old_name,string new_name, double price, string id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@old_name", SqlDbType.NVarChar, 50);
            param[0].Value = old_name;

            param[1] = new SqlParameter("@new_name", SqlDbType.NVarChar, 50);
            param[1].Value = new_name;

            param[2] = new SqlParameter("@price", SqlDbType.Float);
            param[2].Value = price;

            param[3] = new SqlParameter("@category_name", SqlDbType.NVarChar,50);
            param[3].Value = id;

            

            dal.execute_command("update_product", param);
            dal.close();
        }

        public void update_category(string name, string old_name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@old_name", SqlDbType.NVarChar, 50);
            param[1].Value = old_name;
            
            
            dal.execute_command("update_category", param);
            dal.close();
        }


        public DataTable verify_product_name(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name",SqlDbType.NVarChar, 50);
            param[0].Value = name;
            DataTable dt = dal.select_data("verify_product_name",param);
            dal.close();
            return dt;
        }

        public DataTable verify_category_name(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            DataTable dt = dal.select_data("verify_category_name", param);
            dal.close();
            return dt;
        }

        public DataTable verify_update_product(string n,string old)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@new", SqlDbType.NVarChar, 50);
            param[0].Value = n;

            param[1] = new SqlParameter("@old", SqlDbType.NVarChar, 50);
            param[1].Value = old;

            DataTable dt = dal.select_data("verify_update_product", param);
            dal.close();
            return dt;
        }

        public DataTable verify_update_category_name(string name, string old_name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@old_name", SqlDbType.NVarChar, 50);
            param[1].Value = old_name;

            DataTable dt = dal.select_data("verify_update_category_name", param);
            dal.close();
            return dt;
        }

        public DataTable products_search(string word)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@word", SqlDbType.NVarChar, 50);
            param[0].Value = word;
            DataTable dt = dal.select_data("products_search", param);
            dal.close();
            return dt;
        }

        public void delete_product(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@product_name", SqlDbType.NVarChar, 50);
            param[0].Value = name;


            dal.execute_command("delete_product", param);
            dal.close();
        }

        public void delete_category(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;


            dal.execute_command("delete_category", param);
            dal.close();
        }


    }
}
