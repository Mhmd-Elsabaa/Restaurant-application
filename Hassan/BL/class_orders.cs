using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace RestaurantApp.BL
{
    class class_orders
    {
        public DataTable get_last_order_id()
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();

            DataTable dt = dal.select_data("get_last_order_id", null);
            dal.close();
            return dt;
        }
        public void add_order(int id, DateTime date, int customer_id,string salesman)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@date", SqlDbType.DateTime);
            param[1].Value = date;

            param[2] = new SqlParameter("@customer_id", SqlDbType.Int);
            param[2].Value = customer_id;

            param[3] = new SqlParameter("@sales_man", SqlDbType.NVarChar, 50);
            param[3].Value = salesman;

            dal.execute_command("add_order", param);
            dal.close();
        }
        public void add_order_f(int id, DateTime date, string salesman)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@date", SqlDbType.DateTime);
            param[1].Value = date;

            param[2] = new SqlParameter("@sales_man", SqlDbType.NVarChar, 50);
            param[2].Value = salesman;

            dal.execute_command("add_order_f", param);
            dal.close();
        }

        public void add_order_details(int order_id, string product_name, int quantity,float price, float discount, float total_price)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            dal.open();

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;

            param[1] = new SqlParameter("@product_name", SqlDbType.NVarChar,50);
            param[1].Value = product_name;

            param[2] = new SqlParameter("@quantity", SqlDbType.Int);
            param[2].Value = quantity;

            param[3] = new SqlParameter("@price", SqlDbType.Float);
            param[3].Value = price;

            param[4] = new SqlParameter("@discount", SqlDbType.Float);
            param[4].Value = discount;

            param[5] = new SqlParameter("@total_price", SqlDbType.Float);
            param[5].Value = total_price;

            dal.execute_command("add_order_details", param);
            dal.close();
        }
        public DataTable get_order_details(int id)
        {
            DAL.data_access_layer dal = new DAL.data_access_layer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DataTable dt = dal.select_data("get_order_details", param);
            return dt;
        }
    }
}
