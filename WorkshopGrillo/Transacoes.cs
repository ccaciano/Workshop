using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopGrilo.Enum;

namespace WorkshopGrilo
{
     internal class Transacoes
     {
        public TipoTransacao TipoTransacao { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DtHora { get; private set; }

        public Transacoes(TipoTransacao tipoTransacao, string descricao, decimal valor, DateTime dtHora)
        {
            TipoTransacao = tipoTransacao;
            Descricao = descricao;
            Valor = valor;
            DtHora = dtHora;
        }
     }
}
