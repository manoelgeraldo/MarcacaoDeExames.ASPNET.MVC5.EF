using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ExameRepository : RepositoryBase<Exame>, IExameRepository
    {
        public IEnumerable<Exame> ExamesIncluindoTipos()
        {
            return Db.Set<Exame>().Include("Exame.TipoExame").ToList();
        }
    }
}
