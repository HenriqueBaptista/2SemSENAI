using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace senai.inlock.webApi_.Repositories
{
    /// <summary>
    /// Repositório responsável pelos métodos do objeto Usuário
    /// </summary>
    public class EstudioRepository : IEstudioRepository
    {
        /// <summary>
        /// String de conexão para acessar o BD
        /// </summary>
        public string stringCon = "Data Source = NOTE23-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";


        /// <summary>
        /// Atualiza informações do Estúdio pelo id/corpo do objeto
        /// </summary>
        public void AtualizarIdCorpo(EstudioDomain estudioAtualizando)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string queryUpdate = "UPDATE Estudio SET Nome = @Nome WHERE IdEstudio = @IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudioAtualizando.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", estudioAtualizando.IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Busca um estúdio cadastrado para fazer mudanças
        /// </summary>
        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string querySearchById = "SELECT * FROM Estudio WHERE IdEstudio = @IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        return estudioBuscado;
                    }

                    return null!;
                }
            }
        }


        /// <summary>
        /// Cadastra um novo Estudio
        /// </summary>
        public void Cadastrar(EstudioDomain estudioNovo)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string queryRegister = "INSERT INTO Estudio(Nome) VALUES (@Nome)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryRegister, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudioNovo.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Deleta um estúdio já cadastrado
        /// </summary>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Lista todos os estúdios já cadastrados
        /// </summary>
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringCon))
            {
                string queryListAll = "SELECT IdEstudio, Nome FROM Estudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryListAll, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudioListado = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        listaEstudios.Add(estudioListado);
                    }
                }
            }
            return listaEstudios;
        } // Completo
    }
}
