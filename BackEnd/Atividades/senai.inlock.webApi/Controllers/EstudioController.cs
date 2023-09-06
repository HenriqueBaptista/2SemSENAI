using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints do objeto Estudio
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        IEstudioRepository _estudioRepository { get; set; }


        /// <summary>
        /// Instância do objeto _estudioRepository para que haja referência aos métodos do repositório
        /// </summary>
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }


        /// <summary>
        /// Endpoint que acessa o método ListarTodos
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        } // Completo


        /// <summary>
        /// Endpoint que acessa o método Cadastrar
        /// </summary>
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository!.Cadastrar(novoEstudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        } // Completo


        /// <summary>
        /// Endpoint que acessa o método Deletar
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _estudioRepository!.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        } // Completo


        /// <summary>
        /// Endpoint que acessa o método BuscarPorId
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

                if (estudioBuscado == null)
                {
                    return NotFound("Estúdio não existente ou não cadastrado");
                }

                return Ok(estudioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        } // Completo


        [HttpPut]
        public IActionResult Put(EstudioDomain estudio)
        {
            try
            {
                EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(estudio.IdEstudio);

                if (estudioBuscado != null)
                {
                    try
                    {
                        _estudioRepository.AtualizarIdCorpo(estudioBuscado);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }
                }

                return NotFound("Estúdio não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
