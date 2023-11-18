using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DVenda
    {
        private int _idvenda;
        private int _idcliente;
        private int _idproduto;
        private DateTime _data;
        private int _quantidade;
        private float _valorTotal;

        public DVenda()
        {
        }

        public DVenda(int idcliente, int idproduto, DateTime data, int quantidade, float valorTotal)
        {
            _idcliente = idcliente;
            _idproduto = idproduto;
            _data = data;
            _quantidade = quantidade;
            _valorTotal = valorTotal;
        }

        public int Idvenda { get => _idvenda; set => _idvenda = value; }
        public int Idcliente { get => _idcliente; set => _idcliente = value; }
        public int Idproduto { get => _idproduto; set => _idproduto = value; }
        public DateTime Data { get => _data; set => _data = value; }
        public int Quantidade { get => _quantidade; set => _quantidade = value; }
        public float ValorTotal { get => _valorTotal; set => _valorTotal = value; }

        public override bool Equals(object obj)
        {
            return obj is DVenda venda &&
                   _idvenda == venda._idvenda &&
                   _idcliente == venda._idcliente &&
                   _idproduto == venda._idproduto &&
                   _data == venda._data &&
                   _quantidade == venda._quantidade &&
                   _valorTotal == venda._valorTotal;
        }

        public override int GetHashCode()
        {
            int hashCode = 1921417870;
            hashCode = hashCode * -1521134295 + _idvenda.GetHashCode();
            hashCode = hashCode * -1521134295 + _idcliente.GetHashCode();
            hashCode = hashCode * -1521134295 + _idproduto.GetHashCode();
            hashCode = hashCode * -1521134295 + _data.GetHashCode();
            hashCode = hashCode * -1521134295 + _quantidade.GetHashCode();
            hashCode = hashCode * -1521134295 + _valorTotal.GetHashCode();
            return hashCode;
        }

        //método inserir
        public string Inserir(DVenda venda)
        {
            string resp = "";
            string sqlInsert = "INSERT INTO venda (idcliente,idproduto,data,quantidade,valorTotal) VALUES(@idproduto,@data,@quantidade,@valorTotal) ";
                                
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = Connection.SqlCon,
                    CommandText = sqlInsert,
                    CommandType = CommandType.Text
                };

                SqlParameter ParIdCliente = new SqlParameter
                {
                    ParameterName = "@idcliente",
                    SqlDbType = SqlDbType.Int,
                    Value = venda.Idcliente
                };
                _ = SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdProduto = new SqlParameter
                {
                    ParameterName = "@idproduto",
                    SqlDbType = SqlDbType.Int,
                    Value = venda.Idproduto
                };
                _ = SqlCmd.Parameters.Add(ParIdProduto);

                SqlParameter ParQuantidade = new SqlParameter
                {
                    ParameterName = "@quantidade",
                    SqlDbType = SqlDbType.Float,
                    Value = venda.Quantidade
                };
                _ = SqlCmd.Parameters.Add(ParQuantidade);

                SqlParameter ParValorTotal = new SqlParameter
                {
                    ParameterName = "@valorTotal",
                    SqlDbType = SqlDbType.Float,
                    Value = venda.ValorTotal
                };
                _ = SqlCmd.Parameters.Add(ParValorTotal);

                SqlParameter ParData = new SqlParameter
                {
                    ParameterName = "@data",
                    SqlDbType = SqlDbType.Date,
                    Value = venda.Data
                };
                SqlCmd.Parameters.Add(ParData);

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

        public string Editar(DVenda venda)
        {
            string resp = "";
            string sqlUpdate = "UPDATE venda SET idproduto=@idproduto,idcliente=@idcliente,data=@data,quantidade=@quantidade,valorTotal=@valorTotal WHERE idvenda=@idvenda";

            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();


                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlUpdate;
                SqlCmd.CommandType = CommandType.Text;

                SqlParameter ParIdVenda = new SqlParameter();
                ParIdVenda.ParameterName = "@idvenda";
                ParIdVenda.SqlDbType = SqlDbType.Int;
                ParIdVenda.Value = venda.Idvenda;
                SqlCmd.Parameters.Add(ParIdVenda);

                SqlParameter ParIdProduto = new SqlParameter();
                ParIdProduto.ParameterName = "@idproduto";
                ParIdProduto.SqlDbType = SqlDbType.Int;
                ParIdProduto.Value = venda.Idproduto;
                SqlCmd.Parameters.Add(ParIdProduto);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.VarChar;
                ParIdCliente.Value = venda.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParData = new SqlParameter();
                ParData.ParameterName = "@data";
                ParData.SqlDbType = SqlDbType.Date;
                ParData.Value = venda.Data;
                SqlCmd.Parameters.Add(ParData);

                SqlParameter ParQuantidade = new SqlParameter();
                ParQuantidade.ParameterName = "@quantidade";
                ParQuantidade.SqlDbType = SqlDbType.Float;
                ParQuantidade.Value = venda.Quantidade;
                SqlCmd.Parameters.Add(ParQuantidade);

                SqlParameter ParValorTotal = new SqlParameter();
                ParValorTotal.ParameterName = "@valorTotal";
                ParValorTotal.SqlDbType = SqlDbType.Float;
                ParValorTotal.Value = venda.ValorTotal;
                SqlCmd.Parameters.Add(ParValorTotal);

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
        public string Excluir(DVenda venda)
        {
            string resp = "";
            string sqlDelete = "DELETE FROM venda WHERE idvenda=@idvenda";
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();


                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlDelete;
                SqlCmd.CommandType = CommandType.Text;

                SqlParameter ParIdVenda = new SqlParameter();
                ParIdVenda.ParameterName = "@idvenda";
                ParIdVenda.SqlDbType = SqlDbType.Int;
                ParIdVenda.Value = venda.Idvenda;
                SqlCmd.Parameters.Add(ParIdVenda);

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


        //método Mostrar
        public DataTable Mostrar()
        {
            string sqlSelect = "SELECT * FROM venda";
            DataTable DtResultado = new DataTable("venda");
            try
            {
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
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
