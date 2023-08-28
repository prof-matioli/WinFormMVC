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
        int modo = 0; // 0 = neutro

        public frmCliente()
        {
            InitializeComponent();
            carregaListBox();
            habilitar();
        }

        private void habilitar()
        {
            if(modo==0)
            {
                btnNovo.Enabled = true;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;

                txtNome.Enabled = false;
                txtCnpjCpf.Enabled = false;
            }else if(modo == 1)
            {
                btnNovo.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;

                txtNome.Enabled = true;
                txtNome.Clear();
                txtCnpjCpf.Enabled = true;
                txtCnpjCpf.Clear();

                txtNome.Focus(); //posiciona o cursor no campo Nome
            }
            else if(modo == 2)
            {
                btnNovo.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;

                txtNome.Enabled = true;
                txtCnpjCpf.Enabled = true;

                txtNome.Focus();  //posiciona o cursor no campo Nome
            }

        }

        private void carregaListBox()
        {
            String sqlSelect = "select * from Cliente";
            SqlConnection con;
            try
            {
                //Lê a string de conexão do arquivo de configuração da aplicação, App.config
                String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (con = new SqlConnection(conString))
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
            DataRow[] clientes = dsCliente.Tables["Cliente"].Select("idCliente="+id);
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
            habilitar();
        }

        private void cmdSalvar(object sender, EventArgs e)
        {
            //procedimento de persistência em BD


            //habilita/desabilita controles
            modo = 0; //sai do modo edição
            habilitar();
 
        }

        private void cmdCancelar(object sender, EventArgs e)
        {
            //procedimento para cancelar operação corrente


            //habilita/desabilita controles
            modo = 0; //sai do modo atual
            habilitar();

        }

        private void cmdExcluir(object sender, EventArgs e)
        {
            //procedimento para excluir registro corrente
        }

        private void cmdNovo(object sender, EventArgs e)
        {
            //procedimento para incluir novo registro
        }
    }
}
