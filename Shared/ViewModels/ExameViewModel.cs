using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class ExameViewModel
    {
        public int ExameId { get; set; }

        [Display(Name = "Nome do Exame"), MaxLength(100)]
        [Required(ErrorMessage = "Informe o {0}. É obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Obeservações"), MaxLength(1000)]
        public string Observacao { get; set; }

        public int TipoExameId { get; set; }

        [Required(ErrorMessage = "Informe o {0}. É obrigatório!")]
        public virtual  TipoExameViewModel TipoExame { get; set; }
    }
}
