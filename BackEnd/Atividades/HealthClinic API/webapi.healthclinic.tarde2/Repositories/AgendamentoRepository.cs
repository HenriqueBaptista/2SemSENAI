using webapi.healthclinic.tarde2.Contexts;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;

namespace webapi.healthclinic.tarde2.Repositories
{
    /// <summary>
    /// Repositório de Agendamento
    /// </summary>
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly HealthContext healthContext;
        
        /// <summary>
        /// Usa a HealthContext
        /// </summary>
        public AgendamentoRepository()
        {
            healthContext = new HealthContext();
        }


        /// <summary>
        /// Atualiza agendamentos
        /// </summary>
        public void Atualizar(Guid id, Agendamento agendamento)
        {
            try
            {
                Agendamento agendamentoAtualizar = healthContext.Agendamento.Select(a => new Agendamento
                {
                    IdAgendamento = a.IdAgendamento,
                    DiaAgendamento = a.DiaAgendamento,

                    Clinica = new Clinica
                    {
                        IdClinica = a.Clinica!.IdClinica
                    },

                    Usuario = new Usuario
                    {
                        IdUsuario = a.Usuario!.IdUsuario,
                    }

                }).FirstOrDefault()!;

                agendamentoAtualizar = agendamento;

                healthContext.Agendamento.Update(agendamento);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cadastra  agendamentos
        /// </summary>
        public void Cadastrar(Agendamento agendamento)
        {
            try
            {
                healthContext.Agendamento.Add(agendamento);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta agendamentos
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                Agendamento agendamento = new Agendamento();

                agendamento.IdAgendamento = id;

                healthContext.Agendamento.Remove(agendamento);

                healthContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista agendamentos
        /// </summary>
        public List<Agendamento> Listar()
        {
            return healthContext.Agendamento.ToList();
        }
    }
}
