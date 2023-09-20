using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos de Usuario
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Chamada do EventContext
        /// </summary>
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor do repositório - chama o EventContext
        /// </summary>
        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }


        /// <summary>
        /// Atualiza o usuário
        /// </summary>
        public void Atualizar(Usuario usuario)
        {
            _eventContext.Usuario.Update(usuario);
        }


        /// <summary>
        /// Busca usuários pelo email e senha
        /// </summary>
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario.Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario()
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }
                ).FirstOrDefault(u => u.Email! == email!)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere) 
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Busca usuários pelo Id
        /// </summary>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,

                    TipoUsuario = new TipoUsuario()
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }
                ).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Cadastra usuários
        /// </summary>
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Add(usuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Deleta usuários
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                Usuario UsuarioBuscado = new Usuario();

                UsuarioBuscado.IdTipoUsuario = id;

                _eventContext.Remove(UsuarioBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista usuários
        /// </summary>
        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
