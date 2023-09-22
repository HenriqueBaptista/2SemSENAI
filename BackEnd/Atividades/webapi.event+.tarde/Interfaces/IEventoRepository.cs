using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de Evento
    /// </summary>
    public interface IEventoRepository
    {
        /// <summary>
        /// Cadastra eventos
        /// </summary>
        void Cadastrar(Evento evento);


        /// <summary>
        /// Deleta eventos
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Atualiza eventos
        /// </summary>
        void Atualizar(Guid id, Evento evento);


        /// <summary>
        /// Lista eventos
        /// </summary>
        List<Evento> Listar();


        /// <summary>
        /// Busca eventos pelo id
        /// </summary>
        Evento BuscarPorId(Guid id);
    }
}
