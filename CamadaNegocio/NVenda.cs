using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class NVenda
    {
        //Método Inserir
        public static string Inserir(int idcliente, int idproduto, DateTime data, int qtd, float vlrTotal)
        {
            DVenda obj = new DVenda();
            obj.Idcliente = idcliente;
            obj.Idproduto = idproduto;
            obj.Data = data;
            obj.Quantidade = qtd;
            obj.ValorTotal = vlrTotal;
            return obj.Inserir(obj);
        }

        public static string Editar(int idVenda, int idcliente, int idproduto, DateTime data, int qtd, float vlrTotal)
        {
            DVenda obj = new Dados.DVenda();
            obj.Idcliente = idcliente;
            obj.Idproduto = idproduto;
            obj.Data = data;
            obj.Quantidade = qtd;
            obj.ValorTotal = vlrTotal;
            return obj.Editar(obj);
        }

        //Método mostrar
        public static DataTable Mostrar()
        {
            DVenda dvenda = new DVenda();
            DataTable dT = dvenda.Mostrar();
            return dT;
        }

        //Método Deletar
        public static string Excluir(int idVenda)
        {
            DVenda obj = new Dados.DVenda();
            obj.Idvenda = idVenda;
            return obj.Excluir(obj);
        }


    }
}
