using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Consulta
    {
        public int ConsultaId { get; set; }

        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        public int TipoExameId { get; set; }
        public virtual TipoExame TipoExame { get; set; }

        public int ExameId { get; set; }
        public virtual Exame Exame { get; set; }
        public DateTime DataConsulta { get; set; }
        public TimeSpan HorarioConsulta { get; set; }
        public string Protocolo { get; set; }
    }
}
