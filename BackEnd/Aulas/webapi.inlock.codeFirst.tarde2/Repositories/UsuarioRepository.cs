using webapi.inlock.codeFirst.tarde2.Interfaces;
using webapi.inlock.codeFirst.tarde2.Utils;
using webapi.inlock.CodeFirst_Tarde.Contexts;
using webapi.inlock.CodeFirst_Tarde.Domains;

namespace webapi.inlock.codeFirst.tarde2.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InlockContext context;

        public UsuarioRepository()
        { 
        context = new InlockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = context.Usuario.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confirma = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confirma)
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

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                context.Usuario.Add(usuario);

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
