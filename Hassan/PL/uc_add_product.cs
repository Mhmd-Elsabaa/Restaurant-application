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
    public partial class uc_add_product : UserControl
    {
        BL.class_products prod = new BL.class_products();
        public string state = "add";

        public uc_add_product()
        {
            InitializeComponent();
            comboBox1.DataSource = prod.get_all_cat();
            comboBox1.DisplayMember = "الصنف";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                if (bunifuMaterialTextbox1.Text.Length > 0 && bunifuMaterialTextbox2.Text.Length > 0)
                {
                    float x;
                    if (float.TryParse(bunifuMaterialTextbox2.Text, out x))
                    {
                        prod.add_product(bunifuMaterialTextbox1.Text, x, comboBox1.GetItemText(comboBox1.SelectedItem));
                        MessageBox.Show("تمت الاضافه بنجاح", "عمليه الاضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bunifuMaterialTextbox1.Text = "";
                        bunifuMaterialTextbox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("من فضلك ادخل سعر صحيح");
                    }
                }
                else
                {
                    MessageBox.Show("تأكد من ملأ البيانات بطريقه صحيحه", " تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (bunifuMaterialTextbox1.Text.Length > 0 && bunifuMaterialTextbox2.Text.Length > 0)
                {
                    float x;
                    if (float.TryParse(bunifuMaterialTextbox2.Text, out x))
                    {
                        prod.update_product(state, bunifuMaterialTextbox1.Text, x, comboBox1.GetItemText(comboBox1.SelectedItem));

                        MessageBox.Show("تم التعديل بنجاح", "عمليه التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        foreach (Control vb in form_main.get_main_form.panel1.Controls)
                        {
                            if (vb is uc_products_managment)
                            {
                                vb.Show();
                                vb.BringToFront();
                                return;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("من فضلك ادخل سعر صحيح");
                    }
                }
                else
                {
                    MessageBox.Show("تأكد من ملأ البيانات بطريقه صحيحه", " تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void bunifuMaterialTextbox1_Validated(object sender, EventArgs e)
        {
            if(state == "add")
            {
                DataTable dt = prod.verify_product_name(bunifuMaterialTextbox1.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا المنتج موجود بالفعل", " تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuMaterialTextbox1.Focus();
                    bunifuMaterialTextbox1.Select();
                }
            }
            else
            {
                DataTable dt = prod.verify_update_product(bunifuMaterialTextbox1.Text, state);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("هذا المنتج موجود بالفعل", " تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuMaterialTextbox1.Focus();
                    bunifuMaterialTextbox1.Select();
                }
            }

           
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            foreach (Control vb in form_main.get_main_form.panel1.Controls)
            {
                if (vb is uc_products_managment)
                {
                    vb.Show();
                    vb.BringToFront();
                    return;
                }
            }
        }
    }
}
