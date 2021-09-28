using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ExameConfiguration : EntityTypeConfiguration<Exame>
    {
        public ExameConfiguration()
        {
            //Determina que o atributo Observção não pode ter mais que 1000 caracteres.
            Property(c => c.Observacao)
                .IsRequired().HasMaxLength(1000);

            //Determina que o atributo Id não pode ser Nulo.
            Property(c => c.TipoExameId)
                .IsRequired();
        }
    }
}
