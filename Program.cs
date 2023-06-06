using System;
using ProjetoMVCEvento.Controller;

namespace CadastroEventos
{
    class Program
    {
        static void Main(string[] args)
        {
            EventoController controller = new EventoController();

            while (true)
            {
                Console.WriteLine("=== Menu ===");
                Console.WriteLine("1. Cadastrar Evento");
                Console.WriteLine("2. Listar Eventos");
                Console.WriteLine("3. Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        controller.CadastrarEvento();
                        break;
                    case "2":
                        controller.ListarEventos();
                        break;
                    case "3":
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
