using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BL
{
    class class_report
    {

        public DataTable get_product_details_n(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar,50);
            param[0].Value = name;
            
            DataTable dt = dal.select_data("get_product_details_n", param);
            return dt;
        }
        public DataTable get_product_details_y(string name,DateTime from,DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar,50);
            param[0].Value = name;

            param[1] = new SqlParameter("@from", SqlDbType.DateTime);
            param[1].Value = from;

            param[2] = new SqlParameter("@to", SqlDbType.DateTime);
            param[2].Value = to;


            DataTable dt = dal.select_data("get_product_details_y", param);
            return dt;
        }
        public DataTable get_categories_details_n(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar,50);
            param[0].Value = name;

            DataTable dt = dal.select_data("get_categories_details_n", param);
            return dt;
        }
        public DataTable get_categories_details_y(string name, DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar,50);
            param[0].Value = name;

            param[1] = new SqlParameter("@from", SqlDbType.DateTime);
            param[1].Value = from;

            param[2] = new SqlParameter("@to", SqlDbType.DateTime);
            param[2].Value = to;


            DataTable dt = dal.select_data("get_categories_details_y", param);
            return dt;
        }

        public DataTable get_all_products_details_n()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_products_details_n", null);
            return dt;
        }
        public DataTable get_all_products_details_y(DateTime from,DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@from", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@to", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_all_products_details_y", param);
            return dt;
        }

        public DataTable get_details_report_of_user_n(string name)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            DataTable dt = dal.select_data("get_details_report_of_user_n", param);
            return dt;
        }
        public DataTable get_details_report_of_user(string name,DateTime from,DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@from", SqlDbType.DateTime);
            param[1].Value = from;

            param[2] = new SqlParameter("@to", SqlDbType.DateTime);
            param[2].Value = to;

            DataTable dt = dal.select_data("get_details_report_of_user", param);
            return dt;
        }

        public DataTable get_all_user_report_n()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            
            DataTable dt = dal.select_data("get_all_user_report_n", null);
            return dt;
        }
        public DataTable get_all_user_report_y(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];
            
            param[0] = new SqlParameter("@from", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@to", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_all_user_report_y", param);
            return dt;
        }

        public DataTable get_all_customer_report_n()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_customer_report_n", null);
            return dt;
        }
        public DataTable get_all_customer_report_y(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@from", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@to", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_all_customer_report_y", param);
            return dt;
        }

        public DataTable get_details_report_of_customer_y(int id ,DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@from", SqlDbType.DateTime);
            param[1].Value = from;

            param[2] = new SqlParameter("@to", SqlDbType.DateTime);
            param[2].Value = to;

            DataTable dt = dal.select_data("get_details_report_of_customer_y", param);
            return dt;
        }

        public DataTable get_details_report_of_customer_n(int id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = dal.select_data("get_details_report_of_customer_n", param);
            return dt;
        }
        public DataTable show_bill(int id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = dal.select_data("show_bill", param);
            return dt;
        }
        
        public void delete_bill(int id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dal.execute_command("delete_bill", param);
        }
        public DataTable get_all_bills_y(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];
            
            param[0] = new SqlParameter("@from", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@to", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_all_bills_y", param);
            return dt;
        }
        public DataTable get_all_bills_n()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_bills_n", null);
            return dt;
        }
        public DataTable get_bill(int id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            
            DataTable dt = dal.select_data("get_bill", param);
            return dt;
        }



        public DataTable show_bill_deleted(int id , DateTime dat)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@da", SqlDbType.DateTime);
            param[1].Value = dat;

            DataTable dt = dal.select_data("show_bill_deleted", param);
            return dt;
        }

        public void delete_bill_delete(int id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            dal.execute_command("delete_bill_delete", param);
        }
        public DataTable get_all_bills_deleted_t(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@s", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@e", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_all_bills_deleted_t", param);
            return dt;
        }
        public DataTable get_all_bills_deleted()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_bills_deleted", null);
            return dt;
        }
        public DataTable get_bill_delete(int id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = dal.select_data("get_bill_delete", param);
            return dt;
        }

        public DataTable get_all_bills_deleted_d_t(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@s", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@e", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_all_bills_deleted_d_t", param);
            return dt;
        }
        public DataTable get_all_bills_deleted_d()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_all_bills_deleted_d", null);
            return dt;
        }
        
        public DataTable get_last_day_bills(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@s", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@e", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_last_day_bills", param);
            return dt;
        }


        
        public DataTable all_purchases()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("all_purchases", null);
            return dt;
        }
        public DataTable all_purchases_top()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("all_purchases_top", null);
            return dt;
        }

        public DataTable all_purchases_d(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@s", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@e", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("all_purchases_d", param);
            return dt;
        }
        public void add_purchases(string d,float c,float weight,float price,DateTime date)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@d", SqlDbType.NVarChar,100);
            param[0].Value = d;

            param[1] = new SqlParameter("@c", SqlDbType.Float);
            param[1].Value = c;

            param[2] = new SqlParameter("@weight", SqlDbType.Float);
            param[2].Value = weight;

            param[3] = new SqlParameter("@price", SqlDbType.Float);
            param[3].Value = price;

            param[4] = new SqlParameter("@date", SqlDbType.DateTime);
            param[4].Value = date;

            dal.execute_command("add_purchases", param);
            dal.close();
        }



        public DataTable get_rest_bills_n(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@from", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("to", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_rest_bills_n", param);
            return dt;
        }

        public DataTable get_delevry_bills_n(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@from", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@to", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_delevry_bills_n", param);
            return dt;
        }



        public DataTable get_rest_bills(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@s", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@e", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_rest_bills", param);
            return dt;
        }

        public DataTable get_delevry_bills(DateTime from, DateTime to)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@s", SqlDbType.DateTime);
            param[0].Value = from;

            param[1] = new SqlParameter("@e", SqlDbType.DateTime);
            param[1].Value = to;

            DataTable dt = dal.select_data("get_delevry_bills", param);
            return dt;
        }

    }
}
