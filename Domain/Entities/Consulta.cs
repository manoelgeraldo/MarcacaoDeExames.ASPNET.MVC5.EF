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
        public virtual Paciente Paciente { get; set; }
        public virtual TipoExame TipoExame { get; set; }
        public virtual Exame Exame { get; set; }
        public DateTime DataConsulta { get; set; }
        public DateTime HorarioConsulta { get; set; }
        public int Protocolo { get; set; }
    }
}
