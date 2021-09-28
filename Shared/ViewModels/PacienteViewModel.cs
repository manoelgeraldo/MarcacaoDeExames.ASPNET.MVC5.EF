using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class PacienteViewModel
    {
        [Required(ErrorMessage = "É obrigatório!")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MinLength(11)]
        [MaxLength(11)]
        [RegularExpression(@"(\d{3})(\d{3})(\d{3})(\d{2})", ErrorMessage = "Informe apenas os 11 números do CPF!")]
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [EnumDataType(typeof(Sexo))]
        public Sexo Sexo { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+55)?[\s]?\(?(\d{2})?\)?[\s-]?(9?\d{4}[\s-]?\d{4})$", ErrorMessage = "Insira um formato válido! Ex.: (81) 9 1234-5678")]
        public string Telefone { get; set; }

        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
