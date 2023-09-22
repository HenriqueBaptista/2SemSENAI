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
    /// Controller responsável pelos endpoints de Instituicao
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        /// <summary>
        /// Chamada da interface de Instituicao
        /// </summary>
        private IInstituicaoRepository _instituicaoRepository { get; set; } //

        /// <summary>
        /// Construtor do controller - chama o repositório de Instituicao
        /// </summary>
        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        } //


        /// <summary>
        /// Endpoint que acessa o método Cadastrar
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Diretor")]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);

                return StatusCode(201, "Instituição criada com sucesso!");
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
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                return Ok(instituicaoBuscada);
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
                return Ok(_instituicaoRepository.Listar());
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
                _instituicaoRepository.Deletar(id);

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
        [Authorize(Roles = "Diretor")]
        public IActionResult Put(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Atualizar(instituicao.IdInstituicao, instituicao);

                return StatusCode(200, "Instituição atualizada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        } //
    }
}
