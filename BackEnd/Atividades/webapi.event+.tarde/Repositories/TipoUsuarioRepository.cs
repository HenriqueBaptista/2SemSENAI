using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos de TipoUsuario
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Acesso a context
        /// </summary>
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor para obtenção do acesso a context
        /// </summary>
        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }


        /// <summary>
        /// Atualiza tipos de usuário
        /// </summary>
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Busca usuários
        /// </summary>
        public TipoUsuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Cadastra um tipo de usuário
        /// </summary>
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Lista os tipos de usuário
        /// </summary>
        public List<TipoUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
