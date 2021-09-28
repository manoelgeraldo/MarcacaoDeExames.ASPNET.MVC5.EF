using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exame
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }

        public int TipoExameId { get; set; }
        public TipoExame TipoExame { get; set; }
    }
}
