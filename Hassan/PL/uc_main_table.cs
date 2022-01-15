using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Bunifu.Framework.UI;

namespace RestaurantApp.PL
{
    public partial class uc_main_table : UserControl
    {
        public uc_main_table()
        {
            InitializeComponent();
        }


        private void bunifuFlatButton16_Click(object sender, EventArgs e)
        {
            BunifuFlatButton b = (BunifuFlatButton)sender;
            string txt = b.Text;
            FormCollection forms;

  
            forms = Application.OpenForms;

            foreach (Form form in forms)
            {

                if (form.Visible == false && form.Text == txt)
                {
                    form.Visible = true;
                    b.Visible = false;
                    form.Show();
                    return;
                        
                }
            }
            
            b.Visible = false;
            form_table f = new form_table();
            f.Text = txt;
            int i= int.Parse(txt);
            form_main.order_num[i - 1] = 1;
            f.Show();

        }

    }

}
