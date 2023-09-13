using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public partial class frmProdutosMySql : Form
    {
        DataSet dsProduto;
        public frmProdutosMySql()
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
                String conString = ConfigurationManager.ConnectionStrings["connectionStringMysql"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open(); // tenta abrir a conexão
                    MySqlCommand cmd = new MySqlCommand(sqlSelect, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    dsProduto = new DataSet();
                    da.Fill(dsProduto, "Produto");
                    DataTable dtProduto = dsProduto.Tables["Produto"];

                    grdProdutosMySql.DataSource = dtProduto;
                    grdProdutosMySql.Refresh();
                }
            }
            catch (MySqlException ex)
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
