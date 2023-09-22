using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos de PresencaEvento
    /// </summary>
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        /// <summary>
        /// Acesso a context
        /// </summary>
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor para a obtenção da context
        /// </summary>
        public PresencaEventoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Altera presenças
        /// </summary>
        public void Alterar(Guid id)
        {
            try
            {
                PresencaEvento presencaAlterar = _eventContext.PresencaEvento.FirstOrDefault(p => p.IdPresencaEvento == id)!;

                switch (presencaAlterar.Situacao)
                {
                    case true:
                        presencaAlterar.Situacao = false;
                        break;

                    default:
                        presencaAlterar.Situacao = true;
                        break;
                }

                _eventContext.Update(presencaAlterar);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Busca presenças pelo Id
        /// </summary>
        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                PresencaEvento eventoBuscado = _eventContext.PresencaEvento.Select(p => new PresencaEvento
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    Situacao = p.Situacao,

                    Usuario = new Usuario()
                    {
                        Nome = p.Usuario!.Nome,
                        Email = p.Usuario!.Email,
                        TipoUsuario = p.Usuario.TipoUsuario
                    },

                    Evento = new Evento()
                    {
                        NomeEvento = p.Evento!.NomeEvento,
                        DataEvento = p.Evento!.DataEvento,
                        Descricao = p.Evento!.Descricao,
                        TipoEvento = p.Evento.TipoEvento,
                        Instituicao = p.Evento.Instituicao
                    }
                }).FirstOrDefault(p => p.IdPresencaEvento == id)!;

                return eventoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Cadastra presenças
        /// </summary>
        /// <param name="presenca"></param>
        public void Cadastrar(PresencaEvento presenca)
        {
            try
            {
                _eventContext.PresencaEvento.Add(presenca);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Deleta presenças
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                PresencaEvento presencaBuscada = new PresencaEvento();

                presencaBuscada.IdPresencaEvento = id;

                _eventContext.Remove(presencaBuscada);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Lista presenças
        /// </summary>
        public List<PresencaEvento> Listar()
        {
            return _eventContext.PresencaEvento.Select(p => new PresencaEvento
            {
                IdPresencaEvento = p.IdPresencaEvento,
                Situacao = p.Situacao,

                Usuario = new Usuario()
                {
                    Nome = p.Usuario!.Nome
                },

                Evento = new Evento()
                {
                    NomeEvento = p.Evento!.NomeEvento,
                    DataEvento = p.Evento!.DataEvento,
                    Instituicao = p.Evento.Instituicao
                }
            }).ToList();
        } //
    }
}
