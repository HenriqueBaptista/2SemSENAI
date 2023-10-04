using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using webapi.healthclinic.tarde2.Repositories;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace webapi.healthclinic.tarde2.Controllers
{
    /// <summary>
    /// Controller de TipoConsulta
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoConsultaController : ControllerBase
    {
        private ITipoConsultaRepository tipoConsultaRepository { get; set; }

        /// <summary>
        /// Usa o repositório TipoConsulta
        /// </summary>
        public TipoConsultaController()
        {
            tipoConsultaRepository = new TipoConsultaRepository();
        }


        /// <summary>
        /// Cadastrar
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(TipoConsulta tipoConsulta)
        {
            try
            {
                tipoConsultaRepository.Cadastrar(tipoConsulta);

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
        [Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(tipoConsultaRepository.Listar());
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
        public IActionResult Put(TipoConsulta tipoConsulta)
        {
            try
            {
                tipoConsultaRepository.Atualizar(tipoConsulta.IdTipoConsulta, tipoConsulta);

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
                tipoConsultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
