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
    public partial class uc_report_customer : UserControl
    {
        BL.class_products prod = new BL.class_products();
        BL.class_report rep = new BL.class_report();
        BL.class_customers cust = new BL.class_customers();

        public uc_report_customer()
        {
            InitializeComponent();
        }

        private void uc_report_customer_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = cust.get_all_customers();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                double res = 0.0;
                bunifuCustomDataGrid3.DataSource = null;
                bunifuCustomDataGrid3.DataSource = rep.get_all_customer_report_n();
                foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                {
                    if (x.Cells[3].Value != string.Empty)
                    {
                        res += double.Parse(x.Cells[3].Value.ToString());
                    }
                }
                textBox2.Text = res.ToString();
            }
            else
            {
                DateTime a, b;
                if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                {
                    double res = 0.0;
                    bunifuCustomDataGrid3.DataSource = null;
                    bunifuCustomDataGrid3.DataSource = rep.get_all_customer_report_y(a, b);
                    foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                    {
                        if (x.Cells[3].Value != string.Empty)
                        {
                            res += double.Parse(x.Cells[3].Value.ToString());
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

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                double res = 0.0;
                int q = Int32.Parse(cust.get_customer_id(bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString()).Rows[0][0].ToString());
                bunifuCustomDataGrid3.DataSource = null;
                bunifuCustomDataGrid3.DataSource = rep.get_details_report_of_customer_n(q);
                foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                {
                    if (x.Cells[5].Value != string.Empty)
                    {
                        res += double.Parse(x.Cells[5].Value.ToString());
                    }
                }
                textBox2.Text = res.ToString();
                bunifuCustomDataGrid3.Columns[1].Width = 260;
            }
            else
            {
                DateTime a, b;
                if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                {
                    double res = 0.0;
                    int q = Int32.Parse(cust.get_customer_id(bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString()).Rows[0][0].ToString());
                    bunifuCustomDataGrid3.DataSource = null;
                    bunifuCustomDataGrid3.DataSource = rep.get_details_report_of_customer_y(q,a,b);
                    foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                    {
                        if (x.Cells[5].Value != string.Empty)
                        {
                            res += double.Parse(x.Cells[5].Value.ToString());
                        }
                    }
                    textBox2.Text = res.ToString();
                    bunifuCustomDataGrid3.Columns[1].Width = 260;
                }
                else
                {
                    MessageBox.Show("ادخل التاريخ بصوره صحيحه");
                }
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid3.DataSource = null;
            textBox2.Text = "";
        }
    }
}
