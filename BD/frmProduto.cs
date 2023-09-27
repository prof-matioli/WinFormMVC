using System;
using System.Windows.Forms;
using Negocio;

namespace BD
{
    public partial class frmProduto : Form
    {
        private int modo = 0; // 0=netro; 1=inclusao; 2=alteração; 3=exclusão
        public frmProduto()
        {
            InitializeComponent();
        }
        private void frmProduto_Load(object sender, EventArgs e)
        {
            LoadData();
            //define o cabeçalho de cada coluna do GridView
            grdProdutos.Columns[0].HeaderText = "ID";
            grdProdutos.Columns[1].HeaderText = "NOME";
            grdProdutos.Columns[2].HeaderText = "DESCRIÇÃO";
            grdProdutos.Columns[3].HeaderText = "QUANTIDADE";
            grdProdutos.Columns[4].HeaderText = "PREÇO";
            grdProdutos.Columns[5].HeaderText = "UNID. MEDIDA";
        }

        private void habilita()
        {
            switch(modo)
            {
                case 0: //neutro
                    btnNovo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnExcluir.Enabled = true;
                    btnSalvar.Enabled = false;
                    btnCancelar.Enabled = false;
                    grpDados.Enabled = false;
                    grdProdutos.Enabled = true;
                    break;
                case 1: //inclusão
                    btnNovo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    grpDados.Enabled = true;
                    grdProdutos.Enabled = false;

                    break;
                case 2:
                    btnNovo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnSalvar.Enabled = true;
                    btnCancelar.Enabled = true;
                    grpDados.Enabled = true;
                    grdProdutos.Enabled = false;

                    break;
                case 3:
                    break;
            }

        }

        private void LoadData()
        {
            grdProdutos.DataSource = NProduto.Mostrar();
            modo = 0;
            habilita();
        }
        private void UpdateData()
        {
            int idProduto = Convert.ToInt32(grdProdutos.CurrentRow.Cells[0].Value.ToString());
            String nome = txtNome.Text;
            String descricao = txtDescricao.Text;
            float estoque = float.Parse(txtQtd.Text);
            Decimal preco = Convert.ToDecimal(txtPreco.Text);
            String unidade = txtUnidade.Text;
            string result = string.Empty;
            String msg = string.Empty;

            if (modo==1)
            {
                result = NProduto.Inserir(nome, descricao, estoque, preco, unidade);
                if (result=="SUCESSO")
                {
                    msg = "PRODUTO cadastrado com sucesso!";
                    LoadData();
                }
                else
                {
                    msg = "Falha ao cadastrar PRODUTO!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(modo==2)
            {
                result = NProduto.Editar(idProduto,nome,descricao,estoque,preco,unidade);
                if (result=="SUCESSO")
                {
                    msg = "PRODUTO cadastrado com sucesso!";
                    LoadData();
                }
                else
                {
                    msg = "Falha ao atualizar PRODUTO!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /*
                        try
                        {
                            int i = db.UpdateData(dtData);
                            MessageBox.Show(i + " : registros atualizados com sucesso!","Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.Message, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            */
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            UpdateData();
            modo = 0;
            habilita();
        }

        private void grdProdutos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null)
                return; //Or clear your TextBoxes
            txtNome.Text = grdProdutos.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = grdProdutos.CurrentRow.Cells[2].Value.ToString();
            txtQtd.Text = grdProdutos.CurrentRow.Cells[3].Value.ToString();
            txtPreco.Text = grdProdutos.CurrentRow.Cells[4].Value.ToString();
            txtUnidade.Text = grdProdutos.CurrentRow.Cells[5].Value.ToString();

        }

        public void limpaForm()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtQtd.Clear();
            txtPreco.Clear();
            txtUnidade.Clear();
            txtNome.Focus();
        }

        private void btnNovoSalvar(object sender, EventArgs e)
        {
            modo = 1;
            habilita();
            limpaForm();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            modo = 2;
            habilita();
        }
    }
}
