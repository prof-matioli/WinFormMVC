using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BD
{
    public partial class frmCliente : Form
    {
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
                    SqlDataReader sdr = cmd.ExecuteReader();
                    lstClientes.Items.Clear();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["nome"] + " | " + sdr["cpf_cnpj"] + "\n");
                        lstClientes.Items.Add(sdr["nome"]);
                    }
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

        }
    }
}
