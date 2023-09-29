using webapi.healthclinic.tarde2.Contexts;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;

namespace webapi.healthclinic.tarde2.Repositories
{
    /// <summary>
    /// Repositório de TipoConsulta
    /// </summary>
    public class TipoConsultaRepository : ITipoConsultaRepository
    {
        private readonly HealthContext healthContext;

        /// <summary>
        /// Usa o HealthContext
        /// </summary>
        public TipoConsultaRepository()
        {
            healthContext = new HealthContext();
        }


        /// <summary>
        /// Atualiza tipos de consulta
        /// </summary>
        public void Atualizar(Guid id, TipoConsulta tipoConsulta)
        {
            TipoConsulta tipoConsultaBuscado = healthContext.TipoConsulta.Select(tc => new TipoConsulta
            {
                IdTipoConsulta = tc.IdTipoConsulta,
                Titulo = tc.Titulo
            }).FirstOrDefault(tc => tc.IdTipoConsulta == id)!;

            tipoConsultaBuscado = tipoConsulta;

            healthContext.Update(tipoConsulta);

            healthContext.SaveChanges();
        }
        

        /// <summary>
        /// Cadastra tipos de consulta
        /// </summary>
        public void Cadastrar(TipoConsulta tipoConsulta)
        {
            try
            {
                healthContext.TipoConsulta.Add(tipoConsulta);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta tipos de consulta
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                TipoConsulta tipoConsulta = new TipoConsulta();

                tipoConsulta.IdTipoConsulta = id;

                healthContext.TipoConsulta.Remove(tipoConsulta);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista tipos de consulta
        /// </summary>
        public List<TipoConsulta> Listar()
        {
            try
            {
                return healthContext.TipoConsulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
