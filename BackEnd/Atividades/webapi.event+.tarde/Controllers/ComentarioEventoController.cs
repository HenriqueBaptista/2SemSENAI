using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de ComentarioEvento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        /// <summary>
        /// Acesso a Comentario
        /// </summary>
        private IComentarioEventoRepositoy _ComentarioEventoRepository { get; set; }

        /// <summary>
        /// Construtor para usar o Comentario
        /// </summary>
        public ComentarioEventoController()
        {
            _ComentarioEventoRepository = new ComentarioEventoRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult Post(ComentarioEvento comentario)
        {
            try
            {
                _ComentarioEventoRepository.Cadastrar(comentario);

                return StatusCode(201, "Comentário enviado com sucesso!");
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
                ComentarioEvento comentario = _ComentarioEventoRepository.BuscarPorId(id);

                return Ok(comentario);
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
                return Ok(_ComentarioEventoRepository.Listar());
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
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _ComentarioEventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //


        /// <summary>
        /// Endpoint que acessa o método AlterarExibicao
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult SwitchBool(Guid id)
        {
            try
            {
                _ComentarioEventoRepository.AlterarExibicao(id);

                return StatusCode(200, "Comentário alterado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //
    }
}
