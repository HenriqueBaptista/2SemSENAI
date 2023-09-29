using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Interfaces
{
    /// <summary>
    /// Interface de Consulta
    /// </summary>
    public interface IConsultaRepository
    {
        /// <summary>
        /// Cadastra consultas
        /// </summary>
        void Cadastrar(Consulta consulta);


        /// <summary>
        /// Deleta consultas
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Atualiza consultas
        /// </summary>
        void Atualizar(Guid id, Consulta consulta);


        /// <summary>
        /// Lista consultas
        /// </summary>
        List<Consulta> Listar();
    }
}
