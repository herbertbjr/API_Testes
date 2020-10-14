using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoTeste.Models
{
    public class Contrato
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Data do contrato")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Required(ErrorMessage = "Por favor, informe o valor para o campo: Data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Por favor, informe o valor para o campo: Quantidade de parcelas")]
        [Display(Name = "Quantidade de Parcelas", Description = "A quantidade de parcelas deve ser entre 1 e 60.")]
        [Range(1, 60)]
        public int QtdeParcelas { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Por favor, informe o valor para o campo: Valor financiado")]
        [Display(Name = "Valor financiado")]
        public decimal VlrFinanciado { get; set; }
        public ICollection<Prestacao> Prestacao { get; set; }
        public Contrato()
        {
            Prestacao = new Collection<Prestacao>();
        }
    }
}
