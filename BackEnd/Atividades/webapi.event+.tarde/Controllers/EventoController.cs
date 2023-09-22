using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de Evento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        /// <summary>
        /// Chamada da interface de Evento
        /// </summary>
        private IEventoRepository _eventoRepository { get; set; }

        /// <summary>
        /// Construtor do controller - chama o repositório de Evento
        /// </summary>
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Diretor")]
        public IActionResult Post(Evento Evento)
        {
            try
            {
                _eventoRepository.Cadastrar(Evento);

                return StatusCode(201, "Evento criado com sucesso!");
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
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                return Ok(eventoBuscado);
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
                return Ok(_eventoRepository.Listar());
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
                _eventoRepository.Deletar(id);

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
        [HttpPut]
        [Authorize]
        public IActionResult Put(Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(evento.IdEvento, evento);

                return StatusCode(200, "Evento atualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //
    }
}
