using System;
using System.Collections.Generic;

namespace Avaliacao09_08_.Entidades
{
    class Cliente
    {
        public int ID { get; set;} 
        public string Nome { get; set; }

        public virtual void Cadastro<T>(List<T> clientes)
        {
            Console.WriteLine($"Digite o Nome do {GetType().Name}");
            Nome = Console.ReadLine().ToUpper();
            //Auto Incremeta o ID
            ID = clientes.Count + 1;
        }
        public override string ToString() => $"ID: {ID}, Nome:{Nome}";
    }
}
