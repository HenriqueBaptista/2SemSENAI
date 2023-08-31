using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Usuario
    /// </summary>
    public class UsuarioDomain
    {
        /// <summary>
        /// Id de um usuário já cadastrado
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
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string? Senha { get; set; }

        /// <summary>
        /// Permissão do usuário
        /// </summary>
        public string? Permissao { get; set; }
    }
}
