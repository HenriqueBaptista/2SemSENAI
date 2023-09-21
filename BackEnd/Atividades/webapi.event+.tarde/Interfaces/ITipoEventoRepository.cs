using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de TipoEvento
    /// </summary>
    public interface ITipoEventoRepository
    {
        /// <summary>
        /// Cadastra um tipo de evento
        /// </summary>
        void Cadastrar(TipoEvento tipoEvento);


        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Lista os tipos de evento
        /// </summary>
        List<TipoEvento> Listar();


        /// <summary>
        /// Busca/seleciona um tipo de evento
        /// </summary>
        TipoEvento BuscarPorId(Guid id);


        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        void Atualizar(Guid id, TipoEvento tipoEvento);
    }
} // Complete
