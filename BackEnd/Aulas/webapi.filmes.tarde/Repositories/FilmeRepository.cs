using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos filmes
    /// </summary>
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: Nome do servidor do banco
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação
        ///     - Windows: Integrated Security = True
        ///     - SqlServer: User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE23-S15; Initial Catalog = FilmesTarde; User Id = sa; Pwd = Senai@134";


        /// <summary>
        /// Atualiza um filme, seu Id passa pelo corpo
        /// </summary>
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryGetByBody = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryGetByBody, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("IdFilme", filme.IdFilme);

                    cmd.ExecuteNonQuery();
                }
            }
        } // Complete


        /// <summary>
        /// Atualiza um filme, seu Id passa pela Url
        /// </summary>
        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryGetByBody = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryGetByBody, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Busca um filme por seu Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT IdFilme, IdGenero, Titulo FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        return filmeBuscado;
                    }
                }
            }
            return null!;
        } // Complete


        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme"> Novo filme a ser adicionado </param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryRegister = "INSERT INTO Filme(IdGenero, Titulo) VALUES (@intGen, @Titulo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryRegister, con))
                {
                    cmd.Parameters.AddWithValue("@intGen", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        } // Complete


        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryDelete = "DELETE FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        } // Complete


        /// <summary>
        /// Lista todos os filmes já cadastrados
        /// </summary>
        /// <returns></returns>
        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilmes    = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdFilme, IdGenero, Titulo FROM Filme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filmes = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            IdGenero = Convert.ToInt32(rdr[1]),
                            Titulo = Convert.ToString(rdr["Titulo"])
                        };
                        listaFilmes.Add(filmes);
                    }
                }
            }
            return listaFilmes;
        } // Complete
    }
}
