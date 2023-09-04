using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato:
    /// Domínio/api/nomeControle
    /// exemplo: http://localhost.7242/api/Genero
    /// </summary>
    [Route("api/[controller]")]


    // Define que é um controlador de API
    [ApiController]


    // Define que o tipo de resposta da API é JSON
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository? _generoRepository { get; set; }

        /// <summary>
        /// Instância do objeto _generoRepository para que haja referência aos métodos do repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método de listar os gêneros
        /// </summary>
        /// <returns> Lista de gêneros e um status code </returns>
        [HttpGet]
        [Authorize] // Precisa estar logado para acessar a rota
        public IActionResult Get()
        {
            try
            {
                // Cria uma lista para receber os gêneros
                List<GeneroDomain> listaGeneros = _generoRepository!.ListarTodos();

                // Retorna o status code 200 - Ok e a lista de gêneros no formato JSON
                return Ok(listaGeneros);
            }
            catch (Exception erro)
            {
                // Retorna o status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }

        }


        /// <summary>
        /// Endpoint que acessa o método de cadastrar um gênero
        /// </summary>
        /// <param name="novoGenero"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                // Faz a chamada para o método Cadastrar
                _generoRepository!.Cadastrar(novoGenero);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                // Retorna um BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o método de deletar um gênero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada do método Deletar
                _generoRepository!.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna um BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o método buscar por id de um gênero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository!.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound();
                }

                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o método atualizar por corpo
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult PutByBody(GeneroDomain genero)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository!.BuscarPorId(genero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(genero);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }

                return NotFound("Gênero não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o método atualizar por url
        /// </summary>
        /// <param name="genero"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutByUrl(GeneroDomain genero, int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository!.BuscarPorId(id);

                try
                {
                    if (generoBuscado != null)
                    {
                        _generoRepository.AtualizarIdUrl(id, genero);

                        return NoContent();
                    }
                }
                catch (Exception erro)
                {
                    return BadRequest(erro.Message);
                }
                
                return NotFound("Gênero não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
