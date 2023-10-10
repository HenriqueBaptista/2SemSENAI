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
    /// Controller de Consulta
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository consultaRepository { get; set; }

        /// <summary>
        /// Usa o repositório de Consulta
        /// </summary>
        public ConsultaController()
        {
            consultaRepository = new ConsultaRepository();
        }


        /// <summary>
        /// Cadastrar
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Consulta consulta)
        {
            try
            {
                consultaRepository.Cadastrar(consulta);

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
        [Authorize(Roles = "Administrador")] [Authorize(Roles = "Médico")]
        public IActionResult Get()
        {
            try
            {
                return Ok(consultaRepository.Listar());
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
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(Consulta consulta)
        {
            try
            {
                consultaRepository.Atualizar(consulta.IdConsulta, consulta);

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
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                consultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
