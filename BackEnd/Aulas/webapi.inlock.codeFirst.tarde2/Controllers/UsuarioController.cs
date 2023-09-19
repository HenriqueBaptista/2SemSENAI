using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using webapi.inlock.codeFirst.tarde2.Interfaces;
using webapi.inlock.codeFirst.tarde2.Repositories;
using webapi.inlock.CodeFirst_Tarde.Domains;

namespace webapi.inlock.codeFirst.tarde2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository? _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository!.Cadastrar(usuario);

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetByEmailAndPassword(Usuario usuario, string senha) 
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository!.BuscarUsuario(usuario.Email!, senha);

                if (usuarioBuscado != null)
                {
                    return Ok(usuario);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
