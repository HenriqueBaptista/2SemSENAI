using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    /// <summary>
    /// Repositório responsável pelo ComentarioEvento
    /// </summary>
    public class ComentarioEventoRepository : IComentarioEventoRepositoy
    {
        /// <summary>
        /// Acesso a context
        /// </summary>
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor para a obtenção da context
        /// </summary>
        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }


        /// <summary>
        /// Altera comentários
        /// </summary>
        public void AlterarExibicao(Guid id)
        {
            try
            {
                ComentarioEvento comentarioAlterar = _eventContext.ComentarioEvento.FirstOrDefault(c => c.IdComentarioEvento == id)!;

                switch (comentarioAlterar.Exibe)
                {
                    case true:
                        comentarioAlterar.Exibe = false;
                        break;

                    default:
                        comentarioAlterar.Exibe = true;
                        break;
                }

                _eventContext.Update(comentarioAlterar);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Busca comentários pelo id
        /// </summary>
        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                ComentarioEvento comentario = _eventContext.ComentarioEvento.Select(c => new ComentarioEvento
                {
                    IdComentarioEvento = c.IdComentarioEvento,
                    Descricao = c.Descricao,
                    Exibe = c.Exibe,

                    Usuario = new Usuario
                    {
                        Nome = c.Usuario!.Nome,
                        Email = c.Usuario!.Email,
                        TipoUsuario = c.Usuario.TipoUsuario
                    },

                    Evento = new Evento
                    {
                        NomeEvento = c.Evento!.NomeEvento,
                        DataEvento = c.Evento!.DataEvento,
                        Descricao = c.Evento!.Descricao,
                        TipoEvento = c.Evento.TipoEvento,
                        Instituicao = c.Evento.Instituicao
                    }
                }).FirstOrDefault()!;

                return comentario;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cadastra comentários
        /// </summary>
        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Deleta comentários
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                ComentarioEvento comentario = new ComentarioEvento();

                comentario.IdComentarioEvento = id;

                _eventContext.ComentarioEvento.Remove(comentario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Lista comentários
        /// </summary>
        public List<ComentarioEvento> Listar()
        {
            return _eventContext.ComentarioEvento.ToList();
        } //
    }
}
