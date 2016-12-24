using Galaxy_Logger.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Galaxy_Logger.Forms
{
    public partial class frmScanner : Form
    {
        public frmScanner()
        {
            InitializeComponent();
        }

        private void slcClose1_Click_1(object sender, EventArgs e)
        {
            Hide();
        }

        private void slCbtn1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog odf = new OpenFileDialog();
            if (odf.ShowDialog() != DialogResult.OK) return;
            scan(odf.FileName);
        }
        private void scan(string file)
        {
            slcTextBox1.Text = "";
            listView1.Items.Clear();
            slcTextBox2.Text = "";
            reFUDme scan = new reFUDme("nexisgay");// TODO: set this to .net seal variable
            //scan.ScanState += scan_ScanState;
            new Thread(() =>
            {
                scan.scan(file);
                Invoke(new MethodInvoker(() =>
                {
                    foreach (KeyValuePair<string, string> result in scan.Results)
                    {
                        ListViewItem item = new ListViewItem();
                        Color main = result.Value.Contains("OK") ? Color.LimeGreen : Color.Red;
                        item.Text = result.Key;
                        item.ForeColor = main;
                        item.UseItemStyleForSubItems = true;

                        item.SubItems.Add(result.Value, main, item.BackColor, item.Font);
                        listView1.Items.Add(item);
                    }
                    slcTextBox1.Text = scan.detectionCount + "/35";
                    slcTextBox2.Text = scan.link;
                }));
            }).Start();

        }
    }
}
