using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos de TipoEvento
    /// </summary>
    public class TipoEventoRepository : ITipoEventoRepository
    {
        /// <summary>
        /// Acesso a context
        /// </summary>
        private readonly EventContext _eventContext; //

        /// <summary>
        /// Construtor para obtenção do acesso a context
        /// </summary>
        public TipoEventoRepository()
        {
            _eventContext = new EventContext(); 
        } //


        /// <summary>
        /// Atualiza tipos de evento
        /// </summary>
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento tipoEventoAtualizar = _eventContext.TipoEvento.Select(te => new TipoEvento
                {
                    IdTipoEvento = te.IdTipoEvento,
                    Titulo = te.Titulo
                }).FirstOrDefault(te => te.IdTipoEvento == id)!;

                tipoEventoAtualizar = tipoEvento;

                _eventContext.TipoEvento.Update(tipoEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Busca tipos de evento pelo Id
        /// </summary>
        public TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _eventContext.TipoEvento.Select(te => new TipoEvento
                {
                    IdTipoEvento = te.IdTipoEvento,
                    Titulo = te.Titulo
                }).FirstOrDefault(te => te.IdTipoEvento == id)!;

                return tipoEventoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Cadastra tipos de evento
        /// </summary>
        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                _eventContext.TipoEvento.Add(tipoEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Deleta tipos de evento
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = new TipoEvento();

                tipoEventoBuscado.IdTipoEvento = id;

                _eventContext.Remove(tipoEventoBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Lista tipos de evento
        /// </summary>
        public List<TipoEvento> Listar()
        {
            return _eventContext.TipoEvento.Select(tu => new TipoEvento
            {
                IdTipoEvento = tu.IdTipoEvento,
                Titulo = tu.Titulo
            }).ToList();
        } //
    }
} // Complete
