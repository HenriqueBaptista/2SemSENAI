using webapi.inlock.CodeFirst_Tarde.Domains;

namespace webapi.inlock.codeFirst.tarde2.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario BuscarUsuario(string email, string senha);

        public void Cadastrar(Usuario usuario);
    }
}
