using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manager.Interfaces
{
    public interface IPacienteManager : IServiceManager<Paciente>
    {
        Paciente VerificaCPF(string cpf);
    }
}
