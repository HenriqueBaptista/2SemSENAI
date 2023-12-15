using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        private IComentariosEventoRepository comentarios { get; set; }

        /// <summary>
        /// Armazena dados da API externa
        /// </summary>
        private readonly ContentModeratorClient _contentModeratorClient;

        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            comentarios = new ComentariosEventoRepository();

            _contentModeratorClient = contentModeratorClient;
        }


        [HttpPost("CadastroIa")]
        public async Task<IActionResult> Post(ComentariosEvento comentario) {
            try
            {
                // Se a descrição do comentário não for passada no objeto
                if (string.IsNullOrEmpty(comentario.Descricao))
                {
                    return BadRequest("O texto a ser analisado não pode ser vazio!");
                }

                // Converte a string(descrição do comentário) em um MemoryStream
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(comentario.Descricao));

                // Realiza a moderação do conteúdo(descrição do comentário)
                var moderationResult = await _contentModeratorClient.TextModeration.ScreenTextAsync("text/plain", stream, "por", false, false, null, true);

                // Se existir termos ofensivos
                if (moderationResult.Terms != null)
                {
                    // Atribuir false para "Exibe"
                    comentario.Exibe = false;

                    // Cadastra o comentário
                    comentarios.Cadastrar(comentario);
                } // Senão
                else
                {
                    // Atribuir true para "Exibe"
                    comentario.Exibe = true;

                    // Cadastra o comentário
                    comentarios.Cadastrar(comentario);
                }

                return StatusCode(201, comentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("ListarIa")]
        public IActionResult GetIa()
        {
            try
            {
                return Ok(comentarios.ListarSomenteExibe());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(comentarios.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult ListarPorUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                ComentariosEvento comentarioBuscado = comentarios.BuscarPorIdUsuario(idUsuario, idEvento);

                if (comentarioBuscado == null)
                {
                    return NotFound("Comentário não encontrado");
                }
                else
                {
                    return Ok(comentarioBuscado);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                comentarios.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }
    }
}
