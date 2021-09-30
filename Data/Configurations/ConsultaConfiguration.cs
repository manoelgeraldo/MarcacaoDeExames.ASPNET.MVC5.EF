using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ConsultaConfiguration : EntityTypeConfiguration<Consulta>
    {
        public ConsultaConfiguration()
        {
            //Determina que o atributo DataConsulta é Obrigatório.
            Property(c => c.DataConsulta)
                .IsRequired();

            //Determina que o atributo HoraConsulta é Obrigatório.
            Property(c => c.HorarioConsulta)
                .IsRequired().HasColumnType("datetime");

            //Determina que o atributo Id não pode ser Nulo.
            Property(c => c.PacienteId)
                .IsRequired();

            //Determina que o atributo Id não pode ser Nulo.
            Property(c => c.TipoExameId)
                .IsRequired();

            //Determina que o atributo Id não pode ser Nulo.
            Property(c => c.ExameId)
                .IsRequired();
        }
    }
}
