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
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme através do seu id
        /// </summary>
        FilmeDomain BuscarPorId(int id);    

        /// <summary>
        /// Atualiza um filme pelo corpo
        /// </summary>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza um filme pela url
        /// </summary>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um filme
        /// </summary>
        void Deletar(int id);
    }
}
