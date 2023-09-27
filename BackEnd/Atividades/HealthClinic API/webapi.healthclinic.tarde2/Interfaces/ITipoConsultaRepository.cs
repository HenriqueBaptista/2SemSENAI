using webapi.healthclinic.tarde2.Domains;

namespace webapi.healthclinic.tarde2.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de TipoConsulta
    /// </summary>
    public interface ITipoConsultaRepository
    {
        /// <summary>
        /// Cadastra tipos de consulta - Só Administrador
        /// </summary>
        void Cadastrar(TipoConsulta tipoConsulta);

        /// <summary>
        /// Deleta tipos de consulta - Só Administrador
        /// </summary>
        void Deletar(Guid id);

        /// <summary>
        /// Atualiza tipos de consulta - Só Administrador
        /// </summary>
        void Atualizar(Guid id);

        /// <summary>
        /// Lista tipos de consulta - Qualquer um
        /// </summary>
        List<TipoConsulta> Listar();
    }
}
