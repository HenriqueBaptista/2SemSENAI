using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ComentariosEventoController()
        {
            comentarios = new ComentariosEventoRepository();
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

        [HttpGet("BuscarPorIdUsuario/{id}")]
        public IActionResult ListarPorUsuario(Guid id, Guid idEvento)
        {
            try
            {
                ComentariosEvento comentarioBuscado = comentarios.BuscarPorIdUsuario(id, idEvento);

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

        [HttpPost]
        public IActionResult Postar(ComentariosEvento novoComentario)
        {
            try
            {
                comentarios.Cadastrar(novoComentario);
                return StatusCode(201, novoComentario);
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
