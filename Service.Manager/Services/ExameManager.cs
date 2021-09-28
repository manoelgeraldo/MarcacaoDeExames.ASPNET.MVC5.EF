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
    public class ExameManager : ServiceManager<Exame>, IExameManager
    {
        private readonly IExameRepository exameRepository;

        public ExameManager(IExameRepository exameRepository) : base(exameRepository)
        {
            this.exameRepository = exameRepository;
        }

        public IEnumerable<Exame> ExamesIncluindoTipos()
        {
            return exameRepository.ExamesIncluindoTipos();
        }
    }
}
