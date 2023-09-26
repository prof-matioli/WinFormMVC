using Dados;

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


    }
}
