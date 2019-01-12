using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopGrilo
{
    internal class Program
    {
        private static readonly Banco banco = new Banco();
        private static readonly Conta contaDestino;

        static Program()
        {
            var cidade = new Cidade("Jundiaí", "SP");
            var endereco = new Endereco("Rua Jundiaí", "Centro", "12345000", 10, cidade);
            var cliente = new Cliente("Carlile", "12345678900", new DateTime(1994, 3, 31), endereco);
            contaDestino = banco.AbrirConta(cliente);
        }

        private static void Main(string[] args)
        {
            try
            {
                var cidade = new Cidade("Itupeva", "SP");
                var endereco = new Endereco("Avenida Brasil", "Centro", "13295000", 5, cidade);
                var cliente = new Cliente("Caleo", "12345678900", new DateTime(1991, 7, 23), endereco);
                var contaCaleo = banco.AbrirConta(cliente);

                contaCaleo.Depositar(1800);
                contaCaleo.Sacar(620);
                contaCaleo.ExibirExtrato();
                
                contaCaleo.Transferir(1, 1, 200);
                contaCaleo.ExibirExtrato();

                contaDestino.Depositar(150);
                contaDestino.ExibirExtrato();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ResetColor();
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}
