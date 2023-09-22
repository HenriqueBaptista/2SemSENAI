using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de Usuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Chamada da interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository; //

        /// <summary>
        /// Construtor do controller - chama o repositório de Usuario
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        } //


        /// <summary>
        /// Endpoint que acessa o método Cadastrar
        /// </summary>
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, "Usuário cadastrado!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //


        /// <summary>
        /// Endpoint que acessa o método Listar
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.Listar()!);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //


        /// <summary>
        /// Endpoint que acessa o método BuscarPorId
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario UsuarioBuscado = _usuarioRepository.BuscarPorId(id);

                return Ok(UsuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //


        /// <summary>
        /// Endpoint que acessa o método Atualizar
        /// </summary>
        [HttpPut]
        public IActionResult Put(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Atualizar(usuario.IdUsuario, usuario);

                return StatusCode(200, "Usuário atualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //


        /// <summary>
        /// Endpoint que acessa o método Delete
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Diretor")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //
    }
} // Complete
