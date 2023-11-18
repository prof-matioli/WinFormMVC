using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DCliente
    {
        private int _idCliente;
        private string _nome;
        private string _doc;

        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Doc { get => _doc; set => _doc = value; }

        public DCliente()
        {
        }

        public DCliente(int idCliente, string nome, string doc)
        {
            IdCliente = idCliente;
            Nome = nome;
            Doc = doc;
        }

        public override bool Equals(object obj)
        {
            return obj is DCliente cliente &&
                   _idCliente == cliente._idCliente &&
                   _nome == cliente._nome &&
                   _doc == cliente._doc;
        }

        public override int GetHashCode()
        {
            int hashCode = -1345816598;
            hashCode = hashCode * -1521134295 + _idCliente.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_doc);
            return hashCode;
        }

        //método inserir
        public string Inserir(DCliente cliente)
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
                    CommandText = "INSERT INTO Cliente (nome, cpf_cnpj) VALUES (@pNome, @pDoc) ",
                    CommandType = CommandType.Text
                };
                SqlCmd.Parameters.AddWithValue("pNome", cliente.Nome);
                SqlCmd.Parameters.AddWithValue("pDoc", cliente.Doc);

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

        public string Editar(DCliente cliente)
        {
            string resp = "";
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();

                string updateSql = String.Format("UPDATE Cliente SET " +
                                    "Nome = @pNome, cpf_cnpj = @pDoc " +
                                    "WHERE idCliente = @pId ");
                SqlCommand SqlCmd = new SqlCommand(updateSql, Connection.SqlCon);
                SqlCmd.Parameters.AddWithValue("pNome", cliente.Nome);
                SqlCmd.Parameters.AddWithValue("pDoc", cliente.Doc);
                SqlCmd.Parameters.AddWithValue("pId", cliente.IdCliente);

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
        public string Excluir(DCliente cliente)
        {
            string resp = "";
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();


                string deleteSql = String.Format("DELETE FROM Cliente WHERE idCliente = @ID ");
                SqlCommand SqlCmd = new SqlCommand(deleteSql, Connection.SqlCon);
                SqlCmd.Parameters.Add(new SqlParameter("ID", cliente.IdCliente));

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
            DataTable DtResultado = new DataTable("cliente");
            try
            {
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();
                String sqlSelect = "select * from Cliente";

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = sqlSelect;
                SqlCmd.CommandType = CommandType.Text;
                SqlDataAdapter SqlData = new SqlDataAdapter(SqlCmd);
                SqlData.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //método BuscarNome
        public DataTable BuscarNome(DCliente cliente)
        {
            DataTable dsResultado = new DataTable("cliente");
            try
            {
                //codigo de inserção
                if (Connection.SqlCon.State == ConnectionState.Closed)
                    Connection.SqlCon.Open();


                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Connection.SqlCon;
                SqlCmd.CommandText = "SELECT * FROM cliente WHERE nome LIKE '%@pNome%'";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNomeCliente = new SqlParameter();
                ParNomeCliente.ParameterName = "@pNome";
                ParNomeCliente.SqlDbType = SqlDbType.VarChar;
                ParNomeCliente.Value = cliente.Nome;
                SqlCmd.Parameters.Add(ParNomeCliente);

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


    }
}
