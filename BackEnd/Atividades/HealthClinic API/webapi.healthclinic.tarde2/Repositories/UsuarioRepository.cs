using webapi.healthclinic.tarde2.Contexts;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;
using webapi.healthclinic.tarde2.Utils;

namespace webapi.healthclinic.tarde2.Repositories
{
    /// <summary>
    /// Repositório de Usuário
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HealthContext healthContext;


        /// <summary>
        /// Usa o HealthContext
        /// </summary>
        public UsuarioRepository()
        {
            healthContext = new HealthContext();
        }


        /// <summary>
        /// Atualiza usuários
        /// </summary>
        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioAtualizar = healthContext.Usuario.Select(u => new Usuario
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,
                Senha = u.Senha,
                CPF = u.CPF
            }).FirstOrDefault(u => u.IdUsuario == id)!;

            usuarioAtualizar = usuario;

            healthContext.Update(usuario);

            healthContext.SaveChanges();
        }


        /// <summary>
        /// Busca usuários pelo Id
        /// </summary>
        public Usuario Buscar(Guid id)
        {
            try
            {
                Usuario usuario = healthContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = id,
                    Nome = u.Nome,
                    Email = u.Email,
                    CPF = u.CPF,

                    TipoUsuario = new TipoUsuario
                    {
                        Titulo = u.TipoUsuario!.Titulo
                    }

                }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Busca usuários pelo email e senha
        /// </summary>
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = healthContext.Usuario.Select(u => new Usuario
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
        /// Cadastra usuários
        /// </summary>
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                healthContext.Usuario.Add(usuario);

                healthContext.SaveChanges();
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
                Usuario usuario = new Usuario();

                usuario.IdTipoUsuario = id;

                healthContext.Usuario.Remove(usuario);

                healthContext.SaveChanges();
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
            try
            {
                return healthContext.Usuario.Select(u => new Usuario
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,
                    CPF = u.CPF,
                    DataNascimento = u.DataNascimento,

                    TipoUsuario = new TipoUsuario
                    {
                        Titulo = u.TipoUsuario!.Titulo
                    }
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
