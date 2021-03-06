using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class TipoExameViewModel
    {
        public int TipoExameId { get; set; }

        [Display(Name = "Tipo de Exame"), MaxLength(100)]
        [Required(ErrorMessage = "Informe o {0}. É obrigatório!")]
        public string Tipo { get; set; }

        [Display(Name = "Descrição"), MaxLength(256)]
        public string Descricao { get; set; }
    }
}
