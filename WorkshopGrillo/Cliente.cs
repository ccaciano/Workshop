using System;

namespace WorkshopGrilo
{
    internal class Cliente
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DtNasc { get; private set; }
        public Endereco Endereco { get; private set; }

        public Cliente(string nome, string cpf, DateTime dtNasc, Endereco endereco)
        {
            Nome = nome;
            CPF = cpf;
            DtNasc = dtNasc;
            Endereco = endereco;
        }

        public bool DiMaior()
        {
            var VirificaAno = DateTime.Now.AddYears(-18);
            var diMaior = (DtNasc <= VirificaAno);

            return diMaior;
        }
    }
}