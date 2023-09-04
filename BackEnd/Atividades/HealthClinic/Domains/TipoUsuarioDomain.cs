namespace HealthClinic.Domains
{
    /// <summary>
    /// Domain responsável pela classe TipoUsuario
    /// </summary>
    public class TipoUsuarioDomain
    {
        /// <summary>
        /// Id do tipo de usuário
        /// </summary>
        public int IdTipoUsuario { get; set; }

        /// <summary>
        /// Nome do tipo de usuário - Se ele é Comum, Administrador ou Médico
        /// </summary>
        public string? TituloTipoUsuario { get; set; }
    }
}
