using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace RestaurantApp.PL
{
    public partial class select_printers : Form
    {
        public select_printers()
        {
            InitializeComponent();
            
            foreach(var v in PrinterSettings.InstalledPrinters)
            {
                listBox1.Items.Add(v);
                listBox2.Items.Add(v);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1)
            {
                Properties.Settings.Default.printer = listBox1.SelectedItem.ToString();
                Properties.Settings.Default.k_printer = listBox2.SelectedItem.ToString();
                Properties.Settings.Default.Save();

                this.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            else
            {
                MessageBox.Show("برجاء تحديد الطابعات اولا");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (var v in PrinterSettings.InstalledPrinters)
            {
                listBox1.Items.Add(v);
                listBox2.Items.Add(v);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
