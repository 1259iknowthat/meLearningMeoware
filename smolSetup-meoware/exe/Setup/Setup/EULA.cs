using static Setup.BrowseForFolder;

namespace Setup
{
    public partial class EULA : Form
    {
        public EULA()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxMark = checkBox1.Checked;
        }

        private void EULA_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.checkBoxMark)
            {
                this.Hide();
                BrowseForFolder bff = new BrowseForFolder();
                bff.FormClosed += (s, args) => this.Close();
                bff.Show();
            }
        }
    }
}