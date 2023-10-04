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
    /// Controller de Clinica
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private IClinicaRepository clinicaRepository { get; set; }

        /// <summary>
        /// Usa o repositório Clinica
        /// </summary>
        public ClinicaController()
        {
            clinicaRepository = new ClinicaRepository();
        }


        /// <summary>
        /// Cadastrar
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Clinica clinica)
        {
            try
            {
                clinicaRepository.Cadastrar(clinica);

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
                return Ok(clinicaRepository.Listar());
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
        public IActionResult Put(Clinica clinica)
        {
            try
            {
                clinicaRepository.Atualizar(clinica.IdClinica, clinica);

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
                clinicaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
