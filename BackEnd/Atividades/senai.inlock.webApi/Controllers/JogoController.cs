using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.Data;

namespace senai.inlock.webApi_.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints do objeto Jogo
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        IJogoRepository? _jogoRepository { get; set; }

        /// <summary>
        /// Construtor do controlador
        /// </summary>
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }


        /// <summary>
        /// Endpoint que acessa o método ListarTodos
        /// </summary>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> listaJogos = _jogoRepository!.ListarTodos();

                return Ok(listaJogos);
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
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository!.Cadastrar(novoJogo);

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
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            JogoDomain jogoExistente = _jogoRepository!.BuscarPorId(id);

            if (jogoExistente != null)
            {
                try
                {
                    _jogoRepository!.Deletar(id);

                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro.Message);
                }
            }

            return NotFound("Jogo não cadastrado");
        }


        /// <summary>
        /// Endpoint que acessa o método BuscarPorId
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]

        public IActionResult Get(int id)
        {
            try
            {
                JogoDomain jogoBuscado = _jogoRepository!.BuscarPorId(id);

                if (jogoBuscado == null)
                {
                    return NotFound("Jogo não cadastrado");
                }

                return Ok(jogoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o método AtualizarIdCorpo
        /// </summary>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Put(JogoDomain jogo)
        {
            try
            {
                JogoDomain jogoBuscado = _jogoRepository!.BuscarPorId(jogo.IdJogo);

                if (jogoBuscado != null)
                {
                    try
                    {
                        _jogoRepository!.Atualizar(jogo);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }
                }

                return NotFound("Jogo não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
