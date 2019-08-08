using System;
using System.Collections.Generic;

namespace Avaliacao09_08_.Entidades
{
    class Pedido
    {
        public int Nota { get; set; }
        public DateTime Date { get;set; }
        public Cliente cliente { get; set; }
        public List<Produto> Compras = new List<Produto>();
        public double ValorTotal { get; set; }
        public void NovoPedido(List<Produto> produtos, List<Cliente> clientes, List<Pedido> pedidos)
        {
            int NO = 0;
            //Data do pedido 
            Date = DateTime.Now;
            //ID 
            Nota = pedidos.Count+1;
            //caso o cliente seja digitado errado
            while (cliente == null)
            {
                //lista de clientes cadastrado
                Print(clientes);
                Console.WriteLine("Digite o numero do ID do cliente");
                Int32.TryParse(Console.ReadLine(), out NO);
                cliente = clientes.Find(x => x.ID == NO);
            }
            string s = "S";
            //Listar produto para compra
            while (s != "N")
            {
                Console.ResetColor();
                Print(produtos);
                Console.WriteLine("Digite o ID do produto");
                Int32.TryParse(Console.ReadLine(), out int PE);
                var temp = produtos.Find(x => x.ID == PE);
                if (temp != null)
                {
                    temp.Quantidades = 0;
                    while (temp.Quantidades <= 0)
                    {
                        Console.WriteLine("Digite a Quantidade");
                        Int32.TryParse(Console.ReadLine(), out PE);
                        temp.Quantidades = PE;
                    }
                    Compras.Add(temp);
                    Console.WriteLine("Deseja comprar mais?(S/N)");
                    s = Console.ReadLine().ToUpper();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Digite ID Valido");
                }
            }
            ValorTotal=ValorTotalDoPedido();
            Console.WriteLine(ToString());
        }
        public override string ToString() => $"\nID: {Nota}\nNome do Cliente:{cliente.Nome}\nValor Total:{ValorTotal.ToString("F2")}\nData:{Date.ToString("dd/MM/yyyy HH:mm:ss")}\nProdutos Comprados {Lista()}";
        //Calculo do valor total
        public double ValorTotalDoPedido()
        {
            //Soma todos os produtos da lista de compra
            foreach (var v in Compras){ ValorTotal += v.ValorTotal();}
            if (ValorTotal > 300) return ValorTotal - (ValorTotal * 0.10);
            if (ValorTotal > 100) return ValorTotal - (ValorTotal * 0.05);
            return ValorTotal;
        }
        public string Lista()
        {
            string G = "";
            foreach (var v in Compras){ G += $"\nProduto:{v.Nome} Quantidade:{v.Quantidades} Valor:{v.Valor.ToString("F2")}"; }
            return G;
        }
        public void Print<T>(List<T> ts)
        {
            foreach (var v in ts)
            {
                Console.WriteLine(v.ToString());
            }
        }
    }
}
