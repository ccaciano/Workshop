using System;
using System.Collections.Generic;
using WorkshopGrilo.Enum;

namespace WorkshopGrilo
{
    internal class Conta
    {
        public TipoConta TipoConta { get; private set; }
        public int Agencia { get; private set; }
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; }
        public Banco Banco { get; private set; }

        public List<Transacoes> Transacoes { get; private set; }

        public Conta(TipoConta tipoConta, int agencia, int numero, Banco banco)
        {
            TipoConta = tipoConta;
            Agencia = agencia;
            Numero = numero;
            Saldo = 0;
            Banco = banco;
            Transacoes = new List<Transacoes>();
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("Valor deve ser maior que Zero");

            if (valor > Saldo)
                throw new Exception("Valor em conta insuficiente para realizar saque!");

            Debitar("Saque", valor);
            Console.WriteLine("Saque realizado com sucesso!");
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("Valor deve ser maior que Zero.");

            Creditar("Deposito", valor);
            Console.WriteLine("Deposito realizado com sucesso!");
        }

        public void Transferir(int agencia, int numero, decimal valor)
        {
            if (valor <= 0)
                throw new Exception("Valor deve ser maior que Zero");

            if (valor > Saldo)
                throw new Exception("Valor em conta insuficiente para realizar transferência!");

            var ContaDestino = Banco.ObterConta(agencia, numero);

            ContaDestino.Creditar("Tranferência", valor);
            Debitar("Transferência", valor);
            Console.WriteLine("Transferência realizada com sucesso!");
        }

        public void ExibirExtrato()
        {
            if(Transacoes.Count > 0)
            {
                foreach (var transacao in Transacoes)
                {
                    var cor = transacao.TipoTransacao == TipoTransacao.Credito ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.ForegroundColor = cor;
                    var desc = transacao.Descricao.PadRight(20, '-') + transacao.Valor.ToString("C");
                    Console.WriteLine(desc);
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(string.Empty);

                var SaldoDescricao = "Saldo".PadRight(20, '-') + Saldo.ToString("C");
                Console.WriteLine(SaldoDescricao);
                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Empty);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private void Creditar(string descricao, decimal valor)
        {
            var transacao = new Transacoes(TipoTransacao.Credito, descricao, valor, DateTime.Now);
            Transacoes.Add(transacao);
            Saldo += valor;
        }

        private void Debitar(string descricao, decimal valor)
        {
            var transacao = new Transacoes(TipoTransacao.Debito, descricao, valor, DateTime.Now);
            Transacoes.Add(transacao);
            Saldo -= valor;
        }
    }
}