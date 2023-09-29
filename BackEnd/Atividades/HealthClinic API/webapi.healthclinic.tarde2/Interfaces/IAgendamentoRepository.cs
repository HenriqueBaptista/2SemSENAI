using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Interfaces
{
    /// <summary>
    /// Interface de Agendamento
    /// </summary>
    public interface IAgendamentoRepository
    {
        /// <summary>
        /// Cadastra agendamentos
        /// </summary>
        void Cadastrar(Agendamento agendamento);


        /// <summary>
        /// Deleta agendamentos
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Atualiza agendamentos
        /// </summary>
        void Atualizar(Guid id, Agendamento agendamento);


        /// <summary>
        /// Lista agendamentos
        /// </summary>
        List<Agendamento> Listar();
    }
}
