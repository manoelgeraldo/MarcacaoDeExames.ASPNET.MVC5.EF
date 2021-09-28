using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    // Fluent API.
    // Modela o comportamento da entidade como uma tabela no banco dados.

    public class PacienteConfiguration : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfiguration()
        {
            //Determina que o atributo Nome é Obrigatório.
            Property(c => c.Nome)
                .IsRequired();

            //Determina que o atributo CPF é Obrigatório.
            Property(c => c.CPF)
                .IsRequired().HasMaxLength(11);

            //Determina que o atributo DataNascimento é Opcional.
            Property(c => c.DataNascimento)
                .IsOptional();

            //Determina que o atributo Sexo é Obrigatório.
            Property(c => c.Sexo)
                .IsRequired();

            //Determina que o atributo Telefone é Obrigatório.
            Property(c => c.Telefone)
                .IsRequired();

            //Determina que o atributo Email é Opcional.
            Property(c => c.Email)
                .IsOptional().HasMaxLength(50);

        }
    }
}
