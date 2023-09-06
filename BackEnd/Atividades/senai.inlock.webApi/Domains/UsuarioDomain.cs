using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    /// <summary>
    /// Classe responsável pelas propriedades do Usuário
    /// </summary>
    public class UsuarioDomain
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public int IdUsuario { get; set; }


        /// <summary>
        /// Email do usuário
        /// </summary>
        [Required(ErrorMessage = "O email é obrigatório!")] public string? Email { get; set; }


        /// <summary>
        /// Senha do usuário
        /// </summary>
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha permite no mínimo 3 caracteres e no máximo 20 caracteres!")]
        [Required(ErrorMessage = "A senha é obrigatória")] public string? Senha { get; set; }


        /// <summary>
        /// Tipo de usuário - Cliente ou Administrador
        /// </summary>
        public string? TipoUsuario { get; set; }
    }
}
