
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shared.ViewModels
{
    public class ConsultaViewModel
    {
        public int ConsultaId { get; set; }

        public int PacienteId { get; set; }
        public virtual PacienteViewModel Paciente { get; set; }

        public int TipoExameId { get; set; }

        [Display(Name ="Tipo de Exame")]
        public virtual TipoExameViewModel TipoExame { get; set; }

        public int ExameId { get; set; }

        public virtual ExameViewModel Exame { get; set; }

        [DataType(DataType.Date), Display(Name = "Data da Consulta")]
        [Required(ErrorMessage = "Informe a {0}. É obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DataConsulta { get; set; }

        [DataType(DataType.Time), Display(Name = "Hora da Consulta")]
        [Required(ErrorMessage = "Informe a {0}. É obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan HorarioConsulta { get; set; }

        public string Protocolo { get; set; }
    }
}
