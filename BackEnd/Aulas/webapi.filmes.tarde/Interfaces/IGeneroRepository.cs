using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo reposiório GeneroRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD - Create, Read, Update, Delete
        //TipoDeRetorno NomeMetodo(TipoParametros NomeParametros)

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero"> Objeto que será cadastrado </param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retornar todos os gêneros cadatrados
        /// </summary>
        /// <returns> Uma lista de gêneros </returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Buscar um objeto através do seu Id
        /// </summary>
        /// <param name="id"> Id do objeto que será buscado </param>
        /// <returns> Objeto que foi buscado </returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Atualizar um gênero existente passando o Id pelo corpo da requisição
        /// </summary>
        /// <param name="genero"> Objeto com as novas informações </param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar um gênero existente passando o Id pela URL da requisição
        /// </summary>
        /// <param name="id"> Id do objeto a ser atualizado </param>
        /// <param name="genero"> Objeto com as novas informações </param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deletar um gênero existente
        /// </summary>
        /// <param name="id"> Id do objeto a ser deletado </param>
        void Deletar(int id);
    }
}
