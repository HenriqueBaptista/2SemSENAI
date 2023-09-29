using webapi.healthclinic.tarde2.Contexts;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;

namespace webapi.healthclinic.tarde2.Repositories
{
    /// <summary>
    /// Repositório de Consulta
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext healthContext;

        /// <summary>
        /// Usa a HealthContext
        /// </summary>
        public ConsultaRepository()
        {
            healthContext = new HealthContext();
        }


        /// <summary>
        /// Atualiza consultas
        /// </summary>
        public void Atualizar(Guid id, Consulta consulta)
        {
            try
            {
                Consulta consultaAtualizar = healthContext.Consulta.Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    Condição = c.Condição,
                    Prontuario = c.Prontuario,
                    
                    TipoConsulta = new TipoConsulta
                    {
                        IdTipoConsulta = c.TipoConsulta!.IdTipoConsulta
                    },

                    Agendamento = new Agendamento
                    {
                        IdAgendamento = c.Agendamento!.IdAgendamento
                    }
                }).FirstOrDefault(c => c.IdConsulta == id)!;

                consultaAtualizar = consulta;

                healthContext.Update(consulta);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cadastra consultas
        /// </summary>
        public void Cadastrar(Consulta consulta)
        {
            try
            {
                healthContext.Consulta.Add(consulta);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta consultas
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                Consulta consulta = new Consulta();

                consulta.IdConsulta = id;

                healthContext.Consulta.Remove(consulta);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista consultas
        /// </summary>
        public List<Consulta> Listar()
        {
            try
            {
                return healthContext.Consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
