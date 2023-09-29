using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Interfaces
{
    /// <summary>
    /// Interface de TipoConsulta
    /// </summary>
    public interface ITipoConsultaRepository
    {
        /// <summary>
        /// Cadastra tipos de consulta 
        /// </summary>
        void Cadastrar(TipoConsulta tipoConsulta);

        /// <summary>
        /// Deleta tipos de consulta
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// Atualiza tipos de consulta
        /// </summary>
        void Atualizar(Guid id, TipoConsulta tipoConsulta);

        /// <summary>
        /// Lista tipos de consulta
        /// </summary>
        List<TipoConsulta> Listar();
    }
}
