using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos do objeto Usuário
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conexão para acessar o BD
        /// </summary>
        public string stringCon = "Data Source = NOTE23-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";


        /// <summary>
        /// Loga o usuário
        /// </summary>
        /// <param name="email"> Email do usuário </param>
        /// <param name="senha"> Senha do usuário </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string? queryLogin = "SELECT IdUsuario, Email, IdTipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            TipoUsuario = rdr["IdTipoUsuario"].ToString()
                        };

                        return usuario;
                    }
                    return null!;
                }
            }
        }
    }
}
