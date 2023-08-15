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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void cmdProcessar(object sender, EventArgs e)
        {
            if (txtSenha.Text != "COTIL")
            {
                lblNome.Text = "Senha inválida!";
            }
            else
            {
                lblNome.Text = "Seja bem vindo!";
            }
        }

        private void cmdAtualizarLabel(object sender, EventArgs e)
        {
            lblNome.Text = txtNome.Text;
        }

        private void cmdNovoForm(object sender, EventArgs e)
        {
            frmGroupBox oGroupBox = new frmGroupBox();
            oGroupBox.ShowDialog();
        }
    }
}
