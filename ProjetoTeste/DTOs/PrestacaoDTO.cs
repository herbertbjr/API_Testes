using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTeste.Models;

namespace ProjetoTeste.DTOs
{
    public class PrestacaoDTO
    {
        public int ContratoId { get; set; }

        public DateTime DtVencimento { get; set; }

        public DateTime? DtPagamento { get; set; }

        public Decimal Valor { get; set; }
    }
}
