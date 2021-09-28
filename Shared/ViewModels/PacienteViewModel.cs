using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shared.ViewModels
{
    public class PacienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe um Nome. É obrigatório!"), MaxLength(100)]
        public string Nome { get; set; }
                
        [MinLength(14), MaxLength(14)]
        [Required(ErrorMessage = "Informe um CPF. É obrigatório!")]
        [Remote("ValidarCPF", "Pacientes", ErrorMessage = "CPF já cadastrado!")]
        [RegularExpression(@"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)", ErrorMessage = "Informe apenas os números do CPF!")]
        public string CPF { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [EnumDataType(typeof(Sexo))]
        public Sexo Sexo { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\(\d{2}\)\s)(\d{4,5}\-\d{4})$", ErrorMessage = "Insira um formato válido! Ex.: (81) 9 1234-5678")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress, MaxLength(50)]
        public string Email { get; set; }
    }
}
