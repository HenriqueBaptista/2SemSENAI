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

        void Cadastrar(FilmeDomain novoFilme);

        List<FilmeDomain> ListarTodos();

        FilmeDomain BuscarPorId(int id);    

        void AtualizarIdCorpo(FilmeDomain filme);

        void AtualizarIdCorpo(int id, FilmeDomain filme);

        void Deletar(int id);
    }
}
