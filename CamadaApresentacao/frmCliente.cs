using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class frmCliente : Form
    {
        DataTable dtCliente;
        int modo = 0; // 0 = neutro, 1 = inclusão, 2 = edição

        public frmCliente()
        {
            InitializeComponent();
            LoadData();
            Habilita();
        }

        private void Habilita()
        {
            if (modo == 0) //modo padrão
            {
                btnNovo.Enabled = true;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                grpLstClientes.Enabled = true;

                txtNome.Enabled = false;
                txtCnpjCpf.Enabled = false;
            }
            else if (modo == 1) //modo de inclusão de novos registros
            {
                btnNovo.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                grpLstClientes.Enabled = false;

                txtNome.Enabled = true;
                txtNome.Clear();
                txtCnpjCpf.Enabled = true;
                txtCnpjCpf.Clear();

                txtNome.Focus(); //posiciona o cursor no campo Nome
            }
            else if (modo == 2) //modo de edição de registros
            {
                btnNovo.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;

                grpLstClientes.Enabled = false;

                txtNome.Enabled = true;
                txtCnpjCpf.Enabled = true;

                txtNome.Focus();  //posiciona o cursor no campo Nome
            }

        }


        public void LimpaForm()
        {
            ilblIdCliente.Text = "";
            txtNome.Clear();
            txtCnpjCpf.Clear();
            lstClientes.SelectedIndex = -1; //nenhum elemento selecionado
            txtNome.Focus();
        }

        private void cmdSelecionou(object sender, EventArgs e)
        {
            if (sender == null) return;

            ListBox row = (ListBox)sender;
            if (row.SelectedIndex == -1)
                return;

            //Pesquiso o Cliente na DataTable, no DataSet, e crio uma DataRow com os 
            //dados do Cliente
            DataRow[] clientes = dtCliente.Select("idCliente=" + this.lstClientes.SelectedValue);
            if (clientes != null)
            {
                ilblIdCliente.Text = clientes[0][0].ToString();
                txtNome.Text = clientes[0][1].ToString();
                txtCnpjCpf.Text = clientes[0][2].ToString();
            }
        }

        private void cmdEditar(object sender, EventArgs e)
        {
            modo = 2; //entra em modo edição
            Habilita();
            txtNome.DeselectAll(); //desseleciona o texto
        }

        private void LoadData()
        {
            this.dtCliente = NCliente.Mostrar();
            // 1. seta DisplayMember and ValueMember
            lstClientes.DisplayMember = this.dtCliente.Columns["Nome"].ColumnName;
            lstClientes.ValueMember = this.dtCliente.Columns["idCliente"].ColumnName;
            lstClientes.DataSource = this.dtCliente;

            modo = 0;
            Habilita();
        }

        private void UpdateData()
        {
            int idCliente;
            String nome = txtNome.Text;
            String doc = txtCnpjCpf.Text;

            string result;
            String msg;

            if (modo == 1)
            {
                result = NCliente.Inserir(nome, doc);
                if (result == "SUCESSO")
                {
                    msg = "CLIENTE cadastrado com sucesso!";
                    LoadData();
                }
                else
                {
                    msg = "Falha ao cadastrar CLIENTE!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (modo == 2)
            {
                idCliente = Convert.ToInt32(ilblIdCliente.Text);
                result = NCliente.Editar(idCliente, nome, doc);
                if (result == "SUCESSO")
                {
                    msg = "CLIENTE atualizado com sucesso!";
                    LoadData();
                }
                else
                {
                    msg = "Falha ao atualizar CLIENTE!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (modo == 3)
            {
                idCliente = Convert.ToInt32(ilblIdCliente.Text);
                result = NCliente.Excluir(idCliente);
                if (result == "SUCESSO")
                {
                    msg = "CLIENTE excluido com sucesso!";
                    LoadData();
                }
                else
                {
                    msg = "Falha ao excluir CLIENTE!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void cmdSalvar(object sender, EventArgs e)
        {
            UpdateData();
            modo = 0;
            Habilita();
        }

        private void cmdCancelar(object sender, EventArgs e)
        {
            //procedimento para cancelar operação corrente
            cmdSelecionou(null, null);

            //habilita/desabilita controles
            modo = 0; //sai do modo atual
            Habilita();

        }

        private void cmdExcluir(object sender, EventArgs e)
        {
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma exclusão?", "Aviso do sistema!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.OK)
            {
                modo = 3;
                UpdateData();
            }
        }

        private void cmdNovo(object sender, EventArgs e)
        {
            //procedimento para incluir novo registro
            modo = 1;
            Habilita();
            LimpaForm();

        }
    }
}
