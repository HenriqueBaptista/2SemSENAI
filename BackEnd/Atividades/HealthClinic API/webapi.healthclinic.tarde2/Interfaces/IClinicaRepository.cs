using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Interfaces
{
    /// <summary>
    /// Interface de Clinica
    /// </summary>
    public interface IClinicaRepository
    {
        /// <summary>
        /// Cadastra clínicas
        /// </summary>
        void Cadastrar(Clinica clinica);


        /// <summary>
        /// Deleta clínicas
        /// </summary>
        void Deletar(Guid id);


        /// <summary>
        /// Atualiza clínicas
        /// </summary>
        void Atualizar(Guid id, Clinica clinica);


        /// <summary>
        /// Lista clínicas
        /// </summary>
        List<Clinica> Listar();
    }
}
