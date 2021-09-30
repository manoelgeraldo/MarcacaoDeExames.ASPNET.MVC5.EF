using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ConsultaRepository : RepositoryBase<Consulta>, IConsultaRepository
    {
        public Consulta VerificarConsulta(string protocolo)
        {
            return Db.Set<Consulta>().FirstOrDefault(x => x.Protocolo == protocolo);
        }
    }
}
