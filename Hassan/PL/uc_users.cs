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
    public partial class uc_users : UserControl
    {
        BL.class_customers cust = new BL.class_customers();
        public uc_users()
        {
            InitializeComponent();
        }

        private void uc_users_Load(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = cust.get_all_users();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(bunifuCustomDataGrid2.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("هل انت متأكد من حذف المستخدم المحدد", "عمليه الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    cust.delete_user(bunifuCustomDataGrid2.CurrentRow.Cells[0].Value.ToString());
                    bunifuCustomDataGrid2.DataSource = cust.get_all_users();
                }
            }
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox2.Text = "";
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if(bunifuMetroTextbox1.Text != ""&& bunifuMetroTextbox2.Text != "")
            {
                DataTable dt = cust.verify_user_name(bunifuMetroTextbox1.Text);
                if (dt.Rows.Count <= 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        cust.add_user(bunifuMetroTextbox1.Text, bunifuMetroTextbox2.Text, "user", "ok");
                    }
                    else
                    {
                        cust.add_user(bunifuMetroTextbox1.Text, bunifuMetroTextbox2.Text, "admin", "ok");
                    }
                    bunifuCustomDataGrid2.DataSource = cust.get_all_users();
                    panel1.Visible = false;
                    bunifuMetroTextbox1.Text = "";
                    bunifuMetroTextbox2.Text = "";
                }
                else
                {
                    MessageBox.Show("جرب اسم اخر", " تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuMetroTextbox1.Focus();
                    bunifuMetroTextbox1.Select();
                }
            }
            else
            {
                MessageBox.Show("ادخل البانات اولا");
            }
            

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = cust.get_all_admins();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid2.DataSource = cust.get_all_users();
        }
    }
}
