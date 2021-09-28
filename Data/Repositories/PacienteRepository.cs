using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PacienteRepository : RepositoryBase<Paciente>, IPacienteRepository
    {
        public Paciente VerificaCPF(string cpf)
        {
            return Db.Set<Paciente>().FirstOrDefault(x => x.CPF == cpf);
        }
    }
}
