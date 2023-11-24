using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class frmVenda : Form
    {
        private int modo = 0; // 0=netro; 1=inclusao; 2=alteração; 3=exclusão

        public frmVenda()
        {
            InitializeComponent();

        }

        private void LoadData()
        {
            dgVendas.DataSource = NVenda.MostrarCompleta();
            modo = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            NVenda.Inserir(3, 2, DateTime.Now.Date, 5, 25);            
        }

        private void frmVenda_Load(object sender, EventArgs e)
        {
            LoadData();
            dgVendas.Columns[0].HeaderText = "ID";
            dgVendas.Columns[0].DataPropertyName = "id";
            dgVendas.Columns[1].HeaderText = "DATA";
            dgVendas.Columns[1].DataPropertyName = "data";
            dgVendas.Columns[2].HeaderText = "ID CLIENTE";
            dgVendas.Columns[2].DataPropertyName = "idcliente";
            dgVendas.Columns[3].HeaderText = "NOME CLIENTE";
            dgVendas.Columns[3].Width = 150;
            dgVendas.Columns[3].DataPropertyName = "nomecliente";
            dgVendas.Columns[4].HeaderText = "ID PRODUTO";
            dgVendas.Columns[4].DataPropertyName = "idproduto";
            dgVendas.Columns[4].Width = 150;
            dgVendas.Columns[5].HeaderText = "NOME PRODUTO";
            dgVendas.Columns[5].DataPropertyName = "nomeproduto";
            dgVendas.Columns[6].HeaderText = "QTDE";
            dgVendas.Columns[6].DataPropertyName = "quantidade";
            dgVendas.Columns[7].HeaderText = "VALOR";
            dgVendas.Columns[7].DataPropertyName = "valorTotal";
        }
    }
}
