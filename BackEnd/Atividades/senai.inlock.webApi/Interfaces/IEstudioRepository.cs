using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    /// <summary>
    /// Interface responsável pela classe EstudioRepository
    /// </summary>
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastra um novo Estudio
        /// </summary>
        void Cadastrar(EstudioDomain estudioNovo);


        /// <summary>
        /// Lista todos os estúdios já cadastrados
        /// </summary>
        List<EstudioDomain> ListarTodos();


        /// <summary>
        /// Busca um estúdio cadastrado para fazer mudanças
        /// </summary>
        EstudioDomain BuscarPorId(int id);


        /// <summary>
        /// Atualiza informações pelo id/corpo do objeto
        /// </summary>
        void AtualizarIdCorpo(EstudioDomain estudio);


        /// <summary>
        /// Deleta um estúdio já cadastrado
        /// </summary>
        void Deletar(int id);
    }
}
