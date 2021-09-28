using Data.Configurations;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexto
{
    public class DbContexto : DbContext
    {
        public DbContexto() : base("MarcacaoConsulta")
        {
            //Automatiza as Migrations
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContexto, Migrations.Configuration>());
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoExame> TipoExames { get; set; }
        public DbSet<Exame> Exames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove a exclusão em cascata das entidades relacionadas
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Configura o tipo de string no db
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Configura o tamanho do tipo string
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //Configura o tamanho do tipo string
            modelBuilder.Properties<DateTime>()
                .Configure(p => p.HasColumnType("date"));

            //Configuração específica das entidades
            modelBuilder.Configurations.Add(new PacienteConfiguration());
            modelBuilder.Configurations.Add(new TipoExameConfiguration());
            modelBuilder.Configurations.Add(new ExameConfiguration());
        }

    }
}
