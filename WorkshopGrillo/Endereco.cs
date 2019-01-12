using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopGrilo
{
    internal class Endereco
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public short Numero { get; private set; }
        public Cidade Cidade { get; private set; }

        public Endereco(string logradouro, string bairro, string cep, short numero, Cidade cidade)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            CEP = cep;
            Numero = numero;
            Cidade = cidade;
        }
    }
}
