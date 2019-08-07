using System;
using System.Collections.Generic;

namespace Avaliacao09_08_.Entidades
{
    class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidades { get; set; }
        //cadastro produto
        public void PCadastro(List<Produto> Produtos)
        {
            double NO=0;
            Console.WriteLine("Digite o Nome do Produto");
            Nome = Console.ReadLine().ToUpper();
            while (NO <= 0)
            {
                Console.WriteLine("Digite o Valor do Produto  EX:50,50");
                Double.TryParse(Console.ReadLine(), out NO);
            }
            Valor = NO;
            //Auto Incrementar
            ID = Produtos.Count + 1;
        }
        public override string ToString() => "ID: " + ID + "\nNome: " + Nome + "\nValor: " + Valor.ToString();
        //Calculo do produto
        public double ValorTotal()=> Valor * Quantidades;
        
    }
}
