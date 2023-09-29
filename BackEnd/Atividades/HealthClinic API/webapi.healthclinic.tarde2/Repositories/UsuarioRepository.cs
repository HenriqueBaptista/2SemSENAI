using webapi.healthclinic.tarde2.Contexts;
using webapi.healthclinic.tarde2.Domains;
using webapi.healthclinic.tarde2.Interfaces;

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

                    TipoUsuario = u.TipoUsuario

                }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuario;
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
                healthContext.Usuario.Add(usuario);

                usuario.TipoUsuario!.Titulo = "Sem permissão";

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
                return healthContext.Usuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
