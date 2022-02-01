using System;
using System.Collections.Generic;
using System.Linq;

namespace events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("CPF: ");
            var cpf = Console.ReadLine();

            var client = new Client();

            client.AddClient += delegate (object sender, ClientEventArgs e)
            {
                Console.WriteLine($"Cliente cadastrado com sucesso! Cliente: {e.Name}");
            };
            client.RemoveClient += delegate (object sender, ClientEventArgs e)
            {
                Console.WriteLine($"Cliente removido com sucesso. CPF: {e.CPF}");
            };
            client.Failure += delegate (object sender, EventArgs e)
            {
                Console.WriteLine("ERROR :( ");
            };
            client.Success += delegate (object sender, EventArgs e)
            {
                Console.WriteLine("SUCESSO!");
            };

            client.AdicionarCliente(name, email, cpf);

            client.RemoverCliente(cpf);
        }
    }
}
