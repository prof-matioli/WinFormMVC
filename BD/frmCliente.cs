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
        public frmCliente()
        {
            InitializeComponent();
        }

/*        private void cmdTestaConexao(object sender, EventArgs e)
        {
            try
            {
                String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                AttachDbFilename=|DataDirectory|\APP_DATA\Database.mdf; 
                                Integrated Security=True";
                SqlConnection con = new SqlConnection(conString);
                con.Open(); // tenta abrir a conexão
                MessageBox.Show("Conexão aberta com sucesso!");
            }catch(SqlException ex)
            {
                MessageBox.Show("Falha ao tentar conectar com o BD!\n"+ex.Message);
            }catch (Exception)
            {
                MessageBox.Show("Falha geral do sistema!");
            }
        }
*/
        private void cmdSelect(object sender, EventArgs e)
        {
/*
                 String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                AttachDbFilename=|DataDirectory|\APP_DATA\Database.mdf; 
                                Integrated Security=True";
*/
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
                    da.Fill(dsCliente,"Cliente");
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
            String nome="";
            Int32 id;
 
            nome = this.lstClientes.GetItemText(this.lstClientes.SelectedItem);
            id = Convert.ToInt32(this.lstClientes.SelectedValue);

            Console.WriteLine("{0} - {1}",id,nome);
        }
    }
}
