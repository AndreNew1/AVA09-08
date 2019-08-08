using System;
using System.Collections.Generic;
using Avaliacao09_08_.Entidades;
using System.IO;
using Newtonsoft.Json;

namespace Avaliacao09_08_.Service
{
    class Show
    {
        #region TELA
        public void ShowTela(List<Produto> produtos, List<Cliente> clientes, List<Pedido> pedidos)
        {
            while (true)
            {
                Console.WriteLine("\nDigite 1 para Cadastrar Cliente\nDigite 2 para Cadastrar Produto\nDigite 3 Registrar um Novo Pedido" +
                                "\nDigite 4 para ver todos clientes\nDigite 5 para ver todos os Produtos\nDigite 6 para ver todos os pedidos");
                string g = Console.ReadLine();
                switch (g)
                {
                    case "1":
                        {
                           Cliente ele = new Cliente();
                           ele.Cadastro(clientes);
                           clientes.Add(ele);
                           ArqC(clientes);
                           break;
                        }
                    case "2":
                        {
                           Produto produto = new Produto();
                           produto.Cadastro(produtos);
                           produtos.Add(produto);
                           ArqPro(produtos);
                           break;
                        }
                    case "3":
                        {
                            Pedido ped = new Pedido();
                            ped.NovoPedido(produtos,clientes,pedidos);
                            pedidos.Add(ped);
                            ArqPed(pedidos);
                            break;
                        }
                    case "4": Print(clientes); break; 
                    case "5": Print(produtos); break; 
                    case "6": Print(pedidos); break; 
                }
            }
        }
        #endregion
        #region Arquivos e Escrita de lista
        //Escrita do Arquivo Produtos
        private void ArqPro(List<Produto> produtos)
        {
            string path = @"C:\JSON\Produtos.json";
            string G = JsonConvert.SerializeObject(produtos,Formatting.Indented);
            using (StreamWriter a = File.CreateText(path)) { a.Write(G); }
        }
        //Escrita do Arquivo Pedidos
        private void ArqPed(List<Pedido> pedidos)
        {
            string path3 = @"C:\JSON\Pedidos.json";
            string G = JsonConvert.SerializeObject(pedidos,Formatting.Indented);
            using (StreamWriter a = File.CreateText(path3)) { a.Write(G); }
        }
        //Escrita do Arquivo Cliente
        private void ArqC(List<Cliente> clientes)
        {
            string path2 = @"C:\JSON\Clientes.json";
            string G = JsonConvert.SerializeObject(clientes,Formatting.Indented);
            using (StreamWriter a = File.CreateText(path2)) { a.Write(G); }

        }
        //Metodo para Escrever as listas
        public void Print<T>(List<T> ts)
        {
            foreach(var v in ts)
            {
                Console.WriteLine(v.ToString());
            }
        }
        #endregion
    }
}
