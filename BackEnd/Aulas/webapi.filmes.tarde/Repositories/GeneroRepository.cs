using System.Data.SqlClient;
using System.Xml.Linq;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    /// <summary>
    /// Classe esponsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source: Nome do servidor do banco
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação
        ///     - Windows: Integrated Security = True
        ///     - SqlServer: User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexão = "Data Source = NOTE23-S15; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genero"></param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexão))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @NomeUp WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("NomeUp", genero.Nome);
                    cmd.Parameters.AddWithValue("IdGenero", genero.IdGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um objeto já adicionado, alterando algum de seus valores. Atualiza através da URL do objeto.
        /// </summary>
        /// <param name="id"> Id a ser procurado </param>
        /// <param name="genero"> Gênero que terá sessões a serem alteradas </param>
        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexão))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @NomeUp WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("NomeUp", genero.Nome);
                    cmd.Parameters.AddWithValue("IdGenero", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um objeto gênero através de seu Id
        /// </summary>
        /// <param name="id"> Id do gênero a ser buscado </param>
        /// <returns></returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexão))
            {
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con)) 
                {
                    cmd.Parameters.AddWithValue("IdGenero", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        return generoBuscado;
                    }
                }
            }
            return null!;
        }


        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero"> Objeto com as infomações que serão cadastradas </param>
        /// <exception cref="NotImplementedException"></exception>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            // Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexão))
            {
                // Declara a query que será executada
                string queryInsert = $"INSERT INTO Genero(Nome) VALUES (@Nome)";

                // Declara o SqlCommand passando a query que será executada e a conexão con com o banco de dados
                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {
                    cmd.Parameters.AddWithValue("Nome", novoGenero.Nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        } // Complete


        /// <summary>
        /// Deleta um gênero
        /// </summary>
        /// <param name="id"> Deleta o gênero pelo seu Id </param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexão))
            {
                string queryDelete = $"DELETE FROM Genero WHERE IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("IdGenero", id);

                    cmd.ExecuteNonQuery();
                }
            }
        } // Complete


        /// <summary>
        /// Listar todos os objetos do tipo gênero
        /// </summary>
        /// <returns> Lista de objetos do tipo gênero </returns>
        public List<GeneroDomain> ListarTodos()
        {
            // Cria uma lista de gêneros onde serão armazenados os gêneros
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnecytion passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexão))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para percorrer (ler) a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr
                    // O laço se repetirá
                    while (rdr.Read()) 
                    {
                        // Instancia um objeto do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            // Atribui a propriedade IdGenero o valor coluna IdGenero
                            IdGenero = Convert.ToInt32(rdr[0]),

                            // Atribui a propriedade Nome o valor da coluna Nome
                            Nome = Convert.ToString(rdr["Nome"])
                        };
                        // Adiciona um objeto criado dentro da lista
                        listaGeneros.Add(genero);
                    }
                }
            }
            // Retorna a lista de gêneros
            return listaGeneros;
        } // Complete
    }
}
