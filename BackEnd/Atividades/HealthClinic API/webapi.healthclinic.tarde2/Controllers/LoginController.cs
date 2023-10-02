using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;
using webapi.healthclinic.tarde2.Repositories;
using webapi.healthclinic.tarde2.ViewModels;

namespace webapi.healthclinic.tarde2.Controllers
{
    /// <summary>
    /// Controller do método Login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Chamada da interface IUsuarioRepository
        /// </summary>
        private readonly IUsuarioRepository? usuarioRepository;

        /// <summary>
        /// Construtor do controller, chama o UsuarioRepository
        /// </summary>
        public LoginController()
        {
            usuarioRepository = new UsuarioRepository();
        }


        /// <summary>
        /// Logar
        /// </summary>
        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = usuarioRepository!.BuscarPorEmailESenha(usuario.Email!, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario!.ToString()!),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("login-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                    issuer: "healthclinic_api_tarde_2",

                    audience: "healthclinic_api_tarde_2",

                    claims: claims,

                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
