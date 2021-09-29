using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoExame
    {
        public int TipoExameId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
