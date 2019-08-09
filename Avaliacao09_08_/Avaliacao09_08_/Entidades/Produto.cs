using System;
using System.Collections.Generic;

namespace Avaliacao09_08_.Entidades
{
    class Produto:Cliente
    {
        public double Valor { get; set; }
        public int Quantidades { get; set; }
        //cadastro produto
        public override void Cadastro<T>(List<T> Produtos)
        {
            //reutilização do codigo em cliente
            base.Cadastro(Produtos);
            double NO=0;
            while (NO <= 0)
            {
              Console.WriteLine("Digite o Valor do Produto  EX:50,50");
              Double.TryParse(Console.ReadLine(), out NO);
            }
            Valor = NO;
        }
        public override string ToString() => $"ID: {ID}, Nome: {Nome}, Valor: {Valor.ToString("F2")}";
        //Calculo do produto
        public double ValorTotal()=> Valor * Quantidades;
        
    }
}
