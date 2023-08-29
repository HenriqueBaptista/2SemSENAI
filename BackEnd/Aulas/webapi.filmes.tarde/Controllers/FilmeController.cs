using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Rotas e nova classe
    /// </summary>
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]

    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }


        /// <summary>
        /// Endpoint que acessa o método ListarTodos
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                return Ok(listaFilmes);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        } // Complete


        /// <summary>
        /// Endpoint que acessa o método Cadastrar
        /// </summary>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        } // Complete


        /// <summary>
        /// Endpoint que acessa o método BuscarPorId
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("Filme não encontrado");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        } // Complete


        /// <summary>
        /// Endpoint que acessa o método Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado != null)
                {
                    _filmeRepository.Deletar(id);

                    return StatusCode(204);
                }

                return NotFound("Não há nenhum filme com o Id");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        } // Complete
    }
}
