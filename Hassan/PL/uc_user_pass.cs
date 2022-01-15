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
    public partial class uc_user_pass : UserControl
    {
        BL.class_customers user = new BL.class_customers();
        public uc_user_pass()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(bunifuMetroTextbox2.Text == form_main.user_name && bunifuMetroTextbox1.Text == form_main.user_password)
            {
                if(bunifuMetroTextbox3.Text == bunifuMetroTextbox4.Text)
                {
                    user.update_user_password(bunifuMetroTextbox2.Text, bunifuMetroTextbox3.Text);
                    form_main.get_main_form.panel2.Controls.Clear();
                    form_main.get_main_form.panel5.Visible = true;
                    form_main.user_password = bunifuMetroTextbox3.Text;
                }
                else
                {
                    MessageBox.Show("كلمه المرور الجديده غير متطابقه");
                }
            }
            else
            {
                MessageBox.Show("خطأ في اسم المستخدم او كلمه المرور");
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            form_main.get_main_form.panel2.Controls.Clear();
            form_main.get_main_form.panel5.Visible = true;
        }
    }
}
