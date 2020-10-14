using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoTeste.DTOs
{
    public class ContratoDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int QtdeParcelas { get; set; }
        public decimal VlrFinanciado { get; set; }
        public ICollection<PrestacaoDTO> Prestacao { get; set; }
    }
}
