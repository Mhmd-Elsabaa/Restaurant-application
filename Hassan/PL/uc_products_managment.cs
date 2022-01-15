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
    public partial class uc_products_managment : UserControl
    {
        BL.class_products prod = new BL.class_products();
        public uc_products_managment()
        {
            InitializeComponent();
            bunifuCustomDataGrid1.DataSource = prod.get_all_products();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = prod.products_search(bunifuTextbox1.text);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            foreach (Control vb in form_main.get_main_form.panel1.Controls)
            {
                vb.Hide();
            }

            foreach (Control c in form_main.get_main_form.panel2.Controls) { c.Dispose(); }
            form_main.get_main_form.panel2.Controls.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            form_main.get_main_form.panel2.Show();

            uc_add_product uc = new uc_add_product();
            uc.Dock = DockStyle.Fill;

            form_main.get_main_form.panel2.Controls.Add(uc);
            uc.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("هل انت متأكد من حذف المنتج المحدد","عمليه الحذف",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {
                prod.delete_product(bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString());

                bunifuCustomDataGrid1.DataSource = prod.get_all_products();
                MessageBox.Show("تمت عمليه الحذف بنجاح", "عمليه الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            uc_add_product uc = new uc_add_product();
            uc.Dock = DockStyle.Fill;
            uc.state = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();

            uc.comboBox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();

            uc.bunifuMaterialTextbox1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            uc.bunifuMaterialTextbox2.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            uc.bunifuFlatButton1.Text = "تحديث";


            foreach (Control c in form_main.get_main_form.panel2.Controls) { c.Dispose(); }
            form_main.get_main_form.panel2.Controls.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();


            foreach (Control vb in form_main.get_main_form.panel1.Controls)
            {
                vb.Hide();
                
            }
            form_main.get_main_form.panel2.Show();
            form_main.get_main_form.panel2.Controls.Add(uc);
            uc.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.DataSource = prod.get_all_products();
        }
    }
}
