using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Interfaces
{
    /// <summary>
    /// Interface de Usuario
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra usuários 
        /// </summary>
        void Cadastrar(Usuario usuario);


        /// <summary>
        /// Deleta usuários
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Atualiza usuários
        /// </summary>
        void Atualizar(Guid id, Usuario usuario);


        /// <summary>
        /// Busca usuários pelo Id
        /// </summary>
        Usuario Buscar(Guid id);


        /// <summary>
        /// Lista usuários
        /// </summary>
        /// <returns></returns>
        List<Usuario> Listar();
    }
}
