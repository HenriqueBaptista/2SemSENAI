using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos de Evento
    /// </summary>
    public class EventoRepository : IEventoRepository
    {
        /// <summary>
        /// Acesso a content
        /// </summary>
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor para a obtenção da content
        /// </summary>
        public EventoRepository()
        {
            _eventContext = new EventContext();
        } //


        /// <summary>
        /// Atualiza eventos
        /// </summary>
        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Select(e => new Evento
                {
                    IdEvento = e.IdEvento,
                    DataEvento = e.DataEvento,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,
                    IdTipoEvento = e.IdTipoEvento,
                    IdInstituicao = e.IdInstituicao
                }).FirstOrDefault()!;

                eventoBuscado = evento;

                _eventContext.Evento.Update(evento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        } //


        /// <summary>
        /// Busca eventos pelo Id
        /// </summary>
        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Select(e => new Evento
                {
                    IdEvento = e.IdEvento,
                    DataEvento = e.DataEvento,
                    NomeEvento = e.NomeEvento,
                    Descricao = e.Descricao,

                    TipoEvento = new TipoEvento()
                    {
                        IdTipoEvento = e.TipoEvento!.IdTipoEvento,
                        Titulo = e.TipoEvento!.Titulo,
                    },

                    Instituicao = new Instituicao()
                    {
                        IdInstituicao = e.Instituicao!.IdInstituicao,
                        CNPJ = e.Instituicao!.CNPJ,
                        Endereco = e.Instituicao!.Endereco,
                        NomeFantasia = e.Instituicao!.NomeFantasia
                    }
                }).FirstOrDefault(e => e.IdEvento == id)!;

                return eventoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Cadastra eventos
        /// </summary>
        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Deleta eventos
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                Evento eventoBuscado = new Evento();

                eventoBuscado.IdEvento = id;

                _eventContext.Evento.Remove(eventoBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Lista eventos
        /// </summary>
        public List<Evento> Listar()
        {
            return _eventContext.Evento.ToList();
        } //
    }
} // Complete
