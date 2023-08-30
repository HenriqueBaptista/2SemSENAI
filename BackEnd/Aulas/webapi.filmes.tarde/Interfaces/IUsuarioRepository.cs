using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        void Cadastrar(UsuarioDomain usuario);

        /// <summary>
        /// Bane usuários. Apenas administradores têm essa permissão
        /// </summary>
        void BanirUsuario(UsuarioDomain usuario);

        /// <summary>
        /// Loga um usuário já cadastrado
        /// </summary>
        void Login(UsuarioDomain usuario);

        /// <summary>
        /// Desloga um usuário que está logado
        /// </summary>
        void Logout(UsuarioDomain usuario);
    }
}
