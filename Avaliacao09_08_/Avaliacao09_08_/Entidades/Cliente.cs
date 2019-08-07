using System;
using System.Collections.Generic;

namespace Avaliacao09_08_.Entidades
{
    class Cliente
    {
        public int ID { get; set;} 
        public string Nome { get; set; }

        public void Cadastro(List<Cliente> clientes)
        {
            Console.WriteLine("Digite o Nome do cliente");
            Nome = Console.ReadLine().ToUpper();
            //Auto Incremeta o ID
            ID = clientes.Count + 1;
            if (clientes.Find(x => x.Nome == Nome) != null)
            {
                Console.WriteLine("O Cliente ja existe");
                Cadastro(clientes);
            }
        }
        public override string ToString() => $"ID: {ID}, Nome:{Nome}";
    }
}
