using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;
using webapi.healthclinic.tarde2.Repositories;

namespace webapi.healthclinic.tarde2.Controllers
{
    /// <summary>
    /// Controller de Agendamento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AgendamentoController : ControllerBase
    {
        private IAgendamentoRepository agendamentoRepository { get; set; }

        /// <summary>
        /// Usa o repositório de Agendamento
        /// </summary>
        public AgendamentoController()
        {
            agendamentoRepository = new AgendamentoRepository();
        }


        /// <summary>
        /// Cadastrar
        /// </summary>
        [HttpPost]
        public IActionResult Post(Agendamento agendamento)
        {
            try
            {
                agendamentoRepository.Cadastrar(agendamento);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Listar
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(agendamentoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Atualizar
        /// </summary>
        [HttpPut]
        public IActionResult Put(Agendamento agendamento)
        {
            try
            {
                agendamentoRepository.Atualizar(agendamento.IdAgendamento, agendamento);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Deletar
        /// </summary>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                agendamentoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
