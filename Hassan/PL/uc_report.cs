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
    public partial class uc_report : UserControl
    {
        public uc_report()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel3.Controls)
            {
                if (vb is uc_report_product)
                {
                    vb.BringToFront();
                    return;
                }
            }
            uc_report_product uc = new uc_report_product();
            uc.Dock = DockStyle.Fill;

            panel3.Controls.Add(uc);
            uc.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel3.Controls)
            {
                if (vb is uc_report_users)
                {
                    vb.BringToFront();
                    return;
                }
            }
            uc_report_users uc = new uc_report_users();
            uc.Dock = DockStyle.Fill;

            panel3.Controls.Add(uc);
            uc.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel3.Controls)
            {
                if (vb is uc_report_customer)
                {
                    vb.BringToFront();
                    return;
                }
            }
            uc_report_customer uc = new uc_report_customer();
            uc.Dock = DockStyle.Fill;

            panel3.Controls.Add(uc);
            uc.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel3.Controls)
            {
                if (vb is uc_report_bills)
                {
                    vb.BringToFront();
                    return;
                }
            }
            uc_report_bills uc = new uc_report_bills();
            uc.Dock = DockStyle.Fill;
            
            panel3.Controls.Add(uc);
            uc.BringToFront();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel3.Controls)
            {
                if (vb is uc_purchases)
                {
                    vb.BringToFront();
                    return;
                }
            }
            uc_purchases uc = new uc_purchases();
            uc.Dock = DockStyle.Fill;

            panel3.Controls.Add(uc);
            uc.BringToFront();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            FormCollection forms;

            forms = Application.OpenForms;

            foreach (Form form in forms)
            {

                if (form is select_printers)
                {
                    form.ShowDialog();
                    return;
                }
            }
            select_printers f = new select_printers();
            f.ShowDialog();
        }
    }
}
