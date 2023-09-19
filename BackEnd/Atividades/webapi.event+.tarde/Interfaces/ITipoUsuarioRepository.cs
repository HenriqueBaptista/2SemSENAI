using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TipoUsuarioRepository
    /// </summary>
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um tipo de usuário
        /// </summary>
        void Cadastrar(TipoUsuario tipoUsuario);


        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Lista os tipos de usuário
        /// </summary>
        List<TipoUsuario> Listar();


        /// <summary>
        /// Busca/seleciona um tipo de usuário
        /// </summary>
        TipoUsuario BuscarPorId(Guid id);


        /// <summary>
        /// Atualiza um tipo de usuário
        /// </summary>
        void Atualizar(Guid id, TipoUsuario tipoUsuario);
    }
}
