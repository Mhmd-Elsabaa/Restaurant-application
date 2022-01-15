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
    public partial class uc_table : UserControl
    {
        BL.class_products prod = new BL.class_products();
        BL.class_orders order = new BL.class_orders();
        BL.class_customers cust = new BL.class_customers();

        DataTable dt = new DataTable();
        DataTable dt_f = new DataTable();
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

            bunifuCustomDataGrid3.DataSource = dt;
            bunifuCustomDataGrid4.DataSource = dt_f;

        }
        public uc_table()
        {
            InitializeComponent();
            create_data_table();
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = prod.get_products(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
        }

        private void uc_table_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = prod.get_all_categories();
            bunifuCustomDataGrid2.DataSource = prod.get_products("مشويات");

            txt_order_id.Text = order.get_last_order_id().Rows[0][0].ToString();
            txt_order_date.Text = DateTime.Now.ToString();
            txt_salesman.Text = form_main.user_name;
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
            double res = 0.0;
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
                if(f)
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

            /////////////////////                    ..............................      print bill in ketchen


            dt.Clear();
            bunifuCustomDataGrid3.DataSource = dt;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (bunifuCustomDataGrid4.Rows.Count > 0)
            {
                
                int id = Int32.Parse(order.get_last_order_id().Rows[0][0].ToString());
                DateTime t = DateTime.Now;
                t.ToString("u");
                order.add_order_f(id, t, txt_salesman.Text);
                

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


                // .......................................................................... brint bill

                // .......................................................................... close table

                this.Hide();

            }
            else
            {
                MessageBox.Show("ادخل منجات للبيع مسبقا");
            }


        }
    
    }
}
