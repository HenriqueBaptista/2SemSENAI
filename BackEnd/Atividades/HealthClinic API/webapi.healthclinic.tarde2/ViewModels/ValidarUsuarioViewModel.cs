namespace webapi.healthclinic.tarde2.ViewModels
{
    /// <summary>
    /// ViewModel para o método ValidarUsuario (dá permissão a ele de Administrador, Médico ou de Paciente - de acordo com o Administrador
    /// </summary>
    public class ValidarUsuarioViewModel
    {
        /// <summary>
        /// IdUsuario
        /// </summary>
        public Guid IdUsuario { get; set; }


        /// <summary>
        /// IdTipoUsuario
        /// </summary>
        public Guid IdTipoUsuario { get; set; }
    }
}
