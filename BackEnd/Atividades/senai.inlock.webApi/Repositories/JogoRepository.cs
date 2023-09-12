using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos do objeto Jogo
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexão para acessar o BD
        /// </summary>
        public string stringCon = "Data Source = NOTE23-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";


        /// <summary>
        /// Atualiza um jogo
        /// </summary>
        public void Atualizar(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string queryUpdate = "UPDATE Jogo SET IdEstudio = @IdEstudio, Nome = @Nome, Descricao = @Descricao, DataLancamento = @DataLancamento Valor = @Valor WHERE IdJogo = @IdJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@IdJogo", jogo.IdJogo);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Busca determinado jogo
        /// </summary>
        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string querySearch = "SELECT * FROM Jogo WHERE IdJogo = @IdJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySearch, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = rdr["DataLancamento"].ToString(),
                            Valor = Convert.ToDouble(rdr["Valor"])
                        };

                        return jogoBuscado;
                    }

                    return null!;
                }
            }
        }


        /// <summary>
        /// Cadastra um jogo novo
        /// </summary>
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string queryRegister = "INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor) VALUES (@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryRegister, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string queryListAll = "SELECT * FROM Jogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryListAll, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogoListado = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString(),
                            Descricao = rdr["Descricao"].ToString(),
                            DataLancamento = rdr["DataLancamento"].ToString(),
                            Valor = Convert.ToDouble(rdr["Valor"])
                        };

                        listaJogos.Add(jogoListado);
                    };
                }
            }

            return listaJogos;
        }
    }
}
