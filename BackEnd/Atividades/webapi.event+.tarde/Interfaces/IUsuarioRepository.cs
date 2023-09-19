using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo UsuarioRepository
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra usuários
        /// </summary>
        void Cadastrar(Usuario usuario);


        /// <summary>
        /// Busca usuários pelos Ids
        /// </summary>
        Usuario BuscarPorId(Guid id);


        /// <summary>
        /// Busca usuários pelo email e senha
        /// </summary>
        Usuario BuscarPorEmailESenha(string email, string senha);


        /// <summary>
        /// Atualiza usuários
        /// </summary>
        void Atualizar(Usuario usuario);


        /// <summary>
        /// Deleta usuários
        /// </summary>
        /// <param name="id"></param>
        void Deletar(Guid id);
    }
}
