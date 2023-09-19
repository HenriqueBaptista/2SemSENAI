using System.ComponentModel.DataAnnotations;

namespace webapi.event_.tarde.ViewModels
{
    /// <summary>
    /// ViewModel resposável pela classe Usuário.
    /// Nesta ViewModel, só é para conter Email e Senha do Usuário
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
