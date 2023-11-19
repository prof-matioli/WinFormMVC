using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Model
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
            IdProduto = idProduto;
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
        public int IdProduto { get => _idProduto; set => _idProduto = value; }

        public override bool Equals(object obj)
        {
            return obj is DProduto produto &&
                   IdProduto == produto.IdProduto &&
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
            hashCode = hashCode * -1521134295 + IdProduto.GetHashCode();
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
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = Connection.SqlCon,
                    CommandText = "spInserirProduto",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdProduto = new SqlParameter
                {
                    ParameterName = "@idProduto",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                _ = SqlCmd.Parameters.Add(ParIdProduto);

                SqlParameter ParNome = new SqlParameter
                {
                    ParameterName = "@nome",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = produto.Nome
                };
                _ = SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParDescricao = new SqlParameter
                {
                    ParameterName = "@descricao",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 255,
                    Value = produto.Descricao
                };
                _ = SqlCmd.Parameters.Add(ParDescricao);

                SqlParameter ParEstoque = new SqlParameter
                {
                    ParameterName = "@estoque",
                    SqlDbType = SqlDbType.Float,
                    Value = produto.Estoque
                };
                _ = SqlCmd.Parameters.Add(ParEstoque);

                SqlParameter ParPreco = new SqlParameter
                {
                    ParameterName = "@preco",
                    SqlDbType = SqlDbType.Decimal,
                    Value = produto.Preco
                };
                _ = SqlCmd.Parameters.Add(ParPreco);

                SqlParameter ParUnidade = new SqlParameter
                {
                    ParameterName = "@unidade_medida",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 10,
                    Value = produto.Unidade
                };
                SqlCmd.Parameters.Add(ParUnidade);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }
            return resp;
        }

        public string Editar(DProduto produto)
        {
            string resp = "";
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();


                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = "spAlterarProduto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProduto = new SqlParameter();
                ParIdProduto.ParameterName = "@idProduto";
                ParIdProduto.SqlDbType = SqlDbType.Int;
                ParIdProduto.Value = produto.IdProduto;
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
                ParUnidade.Value = produto.Unidade;
                SqlCmd.Parameters.Add(ParUnidade);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }
            return resp;
        }

        //método excluir
        public string Excluir(DProduto produto)
        {
            string resp = "";
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();


                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = "spExcluirProduto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProduto = new SqlParameter();
                ParIdProduto.ParameterName = "@idProduto";
                ParIdProduto.SqlDbType = SqlDbType.Int;
                ParIdProduto.Value = produto.IdProduto;
                SqlCmd.Parameters.Add(ParIdProduto);

                //executa o stored procedure
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "SUCESSO" : "FALHA";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();
            }
            return resp;
        }

        //método BuscarNome
        public DataTable BuscarNome(DProduto produto)
        {
            DataTable dsResultado = new DataTable("produto");
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();


                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = "spBuscarProdutoPorNome";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNomeProduto = new SqlParameter();
                ParNomeProduto.ParameterName = "@nome";
                ParNomeProduto.SqlDbType = SqlDbType.VarChar;
                ParNomeProduto.Value = produto.Nome;
                SqlCmd.Parameters.Add(ParNomeProduto);

                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(dsResultado);
            }
            catch (Exception)
            {
                dsResultado = null;
            }
            finally
            {
                if (Connection.SqlCon.State == ConnectionState.Open)
                    Connection.SqlCon.Close();

            }
            return dsResultado;
        }


        //método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("produto");
            try
            {
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = "spMostrarProduto";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


    }
}
