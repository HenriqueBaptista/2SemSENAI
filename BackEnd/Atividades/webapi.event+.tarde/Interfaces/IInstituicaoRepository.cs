using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de IInstituicao
    /// </summary>
    public interface IInstituicaoRepository
    {
        /// <summary>
        /// Cadastra instituições
        /// </summary>
        void Cadastrar(Instituicao instituicao);


        /// <summary>
        /// Lista instituições
        /// </summary>
        List<Instituicao> Listar();


        /// <summary>
        /// Busca instituições pelo Id
        /// </summary>
        Instituicao BuscarPorId(Guid id);


        /// <summary>
        /// Atualiza instituições
        /// </summary>
        void Atualizar(Guid id, Instituicao instuicao);


        /// <summary>
        /// Deleta instituições
        /// </summary>
        void Deletar(Guid id);
    }
}
