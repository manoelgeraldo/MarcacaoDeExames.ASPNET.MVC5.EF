
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class ConsultaViewModel
    {
        public int ConsultaId { get; set; }

        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Informe o {0}. É obrigatório!")]
        public virtual PacienteViewModel Paciente { get; set; }

        public int TipoExameId { get; set; }

        [Display(Name ="Tipo de Exame")]
        [Required(ErrorMessage = "Informe o {0}. É obrigatório!")]
        public virtual TipoExameViewModel TipoExame { get; set; }

        public int ExameId { get; set; }

        public virtual ExameViewModel Exame { get; set; }

        [Display(Name ="Data da Consulta")]
        [Required(ErrorMessage = "Informe a {0}. É obrigatório!")]
        public DateTime DataConsulta { get; set; }

        [Display(Name = "Hora da Consulta")]
        [DisplayFormat(DataFormatString ="{0 HH:mm}", ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "Informe a {0}. É obrigatório!")]
        public DateTime HorarioConsulta { get; set; }

        public int Protocolo { get; set; }
    }
}
