using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BD
{
    public partial class frmProduto : Form
    {
        DataSet dsProduto;
        public frmProduto()
        {
            InitializeComponent();
            carregaGridProduto();
        }

        private void carregaGridProduto()
        {
            String sqlSelect = "select * from Produto";
            try
            {
                //Lê a string de conexão do arquivo de configuração da aplicação, App.config
                String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open(); // tenta abrir a conexão
                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dsProduto = new DataSet();
                    da.Fill(dsProduto, "Produto");
                    DataTable dtProduto = dsProduto.Tables["Produto"];

                    grdProdutos.DataSource = dtProduto;
                    grdProdutos.Refresh();
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
