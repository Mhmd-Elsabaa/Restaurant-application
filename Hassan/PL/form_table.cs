using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp.PL
{
    public partial class form_table : Form
    {
        BL.class_products prod = new BL.class_products();
        BL.class_orders order = new BL.class_orders();
        BL.class_customers cust = new BL.class_customers();
        BL.Class_printer rpt_print = new BL.Class_printer();

        DataTable dt = new DataTable();
        DataTable dt_f = new DataTable();
        DataTable dt_printer = new DataTable();
        public void create_data_table()
        {
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("سعر المنتج");
            dt.Columns.Add("الكميه");
            dt.Columns.Add("% نسبه الخصم");
            dt.Columns.Add("المبلغ");

            dt_f.Columns.Add("اسم المنتج");
            dt_f.Columns.Add("سعر المنتج");
            dt_f.Columns.Add("الكميه");
            dt_f.Columns.Add("% نسبه الخصم");
            dt_f.Columns.Add("المبلغ");

            dt_printer.Columns.Add("المنتج");
            dt_printer.Columns.Add("السعر");
            dt_printer.Columns.Add("الكميه");
            dt_printer.Columns.Add("المبلغ");

            bunifuCustomDataGrid3.DataSource = dt;
            bunifuCustomDataGrid4.DataSource = dt_f;

        }
        public form_table()
        {
            InitializeComponent();

            create_data_table();
        }
        private void reset_uc()
        {
            bunifuCustomDataGrid1.DataSource = prod.get_all_categories();
            bunifuCustomDataGrid2.DataSource = prod.get_products(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());

            bunifuCustomDataGrid2.Columns[0].Width = 220;
            bunifuCustomDataGrid2.Columns[1].Width = 50;

            txt_order_id.Text = order.get_last_order_id().Rows[0][0].ToString();
            txt_order_date.Text = DateTime.Now.ToString();
            txt_salesman.Text = form_main.user_name;
            textBox3.Text = "_" + this.Text;

            dt.Rows.Clear();
            dt_f.Rows.Clear();
            bunifuCustomDataGrid3.DataSource = dt;
            bunifuCustomDataGrid4.DataSource = dt_f;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            int o = int.Parse(this.Text);
            form_main.order_num[o - 1] = 1;


        }
        private void form_table_Load(object sender, EventArgs e)
        {

            reset_uc();

        }
        

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = prod.get_products(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            bunifuCustomDataGrid2.Columns[0].Width = 220;
            bunifuCustomDataGrid2.Columns[1].Width = 50;

        }
        

        private void bunifuCustomDataGrid2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            double res = 0.0;
            foreach (DataGridViewRow row in bunifuCustomDataGrid3.Rows)
            {
                if (bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString() == row.Cells[0].Value.ToString())
                {
                    row.Cells[2].Value = Int32.Parse(row.Cells[2].Value.ToString()) + 1;
                    row.Cells[4].Value = double.Parse(row.Cells[2].Value.ToString()) * double.Parse(row.Cells[1].Value.ToString());

                    foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                    {
                        if (x.Cells[4].Value != string.Empty)
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

            textBox1.Text = res.ToString();
            bunifuCustomDataGrid3.Columns[0].Width = 300;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid3.Rows.Count > 0)
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
            if (textBox2.Text == "")
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
            if (!(bunifuCustomDataGrid3.Rows.Count > 0))
            {
                MessageBox.Show("ادخل منجات للبيع مسبقا");
                return;
            }

            double res = 0.0;
            string txt = this.Text;
            int index = int.Parse(txt);

            

            /////////////////////                    ..............................      print bill in ketchen
            DataTable dt_arg = dt_printer;
            for (int k = 0; k < bunifuCustomDataGrid3.Rows.Count; k++)
            {
                DataRow ro = dt_printer.NewRow();
                ro[0] = bunifuCustomDataGrid3.Rows[k].Cells[0].Value.ToString();
                ro[1] = bunifuCustomDataGrid3.Rows[k].Cells[1].Value.ToString();
                ro[2] = bunifuCustomDataGrid3.Rows[k].Cells[2].Value.ToString();
                ro[3] = bunifuCustomDataGrid3.Rows[k].Cells[4].Value.ToString();

                dt_arg.Rows.Add(ro);
            }
            DateTime ti= DateTime.Now;
            string who = textBox5.Text == "" ? " . " : textBox5.Text;
            bool che = rpt_print.ptint_kitchen(dt_arg, txt,(form_main.order_num[index-1]).ToString(),ti,who);
            if(!che)
            {
                MessageBox.Show("لم يتم طباعه الفاتوره");
                return;
            }

            foreach (DataGridViewRow row in bunifuCustomDataGrid3.Rows)
            {
                bool f = true;
                foreach (DataGridViewRow row_f in bunifuCustomDataGrid4.Rows)
                {
                    if (row_f.Cells[0].Value.ToString() == row.Cells[0].Value.ToString())
                    {
                        row_f.Cells[2].Value = Int32.Parse(row_f.Cells[2].Value.ToString()) + Int32.Parse(row.Cells[2].Value.ToString());
                        row_f.Cells[4].Value = double.Parse(row_f.Cells[2].Value.ToString()) * double.Parse(row_f.Cells[1].Value.ToString());
                        f = false;
                        break;
                    }
                }
                if (f)
                {
                    DataRow r = dt_f.NewRow();
                    r[0] = row.Cells[0].Value.ToString();
                    r[1] = row.Cells[1].Value.ToString();
                    r[2] = row.Cells[2].Value.ToString();
                    r[3] = row.Cells[3].Value.ToString();
                    r[4] = row.Cells[4].Value.ToString();
                    dt_f.Rows.Add(r);
                    bunifuCustomDataGrid4.DataSource = dt_f;
                }


            }
            foreach (DataGridViewRow x in bunifuCustomDataGrid4.Rows)
            {
                if (x.Cells[4].Value != string.Empty)
                {
                    res += double.Parse(x.Cells[4].Value.ToString());
                }
            }

            textBox4.Text = res.ToString();
            bunifuCustomDataGrid4.Columns[0].Width = 300;



            form_main.order_num[index-1]=form_main.order_num[index-1]+1;
            dt.Clear();
            dt_printer.Clear();
            bunifuCustomDataGrid3.DataSource = dt;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (!( bunifuCustomDataGrid4.Rows.Count > 0))
            {
                MessageBox.Show("ادخل منجات للبيع مسبقا");
                return;
            }
            
            int id = Int32.Parse(order.get_last_order_id().Rows[0][0].ToString());
            DateTime t = DateTime.Now;
            t.ToString("u");
            order.add_order(id, t,1, txt_salesman.Text);


            for (int i = 0; i < bunifuCustomDataGrid4.Rows.Count; i++)
            {
                order.add_order_details(
                        id,
                        bunifuCustomDataGrid4.Rows[i].Cells[0].Value.ToString(),
                        Int32.Parse(bunifuCustomDataGrid4.Rows[i].Cells[2].Value.ToString()),
                        float.Parse(bunifuCustomDataGrid4.Rows[i].Cells[1].Value.ToString()),
                        float.Parse(bunifuCustomDataGrid4.Rows[i].Cells[3].Value.ToString()),
                        float.Parse(bunifuCustomDataGrid4.Rows[i].Cells[4].Value.ToString())
                    );
            }
            // enable table button again
            foreach (Control zx in form_main.get_main_form.uc_main_table1.Controls)
            {
                if (this.Text == zx.Text)
                {
                    zx.Visible = true;
                    break;
                }
            }


            int r = Int32.Parse(order.get_last_order_id().Rows[0][0].ToString()) - 1;
            DataTable dt_a = order.get_order_details(r);
            string txt = this.Text;
            rpt_print.ptint_table(dt_a, txt);

            reset_uc();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (!(bunifuCustomDataGrid4.Rows.Count > 0))
            {
                // enable table button again
                foreach (Control zx in form_main.get_main_form.uc_main_table1.Controls)
                {
                    if (this.Text == zx.Text)
                    {
                        zx.Visible = true;
                        break;
                    }
                }
                reset_uc();
                this.Hide();
                return;
            }
            
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {

            if(form_main.user_type == "admin")
            {
                if (bunifuCustomDataGrid4.Rows.Count > 0)
                {
                    double res = 0.0;
                    bunifuCustomDataGrid4.Rows.RemoveAt(bunifuCustomDataGrid4.CurrentRow.Index);
                    foreach (DataGridViewRow x in bunifuCustomDataGrid4.Rows)
                    {
                        if (x.Cells[4].Value != string.Empty)
                        {
                            res += double.Parse(x.Cells[4].Value.ToString());
                        }
                    }
                    textBox4.Text = res.ToString();
                }
            }
            else
            {
                MessageBox.Show("قم بادخال بيانات المسئول");
                panel4.Visible = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL.class_users_login log = new BL.class_users_login();
            DataTable dt = log.login(bunifuMetroTextbox2.Text, bunifuMetroTextbox1.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][2].ToString() == "admin")
                {

                    bunifuMetroTextbox1.Text = "";
                    bunifuMetroTextbox2.Text = "";
                    panel4.Visible = false;

                    if (bunifuCustomDataGrid4.Rows.Count > 0)
                    {
                        double res = 0.0;
                        bunifuCustomDataGrid4.Rows.RemoveAt(bunifuCustomDataGrid4.CurrentRow.Index);
                        foreach (DataGridViewRow x in bunifuCustomDataGrid4.Rows)
                        {
                            if (x.Cells[4].Value != string.Empty)
                            {
                                res += double.Parse(x.Cells[4].Value.ToString());
                            }
                        }
                        textBox1.Text = res.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("فشل الدخول");
                    bunifuMetroTextbox1.Text = "";
                    bunifuMetroTextbox2.Text = "";

                }
            }
            else
            {
                MessageBox.Show("فشل الدخول");
                bunifuMetroTextbox1.Text = "";
                bunifuMetroTextbox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox6.Text == "")
            {
                MessageBox.Show("ادخل رقم الطاوله من 1 الي 20 اولا");
                return;
            }
            int i = int.Parse(textBox6.Text);
            if (i > 0 && i < 21)
            {
                foreach (Control zx1 in form_main.get_main_form.uc_main_table1.Controls)
                {
                    if (textBox6.Text == zx1.Text)
                    {
                        if(zx1.Visible == true)
                        {
                            foreach (Control zx in form_main.get_main_form.uc_main_table1.Controls)
                            {
                                if (this.Text == zx.Text)
                                {
                                    zx.Visible = true;
                                    break;
                                }
                            }
                            int o = int.Parse(this.Text);
                            form_main.order_num[i - 1] = form_main.order_num[o - 1];
                            form_main.order_num[o - 1] = 1;

                            textBox3.Text = textBox6.Text;
                            this.Text = textBox6.Text;
                            foreach (Control zx in form_main.get_main_form.uc_main_table1.Controls)
                            {
                                if (this.Text == zx.Text)
                                {
                                    zx.Visible = false;
                                    break;
                                }
                            }
                            return;
                        }
                        else
                        {
                            MessageBox.Show("هذه الطاوله مشغوله الان");
                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("ادخل رقم الطاوله من 1 الي 20 اولا");
                return;
            }
            

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
