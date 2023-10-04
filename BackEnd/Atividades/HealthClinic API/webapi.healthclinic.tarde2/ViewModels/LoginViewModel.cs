using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.tarde2.ViewModels
{
    /// <summary>
    /// ViewModel para o método Login
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Email do usuário
        /// </summary>
        [Required(ErrorMessage = "Email obrigatório!")]
        public string? Email { get; set; }


        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "Senha obrigatória!")]
        public string? Senha { get; set; }
    }
}