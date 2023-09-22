using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de PresencaEvento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        /// <summary>
        /// Acesso a interface de PresencaEvento
        /// </summary>
        private IPresencaEventoRepository _presencaEventoRepository { get; set; }

        /// <summary>
        /// Usa o repositório de PresencaEvento
        /// </summary>
        public PresencaEventoController()
        {
            _presencaEventoRepository = new PresencaEventoRepository();
        }


        /// <summary>
        /// Endpoint que acessa o método Cadastrar
        /// </summary>
        [HttpPost]
        public IActionResult Post(PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.Cadastrar(presencaEvento);

                return StatusCode(201, "Presença cadastrada com sucesso!");
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
        public IActionResult GetById(Guid id)
        {
            try
            {
                PresencaEvento presencaEvento = _presencaEventoRepository.BuscarPorId(id);

                return Ok(presencaEvento);
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
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencaEventoRepository.Listar());
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
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaEventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //


        /// <summary>
        /// Endpoint que acessa o método Alterar
        /// </summary>
        [HttpPut]
        public IActionResult Put(Guid id)
        {
            try
            {
                _presencaEventoRepository.Alterar(id);

                return StatusCode(200, "Presença alterada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //
    }
}
