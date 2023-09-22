using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    /// <summary>
    /// Inteface responsável pelo repositório de ComentarioEvento
    /// </summary>
    public interface IComentarioEventoRepositoy
    {
        /// <summary>
        /// Cadastra um comentário
        /// </summary>
        void Cadastrar(ComentarioEvento comentarioEvento);


        /// <summary>
        /// Deleta um cometário
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Altera a exibição de um comentário - Exibe (true) ou Não exibe (false)
        /// </summary>
        void AlterarExibicao(Guid id);


        /// <summary>
        /// Busca um comentário pelo Id
        /// </summary>
        ComentarioEvento BuscarPorId(Guid id);


        /// <summary>
        /// Lista comentários
        /// </summary>
        List<ComentarioEvento> Listar();
    }
}
