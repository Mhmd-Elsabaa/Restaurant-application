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
    public partial class uc_purchases : UserControl
    {
        BL.class_report rep = new BL.class_report();
        public uc_purchases()
        {
            InitializeComponent();
        }

        private void uc_purchases_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid3.DataSource = rep.all_purchases_top();
            double res = 0;
            foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
            {
                if (w.Cells[3].Value != string.Empty)
                {
                    res += double.Parse(w.Cells[3].Value.ToString());
                }
            }
            textBox11.Text = res.ToString();
            bunifuCustomDataGrid3.Columns[0].Width = 330;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if(textBox5.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("ادخل الوصف والمبلغ بصورة صحيحة");
                return;
            }
            string d = textBox5.Text;
            float price = float.Parse(textBox8.Text);

            float c = textBox6.Text == "" ? 0 : float.Parse(textBox6.Text);

            float weight = textBox7.Text == "" ? 0 : float.Parse(textBox7.Text);
            DateTime date = DateTime.Now;
            rep.add_purchases(d,c,weight,price,date);

            bunifuCustomDataGrid3.DataSource = rep.all_purchases_top();
            double res = 0;
            foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
            {
                if (w.Cells[3].Value != string.Empty)
                {
                    res += double.Parse(w.Cells[3].Value.ToString());
                }
            }
            textBox11.Text = res.ToString();
            bunifuCustomDataGrid3.Columns[0].Width = 330;
            textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";


        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DateTime a, b;

            if (DateTime.TryParse(textBox9.Text, out a))
            {
                b = a.AddDays(1);

                DateTime.TryParse((a.ToString("dd/MM/yyyy") + " 8:0:0"), out a);
                DateTime.TryParse((b.ToString("dd/MM/yyyy") + " 8:0:0"), out b);

                bunifuCustomDataGrid3.DataSource = rep.all_purchases_d(a, b);

                double res = 0;
                foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
                {
                    if (w.Cells[3].Value != string.Empty)
                    {
                        res += double.Parse(w.Cells[3].Value.ToString());
                    }
                }
                textBox11.Text = res.ToString();
                bunifuCustomDataGrid3.Columns[0].Width = 330;
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == string.Empty && textBox10.Text == string.Empty)
            {
                bunifuCustomDataGrid3.DataSource = rep.all_purchases();
                double res = 0;
                foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
                {
                    if (w.Cells[3].Value != string.Empty)
                    {
                        res += double.Parse(w.Cells[3].Value.ToString());
                    }
                }
                textBox11.Text = res.ToString();
                bunifuCustomDataGrid3.Columns[0].Width = 330;
            }
            else
            {
                DateTime a, b;
                if (DateTime.TryParse(textBox9.Text, out a) && DateTime.TryParse(textBox10.Text, out b))
                {
                    bunifuCustomDataGrid3.DataSource = rep.all_purchases_d(a, b);
                    double res = 0;
                    foreach (DataGridViewRow w in bunifuCustomDataGrid3.Rows)
                    {
                        if (w.Cells[3].Value != string.Empty)
                        {
                            res += double.Parse(w.Cells[3].Value.ToString());
                        }
                    }
                    textBox11.Text = res.ToString();
                    bunifuCustomDataGrid3.Columns[0].Width = 330;
                }
                else
                {
                    MessageBox.Show("ادخل التاريخ بصوره صحيحه او عدم ادخال التاريخ يظهر كل المشتريات اللتي تم تخزينها");
                }
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid3.DataSource = null;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
