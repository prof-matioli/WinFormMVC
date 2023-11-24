using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
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
            DVenda obj = new DVenda();
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

        //Método mostrar completo
        //Mostra dasdos relacionados, como Nome do Cliente e Nome do Produto
        public static DataTable MostrarCompleta()
        {
            DVenda dvenda = new DVenda();
            DataTable dT = dvenda.MostrarCompleta();
            return dT;
        }

        //Método Deletar
        public static string Excluir(int idVenda)
        {
            DVenda obj = new DVenda();
            obj.Idvenda = idVenda;
            return obj.Excluir(obj);
        }


    }
}
