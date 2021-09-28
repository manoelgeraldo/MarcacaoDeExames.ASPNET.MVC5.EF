using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class TipoExameConfiguration : EntityTypeConfiguration<TipoExame>
    {
        public TipoExameConfiguration()
        {
            //Determina que o atributo Descrição não pode ter mais que 256 caracteres.
            Property(c => c.Descricao)
                .IsRequired().HasMaxLength(256);

            //Determina que o atributo Tipo é Obrigatório.
            Property(c => c.Tipo)
                .IsRequired();
        }
    }
}
