using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Setup.InstallProgress;

namespace Setup
{
    public partial class BrowseForFolder : Form
    {
        public BrowseForFolder()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text += folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            InstallProgress ip = new InstallProgress();
            ip.FormClosed += (s, args) => this.Close();
            ip.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult msgID = MessageBox.Show(
                "Are you want to close the installation?",
                "Warning!",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
                );
            if (msgID == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
