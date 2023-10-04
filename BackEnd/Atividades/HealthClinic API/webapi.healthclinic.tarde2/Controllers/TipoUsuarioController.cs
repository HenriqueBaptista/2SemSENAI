using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;
using webapi.healthclinic.tarde2.Repositories;

namespace webapi.healthclinic.tarde2.Controllers
{
    /// <summary>
    /// Controller de TipoUsuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Usa o repositório TipoUsuario
        /// </summary>
        public TipoUsuarioController()
        {
            tipoUsuarioRepository = new TipoUsuarioRepository();
        }


        /// <summary>
        /// Listar
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(tipoUsuarioRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
} // Completo
