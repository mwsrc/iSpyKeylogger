using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Galaxy_Logger.Forms
{
    public partial class frmNews : Form
    {
        private Dictionary<string, NewsPost> news = new Dictionary<string, NewsPost>();
        public frmNews()
        {
            InitializeComponent();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(LicenseGlobal.Seal.GetPostMessage(news[listView1.SelectedItems[0].ToString()].ID));
        }

        private void frmNews_Load(object sender, EventArgs e)
        {
            foreach (NewsPost P in LicenseGlobal.Seal.News)
            {
                news.Add(P.Name, P);
                listView1.Items.Add(P.Name);
            }
        }

        private void slcClose1_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
