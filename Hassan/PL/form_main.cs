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
    public partial class form_main : Form
    {
        public static string user_name;
        public static string user_password;
        public static string user_type;

        public static string main_printer;
        public static string second_printer;
        public static int[] order_num=new int[20];


        private static form_main main_form;
        static void main_form_closed(object sender,FormClosedEventArgs e)
        {
            main_form = null;
        }
        public static form_main get_main_form
        {
            get
            {
                if(main_form == null)
                {
                    main_form = new form_main();
                    main_form.FormClosed += new FormClosedEventHandler(main_form_closed);

                }
                return main_form;
            }
        }
        
        public form_main()
        {
            InitializeComponent();

            if(main_form == null)
            {
                main_form = this;
            }
            this.btn_bill.Enabled = false;
            this.btn_categories.Enabled = false;
            this.btn_product.Enabled = false;
            this.btn_report.Enabled = false;
            this.btn_users.Enabled = false;
            this.btn_tables.Enabled = false;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size; ;
            this.MinimumSize = Screen.PrimaryScreen.WorkingArea.Size; ;
        }

        private void form_main_Load(object sender, EventArgs e)
        {
           
            uc_main_table1.Hide();

            uc_login uc = new uc_login();
            uc.Dock = DockStyle.Fill;
            panel2.Controls.Add(uc);
            uc.BringToFront();
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            if(user_name == null || user_name == "")
            {
                foreach (Control vb in panel2.Controls)
                {
                    if (vb is uc_login)
                    {
                        panel5.Visible = false;
                        vb.Show();
                        vb.BringToFront();
                        return;
                    }
                }
                uc_login uc = new uc_login();
                uc.Dock = DockStyle.Fill;

                panel2.Controls.Clear();
                panel5.Visible = false;

                panel2.Controls.Add(uc);
                uc.BringToFront();
            }
            else
            {
                foreach (Control vb in panel1.Controls)
                {
                    vb.Hide();
                }
                panel5.Visible = true;
                panel2.Controls.Clear();
                bunifuFlatButton2.Text = "  تسجيل الخروج من  " + user_name;
            }
        }

        private void btn_categories_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel1.Controls)
            {
                if (vb is uc_category_managment)
                {
                    panel2.Controls.Clear();
                    panel5.Visible = false;
                    vb.Show();
                    vb.BringToFront();
                    return;
                }
            }
            uc_category_managment uc = new uc_category_managment();
            uc.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel5.Visible = false;

            panel1.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btn_product_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel1.Controls)
            {
                if (vb is uc_products_managment)
                {
                    panel2.Controls.Clear();
                    panel5.Visible = false;
                    vb.Show();
                    vb.BringToFront();
                    return;
                }
            }
            uc_products_managment uc = new uc_products_managment();
            uc.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel5.Visible = false;
            panel1.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btn_bill_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel1.Controls)
            {
                if(vb is uc_bills)
                {
                    panel2.Controls.Clear();
                    panel5.Visible = false;
                    vb.Show();
                    vb.BringToFront();
                    return;
                }
            }
            uc_bills uc = new uc_bills();
            uc.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel5.Visible = false;
            panel1.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel1.Controls)
            {
                if (vb is uc_users)
                {
                    panel2.Controls.Clear();
                    panel5.Visible = false;
                    vb.Show();
                    vb.BringToFront();
                    return;
                }
            }
            uc_users uc = new uc_users();
            uc.Dock = DockStyle.Fill;

            panel5.Visible = false;
            panel2.Controls.Clear();
            panel1.Controls.Add(uc);
            uc.BringToFront();
        }
        
       

        private void btn_report_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel1.Controls)
            {
                if (vb is uc_report)
                {
                    panel2.Controls.Clear();
                    panel5.Visible = false;
                    vb.Show();
                    vb.BringToFront();
                    return;
                }
            }
            uc_report uc = new uc_report();
            uc.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel5.Visible = false;
            panel1.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btn_tables_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel1.Controls)
            {
                if (vb is uc_main_table)
                {
                    panel2.Controls.Clear();
                    panel5.Visible = false;
                    vb.Show();
                    vb.BringToFront();
                }
            }
            panel5.Visible = false;
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {

            this.btn_bill.Enabled = false;
            this.btn_categories.Enabled = false;
            this.btn_product.Enabled = false;
            this.btn_report.Enabled = false;
            this.btn_users.Enabled = false;
            this.btn_tables.Enabled = false;
            this.bunifuFlatButton3.Visible = false;

            foreach (Control vb in panel2.Controls)
            {
                if (vb is uc_login)
                {
                    panel5.Visible = false;
                    panel2.Show();
                    vb.Show();
                    vb.BringToFront();
                    return;
                }
            }

            uc_login uc = new uc_login();
            uc.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel2.Show();
            panel5.Visible = false;

            panel2.Controls.Add(uc);
            uc.BringToFront();

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {

            uc_user_pass uc = new uc_user_pass();
            uc.Dock = DockStyle.Fill;
            panel5.Visible = false;
            panel2.Show();
            panel2.Controls.Add(uc);
            uc.BringToFront();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            foreach (Control vb in panel1.Controls)
            {
                if (vb is bill_deleted_report)
                {
                    panel2.Controls.Clear();
                    panel5.Visible = false;
                    vb.Show();
                    vb.BringToFront();
                    return;
                }
            }
            bill_deleted_report uc = new bill_deleted_report();
            uc.Dock = DockStyle.Fill;

            panel2.Controls.Clear();
            panel5.Visible = false;
            panel1.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}