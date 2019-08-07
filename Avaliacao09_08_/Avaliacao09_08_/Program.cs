using System;
using System.Collections.Generic;
using System.IO;
using Avaliacao09_08_.Entidades;
using Avaliacao09_08_.Service;
using Newtonsoft.Json;

namespace Avaliacao09_08_
{
    class Program
    {
        static void Main(string[] args)
        {   List<Produto> produtos = new List<Produto>();
            List<Cliente> clientes = new List<Cliente>();
            List<Pedido> pedidos = new List<Pedido>();
            #region Leitura de Arquivo 
            try
            {
                string path = @"C:\JSON\Produtos.json";
                produtos = JsonConvert.DeserializeObject<List<Produto>>(File.ReadAllText(path));
            }
            catch (Exception) { }
            try
            {
                string path3 = @"C:\JSON\Pedidos.json";
                pedidos = JsonConvert.DeserializeObject<List<Pedido>>(File.ReadAllText(path3));
            }
            catch (Exception) { }
            try
            {
                string path2 = @"C:\JSON\Clientes.json";
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText(path2));
            }
            catch (Exception) { }

            #endregion
            Show show = new Show();
            show.ShowTela(produtos, clientes, pedidos);
        }
    }
}
