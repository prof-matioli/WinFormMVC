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
    public partial class frmGroupBox : Form
    {
        public frmGroupBox()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            String curso = "";
            short serie = 0;
            if (rdCurso1.Checked) curso = rdCurso1.Text;
            else if (rdCurso2.Checked) curso = rdCurso2.Text;
            else if (rdCurso3.Checked) curso = rdCurso3.Text;

            if (rdPrimeira.Checked) serie = 1;
            else if (rdSegunda.Checked) serie = 2;
            else if (rdTerceira.Checked) serie = 3;

            if ((!String.IsNullOrEmpty(curso)) && (serie != 0))
            {
                lblMostrar.Text = "O aluno faz o curso " + curso + 
                    " e está na "+ serie +"ª série";
            }
            else
            {
                MessageBox.Show("Escolha um curso e uma série!", "Aviso do sistema!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
