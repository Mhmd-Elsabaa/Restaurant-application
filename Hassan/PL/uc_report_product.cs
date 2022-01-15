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
    public partial class uc_report_product : UserControl
    {
        BL.class_products prod = new BL.class_products();
        BL.class_report rep = new BL.class_report();
        BL.class_customers cust = new BL.class_customers();


        DataTable dt = new DataTable();
        public void create_data_table()
        {
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("العدد الكلي");
            dt.Columns.Add("المبلغ الاجمالي الكلي");

            bunifuCustomDataGrid3.DataSource = dt;
        }
        //sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        public uc_report_product()
        {
            InitializeComponent();
            create_data_table();
        }

        private void uc_report_product_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = prod.get_all_categories();
            bunifuCustomDataGrid2.DataSource = prod.get_products("مشويات");////////////////////////////////
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = prod.get_products(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());

            bunifuCustomDataGrid2.Columns[0].Width = 260;

        }

        //sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        private void bunifuCustomDataGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            double res = 0.0;
            foreach (DataGridViewRow row in bunifuCustomDataGrid3.Rows)
            {
                if (bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString() == row.Cells[0].Value.ToString())
                {
                    return;
                }
            }

            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                DataRow r = dt.NewRow();

                DataTable d = rep.get_product_details_n(bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString());

                if (d.Rows.Count > 0)
                {
                    r[0] = d.Rows[0][0];
                    r[1] = d.Rows[0][1];
                    r[2] = d.Rows[0][2];
                }
                else
                {
                    r[0] = bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString();
                    r[1] = 0;
                    r[2] = 0;
                }


                dt.Rows.Add(r);
                bunifuCustomDataGrid3.DataSource = dt;

                foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                {
                    if (x.Cells[2].Value != string.Empty)
                    {
                        res += double.Parse(x.Cells[2].Value.ToString());
                    }
                }
                textBox2.Text = res.ToString();
            }
            else
            {
                DateTime a, b;
                if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                {
                    DataRow r = dt.NewRow();

                    DataTable d = rep.get_product_details_y(bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString(), a,b);

                    if (d.Rows.Count > 0)
                    {
                        r[0] = d.Rows[0][0];
                        r[1] = d.Rows[0][1];
                        r[2] = d.Rows[0][2];
                    }
                    else
                    {
                        r[0] = bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString();
                        r[1] = 0;
                        r[2] = 0;
                    }


                    dt.Rows.Add(r);
                    bunifuCustomDataGrid3.DataSource = dt;

                    foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                    {
                        if (x.Cells[2].Value != string.Empty)
                        {
                            res += double.Parse(x.Cells[2].Value.ToString());
                        }
                    }
                    textBox2.Text = res.ToString();
                }
                else
                {
                    MessageBox.Show("ادخل التاريخ بصوره صحيحه");
                }


            }
            
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            bunifuCustomDataGrid3.DataSource = dt;
            textBox2.Text = "";
        }
        //sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                double res = 0.0;
                dt.Rows.Clear();
                dt = rep.get_all_products_details_n();
                bunifuCustomDataGrid3.DataSource = dt;
                foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                {
                    if (x.Cells[2].Value != string.Empty)
                    {
                        res += double.Parse(x.Cells[2].Value.ToString());
                    }
                }
                textBox2.Text = res.ToString();

                bunifuCustomDataGrid3.Columns[0].Width = 330;
            }
            else
            {
                DateTime a, b;
                if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                {
                    double res = 0.0;
                    dt.Rows.Clear();
                    dt = rep.get_all_products_details_y(a,b);
                    bunifuCustomDataGrid3.DataSource = dt;
                    foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                    {
                        if (x.Cells[2].Value != string.Empty)
                        {
                            res += double.Parse(x.Cells[2].Value.ToString());
                        }
                    }
                    textBox2.Text = res.ToString();
                    bunifuCustomDataGrid3.Columns[0].Width = 330;
                }
                else
                {
                    MessageBox.Show("ادخل التاريخ بصوره صحيحه");
                }
            }
               
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                double res = 0.0;
                dt.Rows.Clear();
                
                dt = rep.get_categories_details_n(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                bunifuCustomDataGrid3.DataSource = dt;
                foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                {
                    if (x.Cells[2].Value != string.Empty)
                    {
                        res += double.Parse(x.Cells[2].Value.ToString());
                    }
                }
                textBox2.Text = res.ToString();
            }
            else
            {
               DateTime a, b;
               if(DateTime.TryParse(txt_from.Text ,out a) && DateTime.TryParse(txt_to.Text , out b))
               {
                    double res = 0.0;
                    dt.Rows.Clear();
                    
                    dt = rep.get_categories_details_y(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString(), a,b);
                    bunifuCustomDataGrid3.DataSource = dt;
                    foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                    {
                        if (x.Cells[2].Value != string.Empty)
                        {
                            res += double.Parse(x.Cells[2].Value.ToString());
                        }
                    }
                    textBox2.Text = res.ToString();
                }
               else
               {
                    MessageBox.Show("ادخل التاريخ بصوره صحيحه");
               }
            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
