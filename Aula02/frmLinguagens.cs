using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula02
{
    public partial class frmLinguagens : Form
    {
        public frmLinguagens()
        {
            InitializeComponent();
        }

        private void cmdVerifica(object sender, EventArgs e)
        {
            label4.Text = "";
            if (checkBox1.Checked)
                label4.Text = label4.Text + checkBox1.Text;
            if (checkBox2.Checked)
                label4.Text = label4.Text + checkBox2.Text;
            if (checkBox3.Checked)
                label4.Text = label4.Text + checkBox3.Text;
            if (checkBox4.Checked)
                label4.Text = label4.Text + checkBox4.Text;
        }
    }
}
