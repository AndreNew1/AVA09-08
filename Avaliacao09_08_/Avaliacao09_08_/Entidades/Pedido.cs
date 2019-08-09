using System;
using System.Collections.Generic;

namespace Avaliacao09_08_.Entidades
{
    class Pedido
    {
        public int Nota { get; set; }
        public DateTime Date { get; set; }
        public Cliente cliente { get; set; }
        public List<Produto> Compras = new List<Produto>();
        public double ValorTotal { get; set; }
        //Registro do pedido
        public void NovoPedido(List<Produto> produtos, List<Cliente> clientes, List<Pedido> pedidos)
        {
            int NO = 0;
            //Data do pedido 
            Date = DateTime.Now;
            //ID 
            Nota = pedidos.Count + 1;
            //lista de clientes cadastrado
            Tratar("Digite o ID do cliente", NO, clientes);
            cliente = clientes.Find(x => x.ID == NO);
            string s = "S";
            //Listar produto para compra
            while (s != "N")
            {
                Console.ResetColor();
                Tratar("Digite o ID do produto", NO, produtos);
                var temp = produtos.Find(x => x.ID == NO);
                do
                {
                    Console.WriteLine("Digite a Quantidade");
                    Int32.TryParse(Console.ReadLine(), out NO);
                } while (NO <= 0);
                temp.Quantidades = NO;
                Compras.Add(temp);
                Console.WriteLine("Deseja comprar mais?(S/N)");
                s = Console.ReadLine().ToUpper();
                Console.Clear();
            }
            ValorTotal = ValorTotalDoPedido();
            Console.WriteLine(ToString());
        }
        public override string ToString() => $"\nID: {Nota}\nNome do Cliente: {cliente.Nome}\nValor Total: {ValorTotal.ToString("F2")}\nData: {Date.ToString("dd/MM/yyyy HH:mm:ss")}\nProdutos Comprados {Lista()}";
        #region Metodos
        //Calculo do valor total
        public double ValorTotalDoPedido()
        {
            //Soma todos os produtos da lista de compra
            foreach (var v in Compras) { ValorTotal += v.ValorTotal(); }
            if (ValorTotal > 300) return ValorTotal - (ValorTotal * 0.10);
            if (ValorTotal > 100) return ValorTotal - (ValorTotal * 0.05);
            return ValorTotal;
        }
        //Impressão dos produtos
        public string Lista()
        {
            string G = "";
            foreach (var v in Compras) { G += $"\nProduto:{v.Nome} Quantidade:{v.Quantidades} Valor:{v.Valor.ToString("F2")}"; }
            return G;
        }
        //tratamento dos numeros
        public void Tratar<T>(string M, int G, List<T> ts)
        {
            while (G <= 0||G>ts.Count)
            {
                Print(ts);
                Console.WriteLine(M);
                Int32.TryParse(Console.ReadLine(), out int N);
                G = N;
                Console.Clear();
                if (G <= 0 || G > ts.Count) Console.WriteLine("ID Invalido");
            }
        }
        //Impressão
        public void Print<T>(List<T> ts)
        {
            foreach (var v in ts)
            {
                Console.WriteLine(v.ToString());
            }
        }
        #endregion
    }
}
