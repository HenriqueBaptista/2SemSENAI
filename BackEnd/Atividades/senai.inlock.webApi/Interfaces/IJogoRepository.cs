using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    /// <summary>
    /// Interface responsável pela classe JogoRepository
    /// </summary>
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        void Cadastrar(JogoDomain novoJogo);


        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        List<JogoDomain> ListarTodos();


        /// <summary>
        /// Busca determinado jogo pelo seu Id
        /// </summary>
        JogoDomain BuscarPorId(int id);


        /// <summary>
        /// Atualiza determinado jogo
        /// </summary>
        void Atualizar(JogoDomain jogo);


        /// <summary>
        /// Deleta um jogo já existente
        /// </summary>
        void Deletar(int id);
    }
}
