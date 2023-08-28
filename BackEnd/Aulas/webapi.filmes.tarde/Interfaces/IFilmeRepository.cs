using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FilmeRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IFilmeRepository
    {
        //CRUD - Create, Read, Update, Delete

        /// <summary>
        /// Cadastra um filme
        /// </summary>
        /// <param name="novoFilme"></param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns></returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FilmeDomain BuscarPorId(int id);    

        /// <summary>
        /// Atualiza um filme pelo corpo
        /// </summary>
        /// <param name="filme"></param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme pela url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filme"></param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
