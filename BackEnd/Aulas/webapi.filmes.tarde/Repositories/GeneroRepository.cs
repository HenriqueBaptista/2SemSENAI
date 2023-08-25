using System.Data.SqlClient;
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
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Busca determinado objeto gênero através de seu Id
        /// </summary>
        /// <param name="id"> Id a ser buscado </param>
        /// <returns></returns>
        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        } // Complete


        /// <summary>
        /// Deleta um objeto do tipo gênero
        /// </summary>
        /// <param name="idDel"> Deleta o gênero pelo seu Id </param>
        public void Deletar(int idDel)
        {
            GeneroDomain genero = new GeneroDomain();

            genero.IdGenero = idDel;

            using (SqlConnection con = new SqlConnection(StringConexão))
            {
                string queryDelete = $"DELETE FROM Genero WHERE IdGenero = {idDel}";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


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
