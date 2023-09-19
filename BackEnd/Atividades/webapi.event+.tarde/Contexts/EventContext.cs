using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto de Event +
    /// </summary>
    public class EventContext : DbContext
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
        /// TipoEvento
        /// </summary>
        public DbSet<TipoEvento> TipoEvento { get; set; }

        /// <summary>
        /// Evento
        /// </summary>
        public DbSet<Evento> Evento { get; set; }

        /// <summary>
        /// ComentarioEvento
        /// </summary>
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }

        /// <summary>
        /// Instituicao
        /// </summary>
        public DbSet<Instituicao> Instituicao { get; set; }

        /// <summary>
        /// PresencaEvento
        /// </summary>
        public DbSet<PresencaEvento> PresencaEvento { get; set; }
        


        /// <summary>
        /// Acesso ao banco de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE23-S15; Database = event+_api_tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
