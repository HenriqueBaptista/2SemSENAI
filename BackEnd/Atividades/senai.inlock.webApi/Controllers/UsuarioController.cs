using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi_.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints do objeto Usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }


        /// <summary>
        /// Construtor
        /// Instância do objeto _generoRepository para que haja referência aos métodos do repositório
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Loga um usuário pelo seu email e senha
        /// </summary>
        [HttpPost]
        public IActionResult Login(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioLogin = _usuarioRepository!.Login(usuario.Email!, usuario.Senha!);

                if (usuarioLogin == null)
                {
                    return NotFound("Usuário não encontrado, email ou senha inválidos!");
                }

                // Caso encontado o usuário buscado, prossegue para a criação do Token

                // 1. Definir as informações(Claims) que serão fornecidas no Token - (Payload)
                var claims = new[]
                {
                    // Formato da claim (tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioLogin.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioLogin.Email!.ToString()),
                    // Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada", "Valor Personalizado")
                };

                // 2. Definir a chave de acesso ao Token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

                // 3. Definir as credenciais do Token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // 4. Gerar o Token
                var token = new JwtSecurityToken
                    (
                    // Emissor do Token
                    issuer: "webapi.filmes.tarde",

                    // Destinatário
                    audience: "webapi.filmes.tarde",

                    // Dados definidos nas claims (Payload)
                    claims: claims,

                    // Tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    // Credenciais do Token
                    signingCredentials: creds
                    );

                // 5. Retornar o Token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
