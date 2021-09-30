using Domain.Entities;
using Domain.Interfaces;
using Service.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manager.Services
{
    public class ConsultaManager : ServiceManager<Consulta>, IConsultaManager
    {
        private readonly IConsultaRepository consultaRepository;
        public ConsultaManager(IConsultaRepository consultaRepository) : base(consultaRepository)
        {
            this.consultaRepository = consultaRepository;
        }
    }
}
