using System;
using System.Collections.Generic;
using Avaliacao09_08_.Entidades;
using System.IO;
using Newtonsoft.Json;

namespace Avaliacao09_08_.Service
{
    class Show
    {
        List<Produto> Produtos = new List<Produto>();
        List<Cliente> Clientes = new List<Cliente>();
        List<Pedido> Pedidos = new List<Pedido>();
        readonly string path = @"C:\JSON\Produtos.json";
        readonly string path3 = @"C:\JSON\Pedidos.json";
        readonly string path2 = @"C:\JSON\Clientes.json";
        #region TELA
        public void ShowTela()
        {
            Produtos.AddRange(Ler(Produtos, path));
            Pedidos.AddRange(Ler(Pedidos, path3));
            Clientes.AddRange(Ler(Clientes, path2));
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nDigite 1 para Cadastrar Cliente\nDigite 2 para Cadastrar Produto\nDigite 3 Registrar um Novo Pedido" +
                                "\nDigite 4 para ver todos clientes\nDigite 5 para ver todos os Produtos\nDigite 6 para ver todos os pedidos");
                string g = Console.ReadLine();
                switch (g)
                {
                    case "1":
                        {
                           Cliente ele = new Cliente();
                           ele.Cadastro(Clientes);
                           Clientes.Add(ele);
                           Arq(Clientes,path2);
                           break;
                        }
                    case "2":
                        {
                           Produto produto = new Produto();
                           produto.Cadastro(Produtos);
                           Produtos.Add(produto);
                           Arq(Produtos,path);
                           break;
                        }
                    case "3":
                        {
                            Pedido ped = new Pedido();
                            ped.NovoPedido(Produtos,Clientes,Pedidos);
                            Pedidos.Add(ped);
                            Arq(Pedidos,path3);
                            break;
                        }
                    case "4": Print(Clientes); break; 
                    case "5": Print(Produtos); break; 
                    case "6": Print(Pedidos); break; 
                }
            }
        }
        #endregion
        #region Arquivos e Escrita de lista
        //Escrita do Arquivo e Leitura
        public List<T> Ler<T>(List<T> ts, string Path)
        {
            try
            {
                ts = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(Path));
            }
            catch (Exception) { }
            return ts;
        }
        private void Arq<T>(List<T> ts,string path)
        {
            
            string G = JsonConvert.SerializeObject(ts,Formatting.Indented);
            using (StreamWriter a = File.CreateText(path)) { a.Write(G); }
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
