using System;
using System.Data;
using System.Windows.Forms;
using Negocio;

namespace BD
{
    public partial class FrmProduto : Form
    {
        private int modo = 0; // 0=netro; 1=inclusao; 2=alteração; 3=exclusão
        public FrmProduto()
        {
            InitializeComponent();
        }
        private void FrmProduto_Load(object sender, EventArgs e)
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

        private void Habilita()
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
            Habilita();
        }

        private void UpdateData()
        {
            int idProduto = Convert.ToInt32(grdProdutos.CurrentRow.Cells[0].Value.ToString());
            String nome = txtNome.Text;
            String descricao = txtDescricao.Text;
            float estoque = float.Parse(txtQtd.Text);
            Decimal preco = Convert.ToDecimal(txtPreco.Text);
            String unidade = txtUnidade.Text;
            string result;
            String msg;

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
                    msg = "PRODUTO atualizado com sucesso!";
                    LoadData();
                }
                else
                {
                    msg = "Falha ao atualizar PRODUTO!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(modo==3)
            {
                result = NProduto.Excluir(idProduto);
                if (result == "SUCESSO")
                {
                    msg = "PRODUTO excluido com sucesso!";
                    LoadData();
                }
                else
                {
                    msg = "Falha ao excluir PRODUTO!";
                }
                MessageBox.Show(msg, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            UpdateData();
            modo = 0;
            Habilita();
        }

        private void GrdProdutos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView row = (DataGridView)sender;
            if (row.CurrentRow == null)
                return; 
            
            //limpa os TextBoxes
            txtNome.Text = grdProdutos.CurrentRow.Cells[1].Value.ToString();
            txtDescricao.Text = grdProdutos.CurrentRow.Cells[2].Value.ToString();
            txtQtd.Text = grdProdutos.CurrentRow.Cells[3].Value.ToString();
            txtPreco.Text = grdProdutos.CurrentRow.Cells[4].Value.ToString();
            txtUnidade.Text = grdProdutos.CurrentRow.Cells[5].Value.ToString();

        }

        public void LimpaForm()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtQtd.Clear();
            txtPreco.Clear();
            txtUnidade.Clear();
            txtNome.Focus();
        }

        private void BtnNovoSalvar(object sender, EventArgs e)
        {
            modo = 1;
            Habilita();
            LimpaForm();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            modo = 2;
            Habilita();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resposta;
            resposta = MessageBox.Show("Confirma exclusão?", "Aviso do sistema!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resposta == DialogResult.OK)
            {
                modo = 3;
                UpdateData();
            }
        }

        private void ImgFiltraNome_Click(object sender, EventArgs e)
        {
         }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            string filtroNome = txtFiltro.Text.Trim();
            DataTable fltProdutos = NProduto.BuscarNome(filtroNome);
            if (fltProdutos != null)
            {
                grdProdutos.DataSource = fltProdutos;
                grdProdutos.Refresh();
            }
            else
            {
                MessageBox.Show("Nenhum regisrto encontrado!", "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            grpBotoes.Visible = true;

        }

        private void ImgFiltraNome_Click_1(object sender, EventArgs e)
        {
            grpBotoes.Visible = false;

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
