using System;
using System.Windows.Forms;

namespace View
{
    public partial class frmPrincipal : Form
    {
        //variáveis de instâncias dos forms
        private FrmProduto fProduto = null;
        private frmCliente fCliente = null;
        private frmVenda fVenda = null;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        //Método genérico para verificar se já existe uma instância de um 
        //determinado form. Se já existir, apenas ativa ele, senão cria nova instância.
        //O objeto que contém/conterá a instância do form e o tipo (classe) do form
        //serão passados por parâmetros.
        private Form ShowOrActiveForm(Form form, Type t)
        {
            if (form == null)
            {
                form = (Form)Activator.CreateInstance(t);
                form.MdiParent = this;
                form.Show();
            }
            else
            {
                if (form.IsDisposed)
                {
                    form = (Form)Activator.CreateInstance(t);
                    form.MdiParent = this;
                    form.Show();
                }
                else
                {
                    form.Activate();
                }
            }
            return form;
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            frmCliente fCliente = new frmCliente();
            fCliente.MdiParent = this;
            fCliente.Show();
            */
            fCliente = ShowOrActiveForm(fCliente, typeof(frmCliente)) as frmCliente;
        }

        private void mnuProduto(object sender, EventArgs e)
        {
            /*
            FrmProduto fProduto = new FrmProduto();
            fProduto.MdiParent = this;
            fProduto.Show();
            */
            fProduto= ShowOrActiveForm(fProduto, typeof(FrmProduto)) as FrmProduto;

        }

        private void frmClose(object sender, FormClosingEventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Confirma saída?", "Aviso do sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(resp==DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fVenda = ShowOrActiveForm(fVenda, typeof(frmVenda)) as frmVenda;
        }
    }
}
