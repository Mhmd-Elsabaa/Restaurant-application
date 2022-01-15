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
    public partial class connection_vars : Form
    {
        public connection_vars()
        {
            InitializeComponent();

            txtServer.Text = Properties.Settings.Default.server;
            txtDatabase.Text = Properties.Settings.Default.database;
            if(Properties.Settings.Default.mode == "sql")
            {
                rbsql.Checked = true;
                txtuser.Text = Properties.Settings.Default.id;
                txtpass.Text = Properties.Settings.Default.pass;
            }
            else
            {
                rbwindows.Checked = true;
                txtuser.Clear();
                txtpass.Clear();
                txtuser.ReadOnly = true;
                txtpass.ReadOnly = true;
            }
            
         
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.server = txtServer.Text;
            Properties.Settings.Default.database = txtDatabase.Text;
            Properties.Settings.Default.mode = rbsql.Checked == true ? "sql" : "windows";
            Properties.Settings.Default.id = txtuser.Text;
            Properties.Settings.Default.pass = txtpass.Text;

            Properties.Settings.Default.Save();
            this.Dispose();
        }

        private void rbsql_CheckedChanged(object sender, EventArgs e)
        {
            txtuser.ReadOnly = false;
            txtpass.ReadOnly = false;
        }

        private void rbwindows_CheckedChanged(object sender, EventArgs e)
        {
            txtuser.ReadOnly = true;
            txtpass.ReadOnly = true;
            txtuser.Clear();
            txtpass.Clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
