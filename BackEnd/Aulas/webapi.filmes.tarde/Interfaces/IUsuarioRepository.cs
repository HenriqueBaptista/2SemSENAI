using Microsoft.AspNetCore.Identity;
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
        /// Método que busca um usuário por email e senha
        /// </summary>
        /// <param name="email"> Email do usuário </param>
        /// <param name="senha"> Senha do usuário </param>
        /// <returns> Objeto que foi buscado </returns>
        UsuarioDomain Login(string email, string senha);
    }
}
