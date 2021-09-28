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
    public class TipoExameManager : ServiceManager<TipoExame>, ITipoExameManager
    {
        private readonly ITipoExameRepository tipoExameRepository;

        public TipoExameManager(ITipoExameRepository tipoExameRepository) : base(tipoExameRepository)
        {
            this.tipoExameRepository = tipoExameRepository;
        }
    }
}
