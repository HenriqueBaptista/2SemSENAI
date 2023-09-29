using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Interfaces
{
    /// <summary>
    /// Interface de TipoUsuario
    /// </summary>
    public interface ITipoUsuarioRepository
    {

        /// <summary>
        /// Cadastra tipos de usuário 
        /// </summary>
        void Cadastrar(TipoUsuario tipoUsuario);

        /// <summary>
        /// Deleta tipos de usuário 
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// Atualiza tipos de usuário 
        /// </summary>
        void Atualizar(Guid id, TipoUsuario tipoUsuario);

        /// <summary>
        /// Lista tipos de usuário 
        /// </summary>
        List<TipoUsuario> Listar();
    }
}
