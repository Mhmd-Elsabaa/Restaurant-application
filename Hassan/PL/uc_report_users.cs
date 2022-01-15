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
    public partial class uc_report_users : UserControl
    {
        BL.class_products prod = new BL.class_products();
        BL.class_report rep = new BL.class_report();
        BL.class_customers user = new BL.class_customers();
        
        public uc_report_users()
        {
            InitializeComponent();
        }

        private void uc_report_users_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource =  user.get_all_user();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid3.DataSource = null;
            textBox2.Text = "";
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                double res = 0.0;
                bunifuCustomDataGrid3.DataSource = rep.get_details_report_of_user_n(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                {
                    if (x.Cells[4].Value != string.Empty)
                    {
                        res += double.Parse(x.Cells[4].Value.ToString());
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
                    bunifuCustomDataGrid3.DataSource = rep.get_details_report_of_user(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString(),a,b);
                    foreach (DataGridViewRow x in bunifuCustomDataGrid3.Rows)
                    {
                        if (x.Cells[4].Value != string.Empty)
                        {
                            res += double.Parse(x.Cells[4].Value.ToString());
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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                double res = 0.0;
                bunifuCustomDataGrid3.DataSource = rep.get_all_user_report_n();
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
                    double res = 0.0;
                    bunifuCustomDataGrid3.DataSource = rep.get_all_user_report_y(a, b);
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
    }
}
