using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de Evento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        /// <summary>
        /// Chamada da interface de Evento
        /// </summary>
        private IEventoRepository _eventoRepository { get; set; }

        /// <summary>
        /// Construtor do controller - chama o repositório de Evento
        /// </summary>
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }
    }
}
