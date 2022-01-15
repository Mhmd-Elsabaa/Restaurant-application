using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp.PL
{
    public partial class uc_bills : UserControl
    {
        BL.class_products prod = new BL.class_products();
        BL.class_orders order = new BL.class_orders();
        BL.class_customers cust = new BL.class_customers();
        BL.Class_printer rpt_print = new BL.Class_printer();

        string order_type = "s";

        DataTable dt = new DataTable();
        public void create_data_table()
        {
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("سعر المنتج");
            dt.Columns.Add("الكميه");
            dt.Columns.Add("% نسبه الخصم");
            dt.Columns.Add("المبلغ");

            bunifuCustomDataGrid3.DataSource = dt;
        }

        public uc_bills()
        {
            InitializeComponent();
            create_data_table();

            
        }

        
        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            label8.Visible = true;
            textBox3.Visible = true;
            order_type = "s";
        }
        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            txt_customer_name.Text = "";
            txt_customer_phone.Text = "";
            txt_customer_address.Text = "";
            bunifuFlatButton1.Visible = false;
            bunifuFlatButton2.Visible = false;
            panel4.Visible = true;

            label8.Visible = false;
            textBox3.Visible = false;
            order_type = "d";
        }

        private void uc_bills_Load(object sender, EventArgs e)
        {

            bunifuCustomDataGrid1.DataSource = prod.get_all_categories();
            bunifuCustomDataGrid2.DataSource = prod.get_products(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());

            bunifuCustomDataGrid2.Columns[0].Width = 220;
            bunifuCustomDataGrid2.Columns[1].Width = 50;

            txt_order_id.Text = order.get_last_order_id().Rows[0][0].ToString();
            txt_order_date.Text = DateTime.Now.ToString();
            txt_salesman.Text = form_main.user_name;

        
        }


        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = prod.get_products(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            bunifuCustomDataGrid2.Columns[0].Width = 220;
            bunifuCustomDataGrid2.Columns[1].Width = 50;

        }
        
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(txt_customer_phone.Text != "" && txt_customer_name.Text != "" && txt_customer_address.Text != "")
            {
                cust.add_customer(txt_customer_name.Text, txt_customer_phone.Text, txt_customer_address.Text);
                bunifuFlatButton2.Visible = false;
            }
            else
            {
                MessageBox.Show("ادخل بيانات العميل كامله وبصوره صحيحه");
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txt_customer_phone.Text != "")
            {
                DataTable dt = cust.customers_search(txt_customer_phone.Text);
                if (dt.Rows.Count > 0 )
                {
                    txt_customer_name.Text = dt.Rows[0][1].ToString();
                    txt_customer_phone.Text = dt.Rows[0][2].ToString();
                    txt_customer_address.Text = dt.Rows[0][3].ToString();

                    bunifuFlatButton1.Visible = false;
                    bunifuFlatButton6.Visible = true;
                    txt_customer_name.ReadOnly = true;
                    txt_customer_address.ReadOnly = true;
                }
            }
            else
            {
                bunifuFlatButton2.Visible = false;
                MessageBox.Show("ادخل رقم تيليفون العميل");
            }
        }

        private void txt_customer_phone_TextChanged(object sender, EventArgs e)
        {
            if (cust.customers_search(txt_customer_phone.Text).Rows.Count <= 0)
            {
                bunifuFlatButton2.Visible = true;
                bunifuFlatButton1.Visible = false;
                bunifuFlatButton6.Visible = false;
                txt_customer_name.ReadOnly = false;
                txt_customer_address.ReadOnly = false;
            }
            else
            {
                bunifuFlatButton1.Visible = true;
                bunifuFlatButton2.Visible = false;
                txt_customer_name.ReadOnly = true;
                txt_customer_address.ReadOnly = true;
            }
        }

        private void bunifuCustomDataGrid2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            double res = 0.0;
            foreach (DataGridViewRow row in bunifuCustomDataGrid3.Rows)
            {
                if(bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString() == row.Cells[0].Value.ToString())
                {
                    row.Cells[2].Value = Int32.Parse(row.Cells[2].Value.ToString()) +1 ;
                    row.Cells[4].Value = double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[1].Value.ToString());

                    foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                    {
                        if(x.Cells[4].Value != string.Empty)
                        {
                            res += double.Parse(x.Cells[4].Value.ToString());
                        }
                    }
                    
                    textBox1.Text = res.ToString();
                    return;
                }
            }

            DataRow r = dt.NewRow();
            r[0] = bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString();
            r[1] = bunifuCustomDataGrid2.CurrentRow.Cells[1].Value;
            r[2] = 1;
            r[3] = 0;
            r[4] = double.Parse(r[1].ToString()) * double.Parse(r[2].ToString());
            dt.Rows.Add(r);
            bunifuCustomDataGrid3.DataSource = dt;
            foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
            {
                if (x.Cells[4].Value != string.Empty)
                {
                    res += double.Parse(x.Cells[4].Value.ToString());
                }
            }
            bunifuCustomDataGrid3.Columns[0].Width = 350;
            textBox1.Text = res.ToString();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 ))
            {
                e.Handled = true;
                return;
            }

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if(bunifuCustomDataGrid3.Rows.Count > 0)
            {
                double res = 0.0;
                bunifuCustomDataGrid3.Rows.RemoveAt(bunifuCustomDataGrid3.CurrentRow.Index);
                foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                {
                    if (x.Cells[4].Value != string.Empty)
                    {
                        res += double.Parse(x.Cells[4].Value.ToString());
                    }
                }
                textBox1.Text = res.ToString();
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            double res = 0.0;
            if(textBox2.Text == "")
            {
                return;
            }
            bunifuCustomDataGrid3.CurrentRow.Cells[2].Value = textBox2.Text;
            bunifuCustomDataGrid3.CurrentRow.Cells[4].Value = double.Parse(bunifuCustomDataGrid3.CurrentRow.Cells[2].Value.ToString()) 
                * double.Parse(bunifuCustomDataGrid3.CurrentRow.Cells[1].Value.ToString());
            foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
            {
                if (x.Cells[4].Value != string.Empty)
                {
                    res += double.Parse(x.Cells[4].Value.ToString());
                }
            }
            textBox1.Text = res.ToString();
            textBox2.Text = "";
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            if (order_type == "d")
            {
            }
            else
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم العميل");
                    return;
                }
                else
                {

                }
            }
                int id = Int32.Parse(order.get_last_order_id().Rows[0][0].ToString());
            if (bunifuCustomDataGrid3.Rows.Count>0)
            {
                if (order_type == "d" && txt_customer_phone.Text != "")
                {
                    DataTable dt = cust.get_customer_id(txt_customer_phone.Text);
                    if (dt.Rows.Count > 0)
                    {
                        int x = Int32.Parse(dt.Rows[0][0].ToString());
                        DateTime t = DateTime.Now;
                        t.ToString("u");
                        order.add_order(id, t, x, txt_salesman.Text);
                    }
                    else
                    {
                        MessageBox.Show("الرجاء حفظ بيانات العميل مسبقا");
                        return;
                    }
                }
                else if(txt_customer_phone.Text == "" && order_type == "d")
                {
                    MessageBox.Show("الرجاء ادخال و حفظ بيانات العميل مسبقا");
                    return;
                }
                else
                {
                    DateTime t = DateTime.Now;
                    t.ToString("u");
                    order.add_order(id, t,2, txt_salesman.Text);
                }

                for(int i =0 ;i < bunifuCustomDataGrid3.Rows.Count;i++)
                {
                    order.add_order_details(
                            id,
                            bunifuCustomDataGrid3.Rows[i].Cells[0].Value.ToString(),
                            Int32.Parse(bunifuCustomDataGrid3.Rows[i].Cells[2].Value.ToString()),
                            float.Parse(bunifuCustomDataGrid3.Rows[i].Cells[1].Value.ToString()),
                            float.Parse(bunifuCustomDataGrid3.Rows[i].Cells[3].Value.ToString()),
                            float.Parse(bunifuCustomDataGrid3.Rows[i].Cells[4].Value.ToString())
                        );
                }


                // ....................................................... print bill
                if (order_type == "d")
                {
                    int r = Int32.Parse(order.get_last_order_id().Rows[0][0].ToString())-1;
                    DataTable dt = order.get_order_details(r);
                    rpt_print.print_delevry(dt);
                }
                else
                {
                    if(textBox3.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل اسم العميل");
                        return;
                    }
                    else
                    {
                        int r = Int32.Parse(order.get_last_order_id().Rows[0][0].ToString()) - 1;
                        DataTable dt = order.get_order_details(r);
                        rpt_print.print_safry(dt,textBox3.Text);

                    }
                    
                }

                clear_uc();

                
            }
            else
            {
                MessageBox.Show("ادخل منجات للبيع مسبقا");
            }

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            bunifuFlatButton7.Visible = true;
            bunifuFlatButton8.Visible = true;

            txt_customer_name.ReadOnly = false;
            txt_customer_address.ReadOnly = false;
            txt_customer_phone.ReadOnly = true;
            bunifuFlatButton6.Visible = false;

        }

        private void txt_customer_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txt_customer_phone_KeyUp(object sender, KeyEventArgs e)
        {
            if((e.KeyCode != Keys.OemPeriod) && (e.KeyCode != Keys.Decimal))
            {
                e.Handled = true;
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            DataTable dt = cust.customers_search(txt_customer_phone.Text);
            if (dt.Rows.Count > 0)
            {
                txt_customer_name.Text = dt.Rows[0][1].ToString();
                txt_customer_phone.Text = dt.Rows[0][2].ToString();
                txt_customer_address.Text = dt.Rows[0][3].ToString();

                bunifuFlatButton1.Visible = false;
                bunifuFlatButton6.Visible = true;
                txt_customer_name.ReadOnly = true;
                txt_customer_address.ReadOnly = true;
                txt_customer_phone.ReadOnly = false;
                bunifuFlatButton7.Visible = false;
                bunifuFlatButton8.Visible = false;

            }
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            cust.update_customer(txt_customer_name.Text,txt_customer_phone.Text,txt_customer_address.Text);

            bunifuFlatButton1.Visible = false;
            bunifuFlatButton6.Visible = true;
            txt_customer_name.ReadOnly = true;
            txt_customer_address.ReadOnly = true;
            txt_customer_phone.ReadOnly = false;
            bunifuFlatButton7.Visible = false;
            bunifuFlatButton8.Visible = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            if (order_type == "d")
            {
                int r = Int32.Parse(order.get_last_order_id().Rows[0][0].ToString()) - 1;
                DataTable dt = order.get_order_details(r);
                rpt_print.print_delevry(dt);
            }
            else
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم العميل");
                    return;
                }
                else
                {
                    int r = Int32.Parse(order.get_last_order_id().Rows[0][0].ToString()) - 1;
                    DataTable dt = order.get_order_details(r);
                    rpt_print.print_safry(dt, textBox3.Text);
                }

            }
        }
        private void clear_uc()
        {
            dt.Rows.Clear();
            bunifuCustomDataGrid3.DataSource = dt;
            textBox1.Text = "";
            textBox3.Text = "";
            panel4.Visible = false;
            label8.Visible = true;
            textBox3.Visible = true;
            order_type = "s";

            txt_order_id.Text = order.get_last_order_id().Rows[0][0].ToString();
            txt_order_date.Text = DateTime.Now.ToString();
            txt_salesman.Text = form_main.user_name;
        }
    }
    class stat
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
