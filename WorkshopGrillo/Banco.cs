using System;
using System.Collections.Generic;
using System.Linq;
using WorkshopGrilo.Enum;

namespace WorkshopGrilo
{
    internal  class Banco
    {
        public string Nome { get; private set; }
        public int Numero { get; private set; }
        //public Endereco Endereco { get; private set; }
        //public TipoTransacao TipoTransacao { get; private set; }
        public List<Conta> Contas { get; private set; }
        public Banco()
        {
            Contas = new List<Conta>();
        }
        public Conta AbrirConta(Cliente Cliente)
        {
            if(!Cliente.DiMaior())
                throw new Exception("Cliente tem deve ser maior de idade!");

            var NumeroConta = Contas.Count + 1;
            var conta = new Conta(TipoConta.Corrente, 1, 0, this);
            Contas.Add(conta);
            return conta;
        }

        public void FecharConta(Conta conta)
        {
            Contas.Remove(conta);
        }

        public Conta ObterConta(int agencia, int numero)
        {
            var conta = Contas.FirstOrDefault<Conta>(c => c.Agencia == agencia && c.Numero == Numero);

            if (conta == null)
                throw new Exception("Conta não encontrada!");

            return conta;
        }

    }
}
