using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conexão para acessar o BD
        /// </summary>
        private string stringConection = "Data Source = NOTE23-S15; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Bane usuários (Apenas Admnistradores)
        /// </summary>
        public void BanirUsuario(UsuarioDomain usuario)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Cadastra novos usuários
        /// </summary>
        public void Cadastrar(UsuarioDomain usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConection))
            {
                string tipoUsuario;
                bool permissao = false;

                if (permissao == false)
                {
                    tipoUsuario = "Comum";
                }
                else
                {
                    tipoUsuario = "Administrador";
                }

                string queryAdd = $"INSERT INTO Usuario(Email, Senha, Permissao) VALUES (@Email, @Senha, {tipoUsuario})";


                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryAdd, con))
                {
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);

                    cmd.ExecuteNonQuery();

                }
            }
        }


        /// <summary>
        /// Loga um usuário
        /// </summary>
        public void Login(UsuarioDomain usuario)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Desloga um usuário
        /// </summary>
        public void Logout(UsuarioDomain usuario)
        {
            throw new NotImplementedException();
        }
    }
}