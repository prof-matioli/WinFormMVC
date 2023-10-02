using Dados;
using System.Data;

namespace Negocio
{
    public class NProduto
    {
        //Método Inserir
        public static string Inserir(string nome, string descricao, float estoque, decimal preco, string unidade)
        {
            DProduto obj = new DProduto();
            obj.Nome = nome;
            obj.Descricao = descricao;
            obj.Estoque = estoque;
            obj.Preco = preco;
            obj.Unidade = unidade;
            return obj.Inserir(obj);
        }

        public static string Editar(int idCategoria, string nome, string descricao, float estoque, decimal preco, string unidade)
        {
            DProduto obj = new Dados.DProduto();
            obj.IdProduto = idCategoria;
            obj.Nome = nome;
            obj.Descricao = descricao;
            obj.Estoque = estoque;
            obj.Preco = preco;
            obj.Unidade = unidade;
            return obj.Editar(obj);
        }

        //Método mostrar
        public static DataTable Mostrar()
        {
            DProduto dProd = new DProduto();
            DataTable dT = dProd.Mostrar();
            return dT;
        }

        //Método Deletar
        public static string Excluir(int idProduto)
        {
            DProduto obj = new Dados.DProduto();
            obj.IdProduto = idProduto;
            return obj.Excluir(obj);
        }

        //Método buscar
        public static DataTable BuscarNome(string textobuscar)
        {
            DProduto obj = new DProduto();
            obj.Nome = textobuscar;
            return obj.BuscarNome(obj);
        }


    }
}
