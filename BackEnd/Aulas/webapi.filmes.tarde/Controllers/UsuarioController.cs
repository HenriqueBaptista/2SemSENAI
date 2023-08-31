using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato:
    /// Domínio/api/nomeControle
    /// exemplo: http://localhost.7242/api/Usuario
    /// </summary>
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository? _usuarioRepository { get; set; }


        /// <summary>
        /// Construtor que instancia o objeto UsuarioRepository para que haja referência aos métodos do repositório
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Loga um usuário pelo seu email e senha
        /// </summary>
        /// <param name="email"> Email a ser inserido </param>
        /// <param name="senha"> Senha a ser inserida </param>
        /// <returns> Um usuário </returns>
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                UsuarioDomain usuarioLogin = _usuarioRepository!.Login(email, senha);

                if (usuarioLogin == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha inválidos!");
                }

                return Ok(usuarioLogin);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
