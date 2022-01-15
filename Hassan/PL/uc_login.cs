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
    public partial class uc_login : UserControl
    {
        BL.class_users_login log = new BL.class_users_login();
        public uc_login()
        {
            InitializeComponent();
        }
        private void click_log()
        {
            DataTable dt = log.login(bunifuMaterialTextbox1.Text, bunifuMaterialTextbox2.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][2].ToString() == "admin")
                {
                    form_main.user_name = bunifuMaterialTextbox1.Text;
                    form_main.user_password = bunifuMaterialTextbox2.Text;
                    form_main.user_type = "admin";

                    form_main.get_main_form.btn_product.Enabled = true;
                    form_main.get_main_form.btn_bill.Enabled = true;
                    form_main.get_main_form.btn_categories.Enabled = true;
                    form_main.get_main_form.btn_report.Enabled = true;
                    form_main.get_main_form.btn_tables.Enabled = true;
                    form_main.get_main_form.btn_users.Enabled = true;
                    form_main.get_main_form.bunifuFlatButton3.Visible = false;
                    this.Hide();
                }
                else if(dt.Rows[0][2].ToString() == "pres")
                {
                    form_main.user_name = bunifuMaterialTextbox1.Text;
                    form_main.user_password = bunifuMaterialTextbox2.Text;
                    form_main.user_type = "admin";

                    form_main.get_main_form.btn_product.Enabled = true;
                    form_main.get_main_form.btn_bill.Enabled = true;
                    form_main.get_main_form.btn_categories.Enabled = true;
                    form_main.get_main_form.btn_report.Enabled = true;
                    form_main.get_main_form.btn_tables.Enabled = true;
                    form_main.get_main_form.btn_users.Enabled = true;
                    form_main.get_main_form.bunifuFlatButton3.Visible = true;
                    this.Hide();
                }
                else
                {
                    form_main.user_name = bunifuMaterialTextbox1.Text;
                    form_main.user_password = bunifuMaterialTextbox2.Text;
                    form_main.user_type = "user";

                    form_main.get_main_form.btn_tables.Enabled = true;
                    form_main.get_main_form.btn_bill.Enabled = true;
                    form_main.get_main_form.bunifuFlatButton3.Visible = false;
                    this.Hide();
                }
                uc_bills uc = new uc_bills();
                uc.Dock = DockStyle.Fill;
                form_main.get_main_form.panel2.Controls.Clear();
                form_main.get_main_form.panel1.Controls.Add(uc);
                uc.BringToFront();

            }
            else
            {
                MessageBox.Show("فشل الدخول");
            }
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            click_log();
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
        }

        private void bunifuMaterialTextbox2_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                click_log();
            }
        }
    }
}
