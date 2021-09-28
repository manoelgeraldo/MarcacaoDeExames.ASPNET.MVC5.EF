using Domain.Entities;
using Domain.Interfaces;
using Service.Manager.Interfaces;

namespace Service.Manager.Services
{
    public class PacienteManager : ServiceManager<Paciente>, IPacienteManager
    {
        private readonly IPacienteRepository pacienteRepository;


        public PacienteManager(IPacienteRepository pacienteRepository) : base(pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }
    }
}
