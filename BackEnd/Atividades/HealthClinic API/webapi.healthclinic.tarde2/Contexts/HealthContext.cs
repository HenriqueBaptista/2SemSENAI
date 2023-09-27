using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Contexts
{
    /// <summary>
    /// Context de Health Clinic
    /// </summary>
    public class HealthContext : DbContext
    {
        /// <summary>
        /// TipoUsuario
        /// </summary>
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Clinica
        /// </summary>
        public DbSet<Clinica> Clinica { get; set; }

        /// <summary>
        /// Agendamento
        /// </summary>
        public DbSet<Agendamento> Agendamento { get; set; }

        /// <summary>
        /// TipoConsulta
        /// </summary>
        public DbSet<TipoConsulta> TipoConsulta { get; set; }

        /// <summary>
        /// Consulta
        /// </summary>
        public DbSet<Consulta> Consulta { get; set; }



        /// <summary>
        /// Acesso ao banco de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE23-S15; Database = healthclinic_api_tarde_2; User Id = sa; Pwd = Senai@134; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
