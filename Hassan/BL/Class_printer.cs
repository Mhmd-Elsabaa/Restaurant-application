using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.Threading;

namespace RestaurantApp.BL
{
    class Class_printer
    {
        public void print_delevry(DataTable dt)
        {
            int i = 0;
            go1:
                try
                {
                    report.rpt_orders rep = new report.rpt_orders();
                    rep.SetDataSource(dt);


                    rep.PrintOptions.PrinterName = Properties.Settings.Default.k_printer;
                    rep.PrintToPrinter(1, true, 0, 0);


                    rep.PrintOptions.PrinterName = Properties.Settings.Default.printer;
                    rep.PrintToPrinter(1, true, 0, 0);

                    rep.Refresh();
                    rep.Close();
                    rep.Dispose();
                    GC.SuppressFinalize(rep);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    PL.select_printers fcon = new PL.select_printers();
                    fcon.ShowDialog();

                    if (i > 0)
                    {
                        MessageBox.Show("تم حفظ الفاتوره ولكن لم يتم طباعتها :   اطبعها من زر طباعة اخر فاتوره   بعد التاكد من عمل الطابعات");
                        return;
                    }
                    i++;
                    goto go1;

                }
            
        }

        public void print_safry(DataTable dt,string name)
        {
            int i = 0;
            go2:
                try
                {
                    report.rpt_safry rep = new report.rpt_safry();
                    rep.SetDataSource(dt);
                    rep.SetParameterValue("cust_name", name);
                    rep.PrintOptions.PrinterName = Properties.Settings.Default.printer;
                    rep.PrintToPrinter(1, true, 0, 0);
                    rep.PrintOptions.PrinterName = Properties.Settings.Default.k_printer;
                    rep.PrintToPrinter(1, true, 0, 0);
                    rep.Refresh();
                    rep.Close();
                    rep.Dispose();
                    GC.SuppressFinalize(rep);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    PL.select_printers fcon = new PL.select_printers();
                    fcon.ShowDialog();
                    if(i>1)
                    {
                        MessageBox.Show("تم حفظ الفاتوره ولكن لم يتم طباعتها :   اطبعها من زر طباعة اخر فاتوره    بعد التاكد من عمل الطابعات");
                        return;
                    }
                    i++;
                    goto go2;

                }
           
        }

        public void ptint_table(DataTable dt, string txt)
        {
            int i = 0;
            go3:

                try
                {
                    report.rpt_place rep = new report.rpt_place();
                    rep.SetDataSource(dt);
                    rep.SetParameterValue("table", txt);
                    rep.PrintOptions.PrinterName = Properties.Settings.Default.printer;
                    rep.PrintToPrinter(1, true, 0, 0);
                    rep.Refresh();
                    rep.Close();
                    rep.Dispose();
                    GC.SuppressFinalize(rep);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    PL.select_printers fcon = new PL.select_printers();
                    fcon.ShowDialog();
                    if (i > 1)
                    {
                        MessageBox.Show("تم حفظ الفاتوره ولكن لم يتم طباعتها :   اطبعها من زر طباعة اخر فاتوره    بعد التاكد من عمل الطابعات");
                        return;
                    }
                    i++;
                    goto go3;
                }
            
        }

        public bool ptint_kitchen(DataTable dt, string txt, string num,DateTime t,string who)
        {
            int i = 0;
            go4:
                try
                {
                    report.rpt_kitchen rep = new report.rpt_kitchen();
                    rep.Database.Tables["kitchen_order"].SetDataSource(dt);
                    rep.SetParameterValue("table", txt);
                    rep.SetParameterValue("order_num", num);
                    rep.SetParameterValue("time", t);
                    rep.SetParameterValue("who", who);
                    rep.PrintOptions.PrinterName = Properties.Settings.Default.k_printer;
                    rep.PrintToPrinter(1, true, 0, 0);

                    rep.Refresh();
                    rep.Database.Dispose();
                    rep.Close();
                    rep.Dispose();
                    GC.SuppressFinalize(rep);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    PL.select_printers fcon = new PL.select_printers();
                    fcon.ShowDialog();

                    if (i > 1)
                    {
                        return false;
                    }
                    i++;
                    goto go4;    

                }
            

        }
    }
}
