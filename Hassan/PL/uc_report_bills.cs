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
    public partial class uc_report_bills : UserControl
    {
        BL.class_report rep = new BL.class_report();
        public uc_report_bills()
        {
            InitializeComponent();
        }

        private void uc_report_bills_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = rep.get_all_bills_n();
            textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
            bunifuCustomDataGrid1.Columns[0].Width = 50;
            
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid3.DataSource = null;
            textBox2.Text = "";
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد من حذف المنتج المحدد", "عمليه الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int x = Int32.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                rep.delete_bill(x);
                if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
                {
                    bunifuCustomDataGrid1.DataSource = rep.get_all_bills_n();
                    textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                    bunifuCustomDataGrid1.Columns[0].Width = 50;
                }
                else
                {
                    DateTime a, b;
                    if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                    {
                        bunifuCustomDataGrid1.DataSource = rep.get_all_bills_y(a, b);
                        textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                        bunifuCustomDataGrid1.Columns[0].Width = 50;
                    }
                    
                }
            }
            
        }
        

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                bunifuCustomDataGrid1.DataSource = rep.get_all_bills_n();
                textBox1.Text = "";
                textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                bunifuCustomDataGrid1.Columns[0].Width = 50;
            }
            else
            {
                DateTime a, b;
                if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                {
                    bunifuCustomDataGrid1.DataSource = rep.get_all_bills_y(a,b);
                    textBox1.Text = "";
                    textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                    bunifuCustomDataGrid1.Columns[0].Width = 50;
                }
                else
                {
                    MessageBox.Show("ادخل التاريخ بصوره صحيحه");
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" || textBox1.Text != string.Empty)
            {
                bunifuCustomDataGrid1.DataSource = rep.get_bill(int.Parse(textBox1.Text));
                textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                bunifuCustomDataGrid1.Columns[0].Width = 50;
            }
            else
            {
                bunifuCustomDataGrid1.DataSource = rep.get_all_bills_n();
                bunifuCustomDataGrid1.Columns[0].Width = 50;
            }
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            double res = 0.0;
            int x = Int32.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            bunifuCustomDataGrid3.DataSource = rep.show_bill(x);
            foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
            {
                if (w.Cells[4].Value != string.Empty)
                {
                    res += double.Parse(w.Cells[4].Value.ToString());
                }
            }
            textBox2.Text = res.ToString();
            bunifuCustomDataGrid3.Columns[0].Width = 250;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            double res = 0.0;
            DateTime a, b;

            if(DateTime.TryParse(txt_from.Text, out a))
            {
                b = a.AddDays(1);

                DateTime.TryParse((a.ToString("dd/MM/yyyy") + " 8:0:0"), out a);
                DateTime.TryParse((b.ToString("dd/MM/yyyy") + " 5:0:0"), out b);

                bunifuCustomDataGrid1.DataSource = rep.get_all_bills_y(a, b);
                bunifuCustomDataGrid3.DataSource = rep.get_last_day_bills(a, b);
                textBox1.Text = "";
                textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
                {
                    if (w.Cells[4].Value != string.Empty)
                    {
                        res += double.Parse(w.Cells[5].Value.ToString());
                    }
                }
                textBox2.Text = res.ToString();
                bunifuCustomDataGrid3.Columns[2].Width = 230;
                bunifuCustomDataGrid3.Columns[0].Width = 80;
                bunifuCustomDataGrid1.Columns[0].Width = 50;
            }
            

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            double res = 0.0;
            DateTime a, b;

            if (DateTime.TryParse(txt_from.Text, out a))
            {
                b = a.AddDays(1);

                DateTime.TryParse((a.ToString("dd/MM/yyyy") + " 8:0:0"), out a);
                DateTime.TryParse((b.ToString("dd/MM/yyyy") + " 5:0:0"), out b);

                bunifuCustomDataGrid1.DataSource = rep.get_delevry_bills_n(a, b);
                bunifuCustomDataGrid3.DataSource = rep.get_delevry_bills(a, b);
                textBox1.Text = "";
                textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
                {
                    if (w.Cells[4].Value != string.Empty)
                    {
                        res += double.Parse(w.Cells[5].Value.ToString());
                    }
                }
                textBox2.Text = res.ToString();
                bunifuCustomDataGrid3.Columns[2].Width = 230;
                bunifuCustomDataGrid3.Columns[0].Width = 80;
                bunifuCustomDataGrid1.Columns[0].Width = 50;
            }
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            double res = 0.0;
            DateTime a, b;

            if (DateTime.TryParse(txt_from.Text, out a))
            {
                b = a.AddDays(1);

                DateTime.TryParse((a.ToString("dd/MM/yyyy") + " 8:0:0"), out a);
                DateTime.TryParse((b.ToString("dd/MM/yyyy") + " 5:0:0"), out b);

                bunifuCustomDataGrid1.DataSource = rep.get_rest_bills_n(a, b);
                bunifuCustomDataGrid3.DataSource = rep.get_rest_bills(a, b);
                textBox1.Text = "";
                textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
                {
                    if (w.Cells[4].Value != string.Empty)
                    {
                        res += double.Parse(w.Cells[5].Value.ToString());
                    }
                }
                textBox2.Text = res.ToString();
                bunifuCustomDataGrid3.Columns[2].Width = 230;
                bunifuCustomDataGrid3.Columns[0].Width = 80;
                bunifuCustomDataGrid1.Columns[0].Width = 50;
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
