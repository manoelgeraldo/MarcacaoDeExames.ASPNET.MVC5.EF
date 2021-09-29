﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Manager.Interfaces
{
    public interface IExameManager : IServiceManager<Exame>
    {
        IEnumerable<Exame> ExamesIncluindoTipos();
    }
}