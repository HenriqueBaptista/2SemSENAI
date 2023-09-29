using webapi.healthclinic.tarde2.Contexts;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;

namespace webapi.healthclinic.tarde2.Repositories
{
    /// <summary>
    /// Repositório de TipoUsuario
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthContext healthContext;

        /// <summary>
        /// Usa o HealthContext
        /// </summary>
        public TipoUsuarioRepository()
        {
            healthContext = new HealthContext();
        }


        /// <summary>
        /// Atualiza tipos de usuário
        /// </summary>
        public void Atualizar(Guid id, TipoUsuario tipoConsulta)
        {
            TipoUsuario tipoConsultaBuscado = healthContext.TipoUsuario.Select(tu => new TipoUsuario
            {
                IdTipoUsuario = tu.IdTipoUsuario,
                Titulo = tu.Titulo
            }).FirstOrDefault(tu => tu.IdTipoUsuario == id)!;

            tipoConsultaBuscado = tipoConsulta;

            healthContext.Update(tipoConsulta);

            healthContext.SaveChanges();
        }


        /// <summary>
        /// Cadastra tipos de usuário
        /// </summary>
        public void Cadastrar(TipoUsuario tipoConsulta)
        {
            try
            {
                healthContext.TipoUsuario.Add(tipoConsulta);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta tipos de usuário
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoConsulta = new TipoUsuario();

                tipoConsulta.IdTipoUsuario = id;

                healthContext.TipoUsuario.Remove(tipoConsulta);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista tipos de usuário
        /// </summary>
        public List<TipoUsuario> Listar()
        {
            try
            {
                return healthContext.TipoUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
