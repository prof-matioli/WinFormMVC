using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdTestaConexao(object sender, EventArgs e)
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

        private void cmdSelect(object sender, EventArgs e)
        {
            try
            {
                String conString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                AttachDbFilename=|DataDirectory|\APP_DATA\Database.mdf; 
                                Integrated Security=True";
                String sqlSelect = "select * from Cliente";

                SqlConnection con = new SqlConnection(conString);
                con.Open(); // tenta abrir a conexão
                SqlCommand cmd = new SqlCommand(sqlSelect, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                lstClientes.Items.Clear();
                while(sdr.Read())
                {
                    Console.WriteLine(sdr["nome"] + " | " + sdr["cpf_cnpj"] + "\n");
                    lstClientes.Items.Add(sdr["nome"]);
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
    }
}
