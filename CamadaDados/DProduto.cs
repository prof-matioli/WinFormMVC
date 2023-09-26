using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dados
{
    public class DProduto
    {
        private int _idProduto;
        private string _nome;
        private string _descricao;
        private float _estoque;
        private decimal _preco;
        private string _unidade;

        public DProduto()
        {
        }

        public DProduto(int idProduto, string nome, string descricao, float estoque, decimal preco, string unidade)
        {
            _idProduto = idProduto;
            Nome = nome;
            Descricao = descricao;
            Estoque = estoque;
            Preco = preco;
            Unidade = unidade;
        }

        public string Nome { get => _nome; set => _nome = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public float Estoque { get => _estoque; set => _estoque = value; }
        public decimal Preco { get => _preco; set => _preco = value; }
        public string Unidade { get => _unidade; set => _unidade = value; }

        public override bool Equals(object obj)
        {
            return obj is DProduto produto &&
                   _idProduto == produto._idProduto &&
                   _nome == produto._nome &&
                   _descricao == produto._descricao &&
                   _estoque == produto._estoque &&
                   _preco == produto._preco &&
                   _unidade == produto._unidade &&
                   Nome == produto.Nome &&
                   Descricao == produto.Descricao &&
                   Estoque == produto.Estoque &&
                   Preco == produto.Preco &&
                   Unidade == produto.Unidade;
        }

        public override int GetHashCode()
        {
            int hashCode = -1714732673;
            hashCode = hashCode * -1521134295 + _idProduto.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_descricao);
            hashCode = hashCode * -1521134295 + _estoque.GetHashCode();
            hashCode = hashCode * -1521134295 + _preco.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_unidade);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Descricao);
            hashCode = hashCode * -1521134295 + Estoque.GetHashCode();
            hashCode = hashCode * -1521134295 + Preco.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Unidade);
            return hashCode;
        }

        //método inserir
        public string Inserir(DProduto produto)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //codigo de inserção
                String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

                SqlCon.ConnectionString = conString;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spInserirProduto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProduto = new SqlParameter();
                ParIdProduto.ParameterName = "@idProduto";
                ParIdProduto.SqlDbType = SqlDbType.Int;
                ParIdProduto.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdProduto);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = produto.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 255;
                ParDescricao.Value = produto.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                SqlParameter ParEstoque = new SqlParameter();
                ParEstoque.ParameterName = "@estoque";
                ParEstoque.SqlDbType = SqlDbType.Float;
                ParEstoque.Value = produto.Estoque;
                SqlCmd.Parameters.Add(ParEstoque);

                SqlParameter ParPreco = new SqlParameter();
                ParPreco.ParameterName = "@preco";
                ParPreco.SqlDbType = SqlDbType.Decimal;
                ParPreco.Value = produto.Preco;
                SqlCmd.Parameters.Add(ParPreco);

                SqlParameter ParUnidade = new SqlParameter();
                ParUnidade.ParameterName = "@unidade_medida";
                ParUnidade.SqlDbType = SqlDbType.VarChar;
                ParUnidade.Size = 10;
                ParUnidade.Value = produto.Preco;
                SqlCmd.Parameters.Add(ParUnidade);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi inserido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return resp;
        }

    }
}
