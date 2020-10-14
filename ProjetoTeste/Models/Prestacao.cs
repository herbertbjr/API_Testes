using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoTeste.Models
{
    public class Prestacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("ContratoId")]
        public int ContratoId { get; set; }
        public virtual Contrato Contrato { get; set; }
        [Display(Name = "Data de vencimento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Required(ErrorMessage = "Por favor, informe o valor para o campo: Data de vencimento")]
        public DateTime DtVencimento { get; set; }
        [Display(Name = "Data de pagamento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DtPagamento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Por favor, informe o valor para o campo: Valor")]
        [Display(Name = "Valor", Description = "O valor deve ser maior que zero.")]
        [Range(1, Double.MaxValue)]
        public Decimal Valor { get; set; }
        public string Status
        {
            get
            {
                return ChecaStatus(this.DtVencimento, this.DtPagamento);
            }
        }

        public string ChecaStatus(DateTime dtVencimento, DateTime? dtPagamento)
        {
            string ValorStatus = "";

            if (!string.IsNullOrEmpty(dtPagamento.ToString()))
                ValorStatus = "Baixada";
            else
            {
                ValorStatus = DtVencimento >= DateTime.Now ? "Aberta" : "Atrasada";
            }

            return ValorStatus;

        }

        public Prestacao()
        {
        }

        public Prestacao(int id, int contratoId, Contrato contrato, DateTime dtVencimento, DateTime? dtPagamento, decimal valor)
        {
            Id = id;
            ContratoId = contratoId;
            Contrato = contrato;
            DtVencimento = dtVencimento;
            DtPagamento = dtPagamento;
            Valor = valor;
        }
    }
}
