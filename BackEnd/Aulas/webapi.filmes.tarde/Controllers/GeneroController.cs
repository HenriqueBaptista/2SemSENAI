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
        /// Deleta um gênero existente
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
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                // Retorna um BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }
    }
}
