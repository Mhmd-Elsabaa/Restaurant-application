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
    public partial class bill_deleted_report : UserControl
    {
        BL.class_report rep = new BL.class_report();
        public bill_deleted_report()
        {
            InitializeComponent();
        }

        private void bill_deleted_report_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = rep.get_all_bills_deleted();
            textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                bunifuCustomDataGrid1.DataSource = rep.get_all_bills_deleted();
                textBox1.Text = "";
                textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
            }
            else
            {
                DateTime a, b;
                if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                {
                    bunifuCustomDataGrid1.DataSource = rep.get_all_bills_deleted_t(a, b);
                    textBox1.Text = "";
                    textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                }
                else
                {
                    MessageBox.Show("ادخل التاريخ بصوره صحيحه");
                }
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Int32.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                return;
            }
            if (MessageBox.Show("هل انت متأكد من حذف المنتج المحدد", "عمليه الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int x = Int32.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                rep.delete_bill_delete(x);
                if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
                {
                    bunifuCustomDataGrid1.DataSource = rep.get_all_bills_deleted();
                    textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                }
                else
                {
                    DateTime a, b;
                    if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                    {
                        bunifuCustomDataGrid1.DataSource = rep.get_all_bills_deleted_t(a, b);
                        textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
                    }

                }
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid3.DataSource = null;
            textBox2.Text = "";
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            double res = 0.0;
            int x = Int32.Parse(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
            DateTime d;
            DateTime.TryParse(bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString(),out d);
            bunifuCustomDataGrid3.DataSource = rep.show_bill_deleted(x, d);
            foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
            {
                if (w.Cells[4].Value != string.Empty)
                {
                    res += double.Parse(w.Cells[4].Value.ToString());
                }
            }
            textBox2.Text = res.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox1.Text != string.Empty)
            {
                bunifuCustomDataGrid1.DataSource = rep.get_bill_delete(int.Parse(textBox1.Text));
                textBox3.Text = bunifuCustomDataGrid1.RowCount.ToString();
            }
            else
            {
                bunifuCustomDataGrid1.DataSource = rep.get_all_bills_deleted();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            double res = 0.0;
            if (txt_from.Text == string.Empty && txt_to.Text == string.Empty)
            {
                bunifuCustomDataGrid1.DataSource = rep.get_all_bills_deleted();
                bunifuCustomDataGrid3.DataSource = rep.get_all_bills_deleted_d();
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
                bunifuCustomDataGrid3.Columns[2].Width = 270;
                bunifuCustomDataGrid3.Columns[0].Width = 100;
            }
            else
            {
                DateTime a, b;
                if (DateTime.TryParse(txt_from.Text, out a) && DateTime.TryParse(txt_to.Text, out b))
                {
                    bunifuCustomDataGrid1.DataSource = rep.get_all_bills_deleted_t(a, b);
                    bunifuCustomDataGrid3.DataSource = rep.get_all_bills_deleted_d_t(a,b);
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
                    bunifuCustomDataGrid3.Columns[2].Width = 270;
                    bunifuCustomDataGrid3.Columns[0].Width = 100;
                }
                else
                {
                    MessageBox.Show("ادخل التاريخ بصوره صحيحه");
                }
            }
        }
    }
}
