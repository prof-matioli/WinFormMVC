using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BD
{
    public partial class frmCliente : Form
    {
        DataSet dsCliente;
        int modo = 0; // 0 = neutro, 1 = inclusão, 2 = edição

        public frmCliente()
        {
            InitializeComponent();
            carregaListBox();
            Habilitar();
        }

        private void Habilitar()
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

        private void carregaListBox()
        {
            String sqlSelect = "select * from Cliente";
            try
            {
                //Lê a string de conexão do arquivo de configuração da aplicação, App.config
                String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open(); // tenta abrir a conexão
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dsCliente = new DataSet();
                    da.Fill(dsCliente, "Cliente");
                    DataTable dtCliente = dsCliente.Tables["Cliente"];

                    // 1. seta DisplayMember and ValueMember
                    lstClientes.DisplayMember = dtCliente.Columns["Nome"].ColumnName;
                    lstClientes.ValueMember = dtCliente.Columns["idCliente"].ColumnName;
                    // 2. seta DataSource
                    lstClientes.DataSource = dtCliente;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha ao tentar conectar com o BD!\n" + ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Falha geral do sistema!");
            }

        }

        private void cmdSelecionou(object sender, EventArgs e)
        {
            //String nome="";
            int id;

            //pego os valores direto do Listbox
            //nome = this.lstClientes.GetItemText(this.lstClientes.SelectedItem);
            id = Convert.ToInt32(this.lstClientes.SelectedValue);

            //Pesquiso o Cliente na DataTable, no DataSet, e crio uma DataRow com os 
            //dados do Cliente
            DataRow[] clientes = dsCliente.Tables["Cliente"].Select("idCliente=" + id);
            if (clientes != null)
            {
                Console.WriteLine("{0} - {1} - {2}", clientes[0][0], clientes[0][1], clientes[0][2]);
                idCliente.Text = clientes[0][0].ToString();
                txtNome.Text = clientes[0][1].ToString();
                txtCnpjCpf.Text = clientes[0][2].ToString();
            }
        }

        private void cmdEditar(object sender, EventArgs e)
        {
            modo = 2; //entra em modo edição
            Habilitar();
            txtNome.DeselectAll(); //desseleciona o texto
        }

        private void cmdSalvar(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            int linhasAfetadas = 0;
            try
            {
                //Lê a string de conexão do arquivo de configuração da aplicação, App.config
                con.ConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

                //procedimento de persistência em BD
                string updateSql = String.Format("UPDATE Cliente SET " +
                                    "Nome = @NOME, cpf_cnpj = @CPFCNPJ " +
                                    "WHERE idCliente = @ID ");
                con.Open(); // tenta abrir a conexão
                SqlCommand cmd = new SqlCommand(updateSql, con);
                cmd.Parameters.AddWithValue("NOME", txtNome.Text);
                cmd.Parameters.AddWithValue("CPFCNPJ", txtCnpjCpf.Text);
                cmd.Parameters.AddWithValue("ID", idCliente.Text);

                linhasAfetadas = cmd.ExecuteNonQuery();
                if (linhasAfetadas > 0)
                    MessageBox.Show("Dados atualizados com sucesso!", "Aviso do sisema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Falha ao atualizar dados!", "Aviso do sisema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha ao tentar conectar com o BD!\n" + ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Falha geral do sistema!");
            }
            finally
            {
                //se a conexão estiver aberta
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            //atualiza lista de clientes
            carregaListBox();

            //habilita/desabilita controles
            modo = 0; //sai do modo edição
            Habilitar();

        }

        private void cmdCancelar(object sender, EventArgs e)
        {
            //procedimento para cancelar operação corrente
            cmdSelecionou(null, null);

            //habilita/desabilita controles
            modo = 0; //sai do modo atual
            Habilitar();

        }

        private void cmdExcluir(object sender, EventArgs e)
        {
            //procedimento para excluir registro corrente
            SqlConnection con = new SqlConnection();
            int linhasAfetadas = 0;
            try
            {
                //Lê a string de conexão do arquivo de configuração da aplicação, App.config
                String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                con.ConnectionString = conString;
                //procedimento de persistência em BD
                string deleteSql = String.Format("DELETE FROM Cliente WHERE idCliente = @ID ");
                con.Open(); // tenta abrir a conexão
                SqlCommand cmd = new SqlCommand(deleteSql, con);
                cmd.Parameters.Add(new SqlParameter("ID", idCliente.Text));
                linhasAfetadas = cmd.ExecuteNonQuery();
                if (linhasAfetadas > 0)
                    MessageBox.Show("Dados excluidos com sucesso!", "Aviso do sisema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Falha ao excluir dados!", "Aviso do sisema", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falha ao tentar conectar com o BD!\n" + ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Falha geral do sistema!");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            //atualiza lista de clientes
            carregaListBox();

            //habilita/desabilita controles
            modo = 0; //sai do modo atual
            Habilitar();
        }

        private void cmdNovo(object sender, EventArgs e)
        {
            //procedimento para incluir novo registro
        }
    }
}
