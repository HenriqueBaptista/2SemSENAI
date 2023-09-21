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
        private readonly EventContext _eventContext; //

        /// <summary>
        /// Construtor para obtenção do acesso a context
        /// </summary>
        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        } //



        /// <summary>
        /// Atualiza tipos de usuário
        /// </summary>
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioAtualizar = _eventContext.TipoUsuario.Select(tu => new TipoUsuario
                {
                    IdTipoUsuario = tu.IdTipoUsuario,
                    Titulo = tu.Titulo
                }).FirstOrDefault(tu => tu.IdTipoUsuario == id)!;

                tipoUsuarioAtualizar = tipoUsuario;

                _eventContext.TipoUsuario.Update(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Busca usuários
        /// </summary>
        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _eventContext.TipoUsuario.Select(tu => new TipoUsuario
                {
                    IdTipoUsuario = tu.IdTipoUsuario,
                    Titulo = tu.Titulo
                }).FirstOrDefault(tu => tu.IdTipoUsuario == id)!;

                return tipoUsuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        } //


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
        } //


        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = new TipoUsuario();

                tipoUsuarioBuscado.IdTipoUsuario = id;

                _eventContext.Remove(tipoUsuarioBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        } //


        /// <summary>
        /// Lista os tipos de usuário
        /// </summary>
        public List<TipoUsuario> Listar()
        {
            return _eventContext.TipoUsuario.Select(tu => new TipoUsuario
            {
                IdTipoUsuario = tu.IdTipoUsuario,
                Titulo = tu.Titulo
            }).ToList();
        } //
    }
} // Complete
