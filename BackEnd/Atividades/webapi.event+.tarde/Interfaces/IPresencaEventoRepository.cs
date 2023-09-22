using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de PresencaEvento
    /// </summary>
    public interface IPresencaEventoRepository
    {
        /// <summary>
        /// Cadastra uma presença
        /// </summary>
        void Cadastrar(PresencaEvento presenca);


        /// <summary>
        /// Cancela uma presença
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Altera uma presença - Presente (true) ou Ausente (false)
        /// </summary>
        void Alterar(Guid id);


        /// <summary>
        /// Busca uma presença pelo Id
        /// </summary>
        PresencaEvento BuscarPorId(Guid id);


        /// <summary>
        /// Lista presenças de determinado usuário
        /// </summary>
        List<PresencaEvento> Listar();
    }
}
