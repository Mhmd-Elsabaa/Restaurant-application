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
    public partial class uc_category_managment : UserControl
    {
        BL.class_products prod = new BL.class_products();
        public uc_category_managment()
        {
            InitializeComponent();
            bunifuCustomDataGrid1.DataSource = prod.get_all_categories();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuFlatButton4.Enabled = true;
            bunifuFlatButton1.Enabled = false;
            bunifuFlatButton2.Enabled = false;
            bunifuFlatButton3.Enabled = false;
            bunifuMetroTextbox1.Enabled = true;
            bunifuFlatButton4.Text = "اضافه";
            bunifuCustomDataGrid1.Enabled = false;
            bunifuFlatButton5.Enabled = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد من حذف الصنف المحدد", "عمليه الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                prod.delete_category(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());

                bunifuCustomDataGrid1.DataSource = prod.get_all_categories();
                MessageBox.Show("تمت عمليه الحذف بنجاح", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            bunifuFlatButton4.Enabled = true;
            bunifuFlatButton1.Enabled = false;
            bunifuFlatButton2.Enabled = false;
            bunifuFlatButton3.Enabled = false;
            bunifuMetroTextbox1.Enabled = true;
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            bunifuFlatButton4.Text = "تعديل";
            bunifuCustomDataGrid1.Enabled = false;
            bunifuFlatButton5.Enabled = true;

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            if(bunifuFlatButton4.Text == "اضافه")
            {
                DataTable dt = prod.verify_category_name(bunifuMetroTextbox1.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا الصنف موجود بالفعل", " تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuMetroTextbox1.Focus();
                    bunifuMetroTextbox1.Select();
                }
                else
                {
                    prod.add_category(bunifuMetroTextbox1.Text);
                    bunifuCustomDataGrid1.DataSource = prod.get_all_categories();
                    MessageBox.Show("تمت عمليه الاضافه بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuFlatButton4.Enabled = false;
                    bunifuFlatButton5.Enabled = false;
                    bunifuFlatButton4.Text = "";
                    bunifuMetroTextbox1.Text = "";
                    bunifuMetroTextbox1.Enabled = false;
                    bunifuCustomDataGrid1.Enabled = true;
                    bunifuFlatButton1.Enabled = true;
                    bunifuFlatButton2.Enabled = true;
                    bunifuFlatButton3.Enabled = true;
                }

                

            }
            else if (bunifuFlatButton4.Text == "تعديل")
            {

                DataTable dt = prod.verify_update_category_name(bunifuMetroTextbox1.Text, bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا الصنف موجود بالفعل", " تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuMetroTextbox1.Focus();
                    bunifuMetroTextbox1.Select();
                }
                else
                {
                    prod.update_category(bunifuMetroTextbox1.Text, bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());
                    bunifuCustomDataGrid1.DataSource = prod.get_all_categories();
                    MessageBox.Show("تمت عمليه التعديل بنجاح", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuFlatButton4.Enabled = false;
                    bunifuFlatButton5.Enabled = false;
                    bunifuFlatButton4.Text = "";
                    bunifuMetroTextbox1.Text = "";
                    bunifuMetroTextbox1.Enabled = false;
                    bunifuCustomDataGrid1.Enabled = true;
                    bunifuFlatButton1.Enabled = true;
                    bunifuFlatButton2.Enabled = true;
                    bunifuFlatButton3.Enabled = true;
                }
            }
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            bunifuFlatButton4.Enabled = false;
            bunifuFlatButton5.Enabled = false;
            bunifuFlatButton4.Text = "";
            bunifuMetroTextbox1.Enabled = false;
            bunifuCustomDataGrid1.Enabled = true;
            bunifuMetroTextbox1.Text = "";
            bunifuFlatButton1.Enabled = true;
            bunifuFlatButton2.Enabled = true;
            bunifuFlatButton3.Enabled = true;
        }

        
    }
}
