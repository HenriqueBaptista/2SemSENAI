using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de TipoEvento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        /// <summary>
        /// Chamada da interface TipoEventoRepository
        /// </summary>
        private ITipoEventoRepository _tipoEventoRepository { get; set; } //

        /// <summary>
        /// Construtor do controller - chama o repositório de TipoEvento
        /// </summary>
        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        } //

        /// <summary>
        /// Endpoint que acessa o método Cadastrar
        /// </summary>
        [HttpPost]
        public IActionResult Post(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tipoEvento);

                return StatusCode(201, "Tipo de evento criado com sucesso!");
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
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                return Ok(tipoEventoBuscado);
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
                return Ok(_tipoEventoRepository.Listar());
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
                _tipoEventoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //


        /// <summary>
        /// Endpoint que acessa o método Atualizar
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(tipoEvento.IdTipoEvento, tipoEvento);

                return StatusCode(200, "Tipo de evento atualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //
    }
} // Complete
