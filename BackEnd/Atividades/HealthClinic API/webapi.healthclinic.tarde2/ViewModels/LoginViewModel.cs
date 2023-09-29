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
        [Required(ErrorMessage = "O email é obrigatório")]
        public string? Email { get; set; }


        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Senha { get; set; }
    }
}