using Model;
using System.Data;

namespace Controller
{
    public class NCliente
    {
        //Método Inserir
        public static string Inserir(string nome, string cpf_cnpj)
        {
            DCliente obj = new DCliente();
            obj.Nome = nome;
            obj.Doc = cpf_cnpj;
            return obj.Inserir(obj);
        }

        public static string Editar(int idCliente, string nome, string doc)
        {
            DCliente obj = new DCliente();
            obj.IdCliente = idCliente;
            obj.Nome = nome;
            obj.Doc = doc;
            return obj.Editar(obj);
        }

        //Método mostrar
        public static DataTable Mostrar()
        {
            DCliente dCli = new DCliente();
            DataTable dT = dCli.Mostrar();
            return dT;
        }

        //Método Deletar
        public static string Excluir(int idCliente)
        {
            DCliente obj = new DCliente();
            obj.IdCliente = idCliente;
            return obj.Excluir(obj);
        }

        //Método buscar
        public static DataTable BuscarNome(string textobuscar)
        {
            DCliente obj = new DCliente();
            obj.Nome = textobuscar;
            return obj.BuscarNome(obj);
        }


    }
}
