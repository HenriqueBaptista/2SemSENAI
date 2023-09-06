using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    /// <summary>
    /// Interface responsável pela classe UsuárioRepository
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Loga um usuário
        /// </summary>
        /// <param name="username"> Email do usuário </param>
        /// <param name="password"> Senha do usuário </param>
        /// <returns></returns>
        UsuarioDomain Login(string username, string password);
    }
}
